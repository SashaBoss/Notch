namespace Notch.Infrastructure.Request
{
    using Notch.Infrastructure.Data;
    using System;
    using System.Security.Principal;
    using Notch.Infrastructure.Logging;

    /// <summary>
    /// Represents object provides access to current operation context
    /// </summary>
    public interface IRequestContext : IDisposable
    {
        /// <summary>
        /// Gets an identified of current context
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets a Principal of current context
        /// </summary>
        IPrincipal Principal { get; }
        /// <summary>
        /// Gets instance of ORM entity
        /// </summary>
        IDataContext DataContext { get; }

        /// <summary>
        /// Gets an instance of current logger
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// Gets an instance of domain model /repository factory
        /// </summary>
        IServiceProviderFactory Factory { get; }
    }
}