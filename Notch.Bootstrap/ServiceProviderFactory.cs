namespace Notch.Bootstrap
{
    using System;
    using Notch.Infrastructure;
    using Notch.Infrastructure.Business;
    using Notch.Infrastructure.Request;
    using Unity;

    /// <summary>
    /// Represents implementation of service locator
    /// </summary>
    internal sealed class ServiceProviderFactory : IServiceProviderFactory, IDisposable
    {
        #region Private declarations

        /// <summary>
        /// Stores an instance of data context factory
        /// </summary>
        private readonly IRequestContext _requestContext;

        /// <summary>
        /// Stores cached value of dataContext factory
        /// </summary>
        private readonly ServiceProviderParametersResolver _defaultResolver;

        /// <summary>
        /// Stores static instance of builder
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Stores a cached instance type metadata
        /// </summary>
        private static readonly Type TypedTrigger = typeof(IBusinessContext);

        #endregion

        /// <summary>
        /// Initializes a new instance of <see cref="ServiceProviderFactory"/> class
        /// </summary>
        /// <param name="container">Instance of container</param>
        /// <param name="requestContext">Current user context</param>
        public ServiceProviderFactory(IUnityContainer container, IRequestContext requestContext)
        {
            this._container = container;
            this._requestContext = requestContext;
            this._defaultResolver = new ServiceProviderParametersResolver(requestContext, null);
        }

        #region IServiceProvider Members

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns> A service object of type serviceType.-or- null if there is no service object of type serviceType.</returns>
        public object GetService(Type serviceType)
        {
            return this._container.Resolve(serviceType, new ServiceProviderParametersResolver(this._requestContext, null, this.isSelectedType(serviceType)));
        }

        #endregion

        #region Custom IServiceProvider Members

        public object GetService(Type serviceType, params object[] constructParams)
        {
            return this._container.Resolve(serviceType, new ServiceProviderParametersResolver(this._requestContext, constructParams, this.isSelectedType(serviceType)));
        }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="TServiceType">An object that specifies the type of service object to get.</typeparam>
        /// <returns> A service object of type serviceType.-or- null if there is no service object of type serviceType.</returns>
        public TServiceType GetService<TServiceType>()
        {
            return (TServiceType)this.GetService(typeof(TServiceType));
        }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="TService">An object that specifies the type of service object to get.</typeparam>
        /// <param name="constructParams">List of construction arguments</param>
        /// <returns>A service object of type serviceType.-or- null if there is no service object of type serviceType.</returns>
        public TService GetService<TService>(params object[] constructParams)
        {
            return this._container.Resolve<TService>(new ServiceProviderParametersResolver(this._requestContext, constructParams, this.isSelectedType(typeof(TService))));
        }

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="TService">An object that specifies the type of service object to get.</typeparam>
        /// <param name="name">Mapping name for the IoC resolver.</param>
        /// <param name="param">List of construction arguments</param>
        /// <returns>A service object of type serviceType.-or- null if there is no service object of type serviceType.</returns>
        public TService GetMappingService<TService>(string name, params object[] param)
        {
            return this._container.Resolve<TService>(name, new ServiceProviderParametersResolver(this._requestContext, param, this.isSelectedType(typeof(TService))));
        }

        #endregion Custom IServiceProvider Members

        private bool isSelectedType(Type serviceType)
        {
            if (serviceType == null)
            {
                return false;
            }

            if (TypedTrigger.IsAssignableFrom(serviceType))
            {
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposeManaged)
        {
            //TODO: Add release code here
        }

        ~ServiceProviderFactory()
        {
            this.Dispose(false);
        }
    }
}