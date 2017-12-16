using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Notch.Data.Dapper
{
    using System;
    using Dommel;
    using Infrastructure.Data;
    using Resolvers;

    public class DapperContext : DataContextBase
    {
        public DapperContext(string conString) : base(conString, true)
        {
            this.InitializeEntityMappings();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override void Flush()
        {
        }

        private void InitializeEntityMappings()
        {
            FluentMapper.Initialize(config =>
            {
                config.ForDommel();
                DommelMapper.SetKeyPropertyResolver(new PrimaryKeyResolver());
                DommelMapper.SetTableNameResolver(new TableNameResolver());
            });
        }
    }
}