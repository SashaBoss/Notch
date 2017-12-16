namespace Notch.Bootstrap
{
    using Infrastructure;
    using Infrastructure.Data;
    using Infrastructure.Logging;
    using Notch.Business;
    using Notch.Data.Dapper;
    using Notch.Data.Dapper.Repositories;
    using Notch.Infrastructure.Business;
    using Unity;


    public class UnityDependencyResolver
    {
        private static IUnityContainer _container;

        public static void RegisterTypes(IUnityContainer container)
        {
            _container = container;
            _container.RegisterType<IDataContext, DapperContext>();
            _container.RegisterType<ILogger, LoggerSelector>();
            _container.RegisterInstance<IEntityService>(new ValueConverter());
            RegisterDataModels();
            RegisterBusinessModels();
        }

        private static void RegisterBusinessModels()
        {
            _container.RegisterType<ITrackDM, TrackDM>();
        }

        private static void RegisterDataModels()
        {
            _container.RegisterType<ITrackRepository, TrackRepository>();
        }
    }
}
