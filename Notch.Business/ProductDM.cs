namespace Notch.Business
{
    using System.Collections.Generic;
    using Notch.Domain;
    using Notch.Infrastructure.Business;
    using Notch.Infrastructure.Request;

    public class ProductDM : BusinessContextBase, IProductDM
    {
        public ProductDM(IRequestContext requestContext) : base(requestContext)
        {
        }


        public IList<Product> GetAll()
        {
            using (var repo = Factory.GetService<IProductDM>(DataContext))
            {
                var productsEm = repo.GetAll();

                return EntService.ConvertTo(productsEm, default(IList<Product>));
            }
        }
    }
}