namespace Scientific_Calculator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Scientific_Calculator.Attributes;
    using Scientific_Calculator.Interfaces;

    [Core]
    public class TypeProvider : ITypeProvider
    {
        private Type[] types;
        private readonly Dictionary<Type, Type[]> typesByAttribute;

        public TypeProvider()
        {
            this.GetTypes();
            this.typesByAttribute = new Dictionary<Type, Type[]>();
        }

        public Type[] GetTypesByAttribute(Type attrType)
        {
            if (this.typesByAttribute.ContainsKey(attrType))
            {
                return this.typesByAttribute[attrType];
            }

            var attrTypes =
                this.types.Where(
                    typ => typ.IsDefined(attrType)).ToArray();
            this.typesByAttribute.Add(attrType, attrTypes);

            return attrTypes;
        }

        public Type ProvideType(string typeName)
        {
            return this.types.First(type => type.Name == typeName);
        }

        private void GetTypes()
        {
            this.types = Assembly.GetExecutingAssembly().GetTypes();
        }
    }
}
