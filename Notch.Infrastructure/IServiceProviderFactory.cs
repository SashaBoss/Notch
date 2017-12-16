namespace Notch.Infrastructure
{
    using System;

    /// <summary>
    /// Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.
    /// </summary>
    public interface IServiceProviderFactory : IServiceProvider
    {
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="TService">An object that specifies the type of service object to get</typeparam>
        /// <param name="constructParams">List of construction arguments</param>
        /// <returns>A service object of type serviceType.-or- null if there is no service object	of type serviceType.</returns>
        TService GetService<TService>(params object[] constructParams);

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="TService">An object that specifies the type of service object to get.</typeparam>
        /// <param name="name">Mapping name for the IoC resolver.</param>
        /// <param name="param">List of construction arguments</param>
        /// <returns>A service object of type serviceType.-or- null if there is no service object of type serviceType.</returns>
        TService GetMappingService<TService>(string name, params object[] param);

        /// <summary>
        /// Return instance of service.
        /// </summary>
        /// <param name="serviceType">Type of service.</param>
        /// <param name="constructParams">Params.</param>
        /// <returns></returns>
        object GetService(Type serviceType, params object[] constructParams);
    }
}