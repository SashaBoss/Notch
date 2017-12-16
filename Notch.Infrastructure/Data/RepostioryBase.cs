namespace Notch.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    public abstract class RepostioryBase<TEntity, TKey> : IRepository<TEntity, TKey>, IDisposable
        where TEntity : class
    {
        /// <summary>
        /// Constant for separate errors.
        /// </summary>
        private const string ErrorMessageSeparator = ";";

        /// <summary>
        /// Error messages separator.
        /// </summary>
        private const string ErrorMessagesSeparator = "\r\n";

        protected RepostioryBase(IDataContext context)
        {
            this.CurrentContext = context;
        }

        public IDataContext CurrentContext
        {
            get;
            private set;
        }

        public abstract TEntity Get(TKey id);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract void Delete(TKey id);

        public abstract long Insert(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract IEnumerable<TEntity> SearchQuery(string sql, Dictionary<string, object> parameters, out int totalCount, int pageNumber, int pageSize, string sortColumn, string sortOrder);

        public abstract IEnumerable<TEntity> ExecuteSP(string spName, object parameters);

        public abstract IEnumerable<TOut> ExecuteSP<TOut>(string spName, object parameters);

        public abstract IEnumerable<TOut> ExecuteSP<TOut>(string spName, object parameters, IDbTransaction transaction, bool buffered, int? commandTimeout);

        public abstract IEnumerable<TEntity> ExecuteQuery(string queryString, object parameters);

        public abstract IEnumerable<TOut> ExecuteQuery<TOut>(string queryString, object parameters);      

        public abstract TAggregate ExecuteAggregateQuery<TAggregate>(string queryString, object parameters);

        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public abstract void Dispose();
    }
}
