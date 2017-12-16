using Unity;

namespace Notch.Bootstrap
{
    using System;
    using Microsoft.Practices.Unity;
    using Notch.Infrastructure;
    using Notch.Infrastructure.Request;

    public class UnitySetup
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            IUnityContainer container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static void RegisterTypes(IUnityContainer container)
        {
            UnityDependencyResolver.RegisterTypes(container);
        }

        public static IUnityContainer GetUnityConfig()
        {
            return Container.Value;
        }

        public static IServiceProviderFactory CreateFactory(IRequestContext context)
        {
            return new ServiceProviderFactory(Container.Value, context);
        }
    }
}
