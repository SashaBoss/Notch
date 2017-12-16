namespace Notch.Infrastructure.Business
{
    using System;
    using Data;

    public interface IBusinessContext : IDisposable
    {
        IDataContext DataContext { get ; }

        IServiceProviderFactory Factory { get ; }
    }
}