namespace Notch.Context
{
    using System;
    using System.Configuration;
    using System.Security.Principal;
    using System.Web;
    using Notch.Bootstrap;
    using Notch.Infrastructure;
    using Notch.Infrastructure.Data;
    using Notch.Infrastructure.Logging;
    using Notch.Infrastructure.Request;

    internal class DefaultContext : HttpContextBase, IRequestContext
    {
        private readonly ILogger _logger = LoggerSelector.Instance;
        private readonly GenericPrincipal _prinipical;
        private const string ConnectionKey = "ConnKey";
        private const string EncryptKey = "EncryptKey";

        public DefaultContext(GenericPrincipal prinipical, HttpContextBase requestContext)
            : base()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionKey].ToString();
            var encryptKey = ConfigurationManager.AppSettings[EncryptKey];
            this._prinipical = prinipical;
            this.Factory = UnitySetup.CreateFactory(this);
            this.DataContext = this.Factory.GetService<IDataContext>(connectionString);
            this.Logger = LoggerSelector.Instance;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #region IRequestContext members
        public string Id
        {
            get
            {
                if (this._prinipical == null || this._prinipical.Identity == null)
                {
                    return string.Empty;
                }

                return this._prinipical.Identity.Name;
            }
        }

        public IDataContext DataContext { get; private set; }

        public ILogger Logger { get; private set; }

        public IServiceProviderFactory Factory { get; private set; }

        public IPrincipal Principal
        {
            get
            {
                return this._prinipical;
            }
        }
        #endregion
    }
}