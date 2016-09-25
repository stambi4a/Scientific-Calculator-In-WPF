namespace Scientific_Calculator.Interfaces
{
    using System;
    using System.Reflection;

    public interface IMethodInvoker
    {
        MethodInfo GetMethodByName(Type type, string name);

        void GenerateMethodInfo(Type type, string methodName);
    }
}
