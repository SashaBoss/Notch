using Dapper.Contrib.Extensions;

namespace Notch.Data.Dapper.Resolvers
{
    using System;
    using Dommel;

    public class TableNameResolver : DommelMapper.ITableNameResolver
    {
        public string ResolveTableName(Type type)
        {
            var tableAttribute = Attribute.GetCustomAttribute(type, typeof(TableAttribute));
            return tableAttribute != null ? ((TableAttribute)tableAttribute).Name : null;
        }
    }
}