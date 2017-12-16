using Dapper.Contrib.Extensions;

namespace Notch.Data.Dapper.Resolvers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Dommel;

    public class PrimaryKeyResolver : DommelMapper.IKeyPropertyResolver
    {
        public PropertyInfo ResolveKeyProperty(Type type)
        {
            return type.GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)) || Attribute.IsDefined(prop, typeof(ExplicitKeyAttribute)));
        }

        public PropertyInfo ResolveKeyProperty(Type type, out bool isIdentity)
        {
            isIdentity = true;
            var property = type.GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));
            if (property == null)
            {
                isIdentity = false;
                property = type.GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(ExplicitKeyAttribute)));
            }
            return property;
        }
    }
}