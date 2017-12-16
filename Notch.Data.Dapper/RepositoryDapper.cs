using Dapper;

namespace Notch.Data.Dapper
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Dommel;
    using Notch.Infrastructure.Data;

    public class RepositoryDapper<TEntity, TKey> : RepostioryBase<TEntity, TKey> where TEntity : class
    {
        private bool _isDisposed = false;
        private readonly bool _isInjected = false;

        public RepositoryDapper(IDataContext context) : base(context)
        {
            this._isInjected = true;
        }

        public override IEnumerable<TEntity> GetAll()
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                return db.GetAll<TEntity>();
            }
        }

        public override TEntity Get(TKey id)
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                return db.Get<TEntity>(id);
            }
        }

        public override void Delete(TKey id)
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var entity = db.Get<TEntity>(id);
                db.Delete<TEntity>(entity);
            }
        }

        public override long Insert(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var result = db.Insert<TEntity>(entity);
                return result != null ? long.Parse(result.ToString()) : default(long);
            }
        }

        public override void Update(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                db.Update<TEntity>(entity);
            }
        }

        public override IEnumerable<TEntity> SearchQuery(string sql, Dictionary<string, object> parameters, out int totalCount, int pageNumber, int pageSize, string sortColumn, string sortOrder = "ASC")
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var command =
                    $@"SELECT * FROM ({sql}) as res ORDER BY {sortColumn} {sortOrder
                        } OFFSET @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY ; ";
                var totalCountSql = $"SELECT count(*) AS TotalCount FROM ({sql}) as res;";

                var queryArgs = this.ConvertToDynamicParams(parameters);

                queryArgs.Add("PageNumber", pageNumber, DbType.Int32, ParameterDirection.Input);
                queryArgs.Add("PageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                using (var result = db.QueryMultiple(command + totalCountSql, queryArgs))
                {
                    var entitys = result.Read<TEntity>();
                    totalCount = result.Read<int>().Single();

                    return entitys;
                }
            }
        }

        public override IEnumerable<TEntity> ExecuteSP(string spName, object paramModel)
        {
            var queryArgs = ParameterBuilder.BuildParametersFromModel(paramModel);
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                return db.Query<TEntity>(spName, queryArgs, null, true, null, CommandType.StoredProcedure);
            }
        }

        public override IEnumerable<TOut> ExecuteSP<TOut>(string spName, object paramModel)
        {
            var queryArgs = ParameterBuilder.BuildParametersFromModel(paramModel);
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                return db.Query<TOut>(spName, queryArgs, null, true, null, CommandType.StoredProcedure);
            }
        }

        public override IEnumerable<TOut> ExecuteSP<TOut>(string spName, object paramModel, IDbTransaction transaction, bool buffered, int? commandTimeout)
        {
            var queryArgs = ParameterBuilder.BuildParametersFromModel(paramModel);
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                return db.Query<TOut>(spName, queryArgs, transaction, buffered, commandTimeout, CommandType.StoredProcedure);
            }
        }

        public override IEnumerable<TEntity> ExecuteQuery(string queryString, object parameters)
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var queryArgs = ParameterBuilder.BuildParametersFromModel(parameters);
                return db.Query<TEntity>(queryString, queryArgs);
            }
        }

        public override IEnumerable<TOut> ExecuteQuery<TOut>(string queryString, object parameters)
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var queryArgs = ParameterBuilder.BuildParametersFromModel(parameters);
                return db.Query<TOut>(queryString, queryArgs);
            }
        }

        public override TAggregate ExecuteAggregateQuery<TAggregate>(string queryString, object parameters)
        {
            using (IDbConnection db = new SqlConnection(base.CurrentContext.DbConnection))
            {
                var queryArgs = ParameterBuilder.BuildParametersFromModel(parameters);
                return db.Query<TAggregate>(queryString, queryArgs).FirstOrDefault();
            }
        }

        private DynamicParameters ConvertToDynamicParams(Dictionary<string, object> parameters)
        {
            var queryArgs = new DynamicParameters();
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    queryArgs.Add(item.Key, item.Value);
                }
            }

            return queryArgs;
        }

        #region IDisposable Members

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        ~RepositoryDapper()
        {
            Dispose(false);
        }

        private void Dispose(bool disposeManaged)
        {
            if (this._isDisposed)
            {
                return;
            }

            if (!this._isInjected && disposeManaged && this.CurrentContext != null)
            {
                this.CurrentContext.Dispose();
            }

            this._isDisposed = true;
        }


        #endregion
    }
}
