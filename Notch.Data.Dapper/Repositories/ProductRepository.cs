using Notch.Data.Dapper.Entity;
using Notch.Infrastructure.Data;

namespace Notch.Data.Dapper.Repositories
{
    public class ProductRepository : RepositoryDapper<ProductEM, int>, IProductRepository
    {
        public ProductRepository(IDataContext context) : base(context)
        {
        }
    }
}