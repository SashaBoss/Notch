﻿namespace Notch.Infrastructure.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    public interface IRepository<TEntity, in TKey> : IDisposable
        where TEntity : class
    {
        IDataContext CurrentContext { get; }

        [TransactionFlow(TransactionFlowOption.Allowed)]
        IEnumerable<TEntity> GetAll();

        [TransactionFlow(TransactionFlowOption.Allowed)]
        TEntity Get(TKey id);

        [TransactionFlow(TransactionFlowOption.Allowed)]
        long Insert(TEntity entity);

        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Update(TEntity entity);

        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Delete(TKey id);

        IEnumerable<TEntity> SearchQuery(string sql, Dictionary<string, object> parameters, out int totalCount, int pageNumber, int pageSize, string sortColumn, string sortOrder);

        IEnumerable<TEntity> ExecuteSP(string spName, object parameters);

        IEnumerable<TEntity> ExecuteQuery(string queryString, object parameters);
    }
}