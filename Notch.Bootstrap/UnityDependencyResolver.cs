using Notch.Data.Dapper;
using Unity;

namespace Notch.Bootstrap
{
    using Infrastructure;
    using Infrastructure.Data;
    using Infrastructure.Logging;

    public class UnityDependencyResolver
    {
        private static IUnityContainer _container;

        public static void RegisterTypes(IUnityContainer container)
        {
            _container = container;
            _container.RegisterType<IDataContext, DapperContext>();
            _container.RegisterType<ILogger, LoggerSelector>();
            _container.RegisterInstance<IEntityService>(new ValueConverter());
            //_container.RegisterInstance<IDeployment>(new WinAnyCPUEmbeddedDeployment(new TempFolderDeployment()));
            //_container.RegisterInstance<IConverter>(new ThreadSafeConverter(new RemotingToolset<PdfToolset>(UnityDependencyResolver._container.Resolve<IDeployment>())));
            RegisterDataModels();
            RegisterBusinessModels();
        }

        private static void RegisterBusinessModels()
        {
        }

        private static void RegisterDataModels()
        {
        }
    }
}
