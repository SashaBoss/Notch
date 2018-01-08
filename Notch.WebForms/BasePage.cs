using System.Web.UI;
using Notch.Infrastructure;
using Notch.Infrastructure.Request;

namespace Notch.WebForms
{
    public class BasePage : Page
    {
        private readonly object _mutex = new object();

        private IServiceProviderFactory _modelFactory = default(IServiceProviderFactory);

        private DefaultContext _context = default(DefaultContext);

        private string _cachedContextId = string.Empty;

        protected IServiceProviderFactory Factory
        {
            get
            {
                lock (this._mutex)
                {
                    if (this._modelFactory == null || this._cachedContextId != this.RequestContext.Id)
                    {
                        this._cachedContextId = this.RequestContext.Id;
                        this._modelFactory = this.RequestContext.Factory;
                    }

                    return this._modelFactory;
                }
            }
        }

        public IRequestContext RequestContext
        {
            get
            {
                lock (this._mutex)
                {
                    if (this._context == null)
                    {
                        this._context = new DefaultContext();
                    }
                }

                return this._context;
            }
        }
    }
}