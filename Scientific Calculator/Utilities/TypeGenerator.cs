namespace Scientific_Calculator.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class TypeGenerator
    {
        public static IEnumerable<Type> GenerateTypes(Type type, string replacer, string replaced)
        {
            var types =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(
                        typ =>
                        typ.IsAssignableFrom(typeof(Attribute))
                        && typ.Name == type.Name.Replace(replaced, replacer));

            return types;
        }
    }
}
