namespace Notch.Infrastructure.Business
{
    using System;
    using Data;
    using Request;

    /// <summary>
    /// Represents a bridge base class of all business models.
    /// </summary>
    public abstract class BusinessContextBase : IBusinessContext
    {
        private readonly IDataContext _dataContext = default(IDataContext);
        protected readonly IRequestContext Context;
        protected readonly IEntityService EntService;

        /// <summary>
        /// Initializes a new instance of <see cref="BusinessContextBase"/> class from existed request data context
        /// </summary>
        /// <param name="requestContext"></param>
        protected BusinessContextBase(IRequestContext requestContext)
        {
            if (requestContext != null)
            {
                this._dataContext = requestContext.DataContext;
            }

            this.Context = requestContext;
            this.EntService = this.Context?.Factory.GetService<IEntityService>();
        }

        public IDataContext DataContext { get { return this._dataContext; } }

        public IServiceProviderFactory Factory { get { return this.Context.Factory; } }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}