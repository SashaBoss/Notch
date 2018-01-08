namespace Notch.WebForms
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

    public class DefaultContext : HttpContextBase, IRequestContext
    {
        private readonly ILogger _logger = LoggerSelector.Instance;
        private const string ConnectionKey = "NotchConnection";

        public DefaultContext()
            : base()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionKey].ToString();
            this.Factory = UnitySetup.CreateFactory(this);
            this.DataContext = this.Factory.GetService<IDataContext>(connectionString);
            this.Logger = LoggerSelector.Instance;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string Id { get; }
        public IPrincipal Principal { get; }
        public IDataContext DataContext { get; private set; }

        public ILogger Logger { get; private set; }

        public IServiceProviderFactory Factory { get; private set; }
    }
}