namespace Scientific_Calculator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Interfaces;

    [Core]
    public class MethodInvoker : IMethodInvoker
    {
        private readonly IDictionary<string, MethodInfo> methodsByName;

        public MethodInvoker(params Type[] types)
        {
            this.methodsByName = new Dictionary<string, MethodInfo>();
            this.GenerateMethodInfo(types);
        }

        public MethodInfo GetMethodByName(Type type, string name)
        {
            var method = type.GetMethod(name);

            return method;
        }

        public void GenerateMethodInfo(params Type[] types)
        {
            foreach (var type in types)
            {
                var methods = Assembly.GetExecutingAssembly().GetTypes().First(typ => typ == type).GetMethods();
                foreach (var method in methods)
                {
                    this.methodsByName.Add(method.Name, method);
                }
            }
        }

        public void GenerateMethodInfo(Type type, string methodName)
        {
            if (!this.methodsByName.ContainsKey(methodName))
            {
                var method = type.GetMethod(methodName);
                if (method != null)
                {
                    this.methodsByName.Add(method.Name, method);
                }
            }
        }
    }
}
