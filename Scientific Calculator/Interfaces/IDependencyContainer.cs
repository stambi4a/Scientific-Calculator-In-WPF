namespace Scientific_Calculator.Interfaces
{
    using System;

    public interface IDependencyContainer
    {
        T Resolve<T>();

        void ResolveDependencies(object obj);

        object GetComponent(string componentName, Type[] typeParameters);

        void AddDependency(Type from, object to);
    }
}
