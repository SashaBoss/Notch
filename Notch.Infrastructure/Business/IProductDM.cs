namespace Notch.Infrastructure.Business
{
    using System;
    using System.Collections.Generic;
    using Notch.Domain;

    public interface IProductDM : IDisposable
    {
        IList<Product> GetAll();
    }
}