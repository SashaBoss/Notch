namespace Notch.Infrastructure.Data
{
    using System;
    using System.Transactions;
    using Logging;
    using Request;

    public abstract class DataContextBase : IDataContext
    {
        protected DataContextBase(string conString, bool escalateException)
        {
            this._escalateException = escalateException;

            if (escalateException)
            {
                this._escalationLevel = MessageLevel.Warning;
            }

            this.DbConnection = conString;
        }

        #region IDataContext Members

        /// <summary>
        /// Gets a database connection string
        /// </summary>
        public string DbConnection { get; protected set; }

        /// <summary>
        /// Gets instance of Logger
        /// </summary>
        public ILogger Logger { get { return this._loggergerSelector; } }

        /// <summary>
        /// Gets or sets instance of repository container
        /// </summary>
        public IRepositoryProvider RepositoryContainer { get; set; }

        /// <summary>
        ///  Provides UoW mechanism
        /// </summary>
        /// <param name="context"></param>
        /// <param name="forceSuppresTransaction"></param>
        /// <param name="action">Handler that should be routed by transaction</param>
        /// <returns></returns>
        public virtual void TransactedFlow(Action<IRequestContext> action, IRequestContext context, bool forceSuppresTransaction)
        {
            try
            {
                var scopeOption = forceSuppresTransaction ? TransactionScopeOption.Suppress : TransactionScopeOption.Required;
                using (var tran = new TransactionScope(scopeOption))
                {
                    action(context);
                    this.Flush();
                    tran.Complete();
                }
            }
            catch (Exception err)
            {
                this._loggergerSelector.WriteMessage(err.Message, this._escalationLevel, err);
                if (this._escalateException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Saves all unsaved data into context
        /// </summary>
        /// <remarks>
        /// <see cref="TransactedFlow"/> calls this method before complete
        /// </remarks>
        public abstract void Flush();
        #endregion

        #region IDisposable Members

        public abstract void Dispose();

        #endregion

        private readonly bool _escalateException = false;
        private readonly MessageLevel _escalationLevel = MessageLevel.Error;
        private readonly LoggerSelector _loggergerSelector = LoggerSelector.Instance;
    }
}
