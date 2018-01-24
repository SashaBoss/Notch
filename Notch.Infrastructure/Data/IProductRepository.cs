namespace Notch.Infrastructure.Data
{
    using Notch.Data.Dapper.Entity;
    using Notch.Infrastructure.Data.Common;

    public interface IProductRepository : IRepository<ProductEM, int>
    {
    }
}