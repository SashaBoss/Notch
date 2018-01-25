using System.Web.Mvc;
using Notch.Infrastructure.Business;

namespace Notch.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            using (var productDm = Factory.GetService<IProductDM>(RequestContext))
            {
                var products = productDm.GetAll();

                return View(products);
            }
        }
    }
}