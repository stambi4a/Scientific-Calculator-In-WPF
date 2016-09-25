namespace Scientific_Calculator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Exceptions;
    using Scientific_Calculator.Interfaces;

    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<string, Type> componentsByName;
        private readonly IDictionary<Type, object> cachedComponents;

        private readonly IDictionary<Type, Type> coreComponentsWithParents;
        private readonly IDictionary<Type, object> cachedCoreComponents;

        private readonly ITypeProvider typeProvider;

        public DependencyContainer()
        {
            this.typeProvider = new TypeProvider();
            this.componentsByName = new Dictionary<string, Type>();
            this.cachedComponents = new Dictionary<Type, object>();
            this.coreComponentsWithParents = new Dictionary<Type, Type>();
            this.cachedCoreComponents = new Dictionary<Type, object>();
            this.FillCoreComponents();
            this.MapComponentNames();
        }

        public T Resolve<T>()
        {
            if (!this.coreComponentsWithParents.ContainsKey(typeof(T)))
            {
                throw new UnmappableTypeException(typeof(T).Name);
            }

            var resolvedType = typeof(T);
            var resultType = this.coreComponentsWithParents[resolvedType];
            if (this.cachedCoreComponents.ContainsKey(resolvedType))
            {
                return (T)this.cachedCoreComponents[resolvedType];
            }

            var parameters = resultType.GetConstructors().FirstOrDefault().GetParameters().Select(param => param.ParameterType);

            var result = (T)Activator.CreateInstance(resultType, (from parameter in parameters where this.cachedCoreComponents.ContainsKey(parameter) select this.cachedCoreComponents[parameter]).ToArray());

            this.ResolveDependencies(result);

            this.cachedCoreComponents.Add(resolvedType, result);

            return result;
        }

        public void ResolveDependencies(object obj)
        {
            var currentDependencies =
                obj.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(
                        dependency =>
                        dependency.GetCustomAttributes().Any(attr => attr.GetType() == typeof(InjectAttribute)))
                    .ToArray();

            foreach (var dependency in currentDependencies)
            {
                var currentDependencySource = dependency.FieldType;

                if (!this.coreComponentsWithParents.ContainsKey(currentDependencySource))
                {
                    throw new UnmappableTypeException(currentDependencySource.Name);
                }

                var currentDependencyTarget = this.coreComponentsWithParents[currentDependencySource];

                object currentDependencyInstance = null;
                if (this.cachedCoreComponents.ContainsKey(currentDependencySource))
                {
                    currentDependencyInstance = this.cachedCoreComponents[currentDependencySource];
                    dependency.SetValue(obj, currentDependencyInstance);
                }
                else
                {
                    var parameters = currentDependencyTarget.GetConstructors().FirstOrDefault().GetParameters().Select(param=>param.ParameterType);
                    var parameterInstances = new List<object>();
                    foreach (var parameter in parameters)
                    {
                        if (this.cachedCoreComponents.ContainsKey(parameter))
                        {
                            parameterInstances.Add(this.cachedCoreComponents[parameter]);
                        }
                    }
      
                    currentDependencyInstance = Activator.CreateInstance(currentDependencyTarget, parameterInstances.ToArray());
                    dependency.SetValue(obj, currentDependencyInstance);
                    this.cachedCoreComponents.Add(currentDependencySource, currentDependencyInstance);
                    this.ResolveDependencies(currentDependencyInstance);
                }
            }
        }

        public void AddDependency(Type from, object to)
        {
            this.cachedCoreComponents.Add(from, to);
            this.coreComponentsWithParents.Add(to.GetType(), from);
        }

        public object GetComponent(string componentName, Type[] typeParameters)
        {
            if (!this.componentsByName.ContainsKey(componentName))
            {
                throw new NonExistantTypeException();
            }

            var type = this.componentsByName[componentName];
            if (type.IsGenericType)
            {
                type = type.MakeGenericType(typeParameters);
            }

            object instance = null;

            if (this.cachedComponents.ContainsKey(type))
            {
                instance = this.cachedComponents[type];
            }
            else
            {
                instance = Activator.CreateInstance(type);
                this.cachedComponents.Add(type, instance);
            }

            return instance;
        }

        public MethodInfo GetMethod(Type componentType, Type[] typeParameters, string methodName)
        {
            var methodInfo = componentType.GetMethod(methodName);
            if (methodInfo.IsGenericMethod)
            {
                methodInfo = methodInfo.MakeGenericMethod(typeParameters);
            }

            return methodInfo;
        }

        private void FillCoreComponents()
        {
            foreach (
                var classWithComponentAttribute in this.typeProvider.GetTypesByAttribute(typeof(CoreAttribute)))
            {
                foreach (var parent in classWithComponentAttribute.GetInterfaces())
                {
                    this.coreComponentsWithParents.Add(parent, classWithComponentAttribute);
                }
            }
        }

        private void MapComponentNames()
        {
            foreach (
                var classWithComponentAttribute in this.typeProvider.GetTypesByAttribute(typeof(ComponentAttribute)))
            {
                this.componentsByName.Add(classWithComponentAttribute.Name, classWithComponentAttribute);
            }
        }
    }
}