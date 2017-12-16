namespace Notch.Infrastructure.Logging
{
    using System;
    using System.IO;
    using log4net;
    using log4net.Repository.Hierarchy;

    /// <summary>
    /// Represents instance that manages of loggers
    /// </summary>
    public sealed class LoggerSelector : ILogger, ICloneable
    {
        #region Nested members

        /// <summary>
        /// Represents stub-object of <see cref="ILogger"/> interface
        /// </summary>
        private class Log4NetLogger : ILogger
        {
            /// <summary>
            /// Logger instance.
            /// </summary>
            private readonly ILog _log;

            /// <summary>
            /// Initializes a new instance of the <see cref="Log4NetLogger"/> class.
            /// </summary>
            public Log4NetLogger()
            {
                FileInfo config = new FileInfo(Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath ?? string.Empty, "log4net.config"));
                if (config.Exists)
                {
                    log4net.Config.XmlConfigurator.Configure(config);
                }

                _log = LogManager.GetLogger("MNM.Logger");
            }

            #region ILogger Members

            /// <summary>
            /// Writes simple message with level
            /// </summary>
            /// <param name="message">Message to write</param>
            /// <param name="msgLevel">Message level</param>
            /// <param name="exception">Exception to write</param>
            /// <exception cref="InvalidOperationException">When write transaction failed</exception>
            public void WriteMessage(string message, MessageLevel msgLevel, Exception exception = null)
            {
                InitializeLoggerProperties();
                switch (msgLevel)
                {
                    case MessageLevel.Information:
                        _log.Info(message, exception);
                        break;
                    case MessageLevel.Warning:
                        _log.Warn(message, exception);
                        break;
                    case MessageLevel.Error:
                        _log.Error(message, exception);
                        break;
                    case MessageLevel.Critical:
                        _log.Fatal(message, exception);
                        break;
                    default:
                        _log.Info(message, exception);
                        break;
                }
            }

            /// <summary>
            /// Initializes logger properties.
            /// </summary>
            private void InitializeLoggerProperties()
            {
            }

            /// <summary>
            /// Writes formatted message with level
            /// </summary>
            /// <param name="msgLevel">Message level</param>
            /// <param name="msgTemplateId">Message template to write</param>
            /// <param name="exception">Exception to write</param>
            /// <param name="values">List of values to format them by template</param>
            /// <exception cref="InvalidOperationException">When write transaction failed</exception>
            /// <exception cref="ArgumentException">When values quantity does not match template input</exception>
            public void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, Exception exception, params object[] values)
            {
                this.WriteMessage(string.Format(msgTemplateId, values), msgLevel, exception);
            }

            /// <summary>
            /// Writes formatted message with level
            /// </summary>
            /// <param name="msgLevel">Message level</param>
            /// <param name="msgTemplateId">Message template to write</param>
            /// <param name="values">List of values to format them by template</param>
            /// <exception cref="InvalidOperationException">When write transaction failed</exception>
            /// <exception cref="ArgumentException">When values quantity does not match template input</exception>
            public void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, params object[] values)
            {
                this.WriteMessage(string.Format(msgTemplateId, values), msgLevel);
            }

            #endregion
        }
        #endregion

        /// <summary>
        /// Setups a new instance of <see cref="Logger"/> object to manager
        /// </summary>
        /// <param name="loggerInstance">Instance of logger object</param>
        /// <exception cref="StackOverflowException">When loggerInstance is the instance of LoggerSelector</exception>
        public void Initialize(ILogger loggerInstance)
        {
            lock (this._mutex2)
            {
                if (loggerInstance == null)
                {
                    loggerInstance = new Log4NetLogger();
                }

                if (loggerInstance.GetType().IsAssignableFrom(typeof(LoggerSelector)))
                {
                    throw new StackOverflowException("Recursive references is not allowed");
                }

                this._logger = loggerInstance;
            }
        }

        #region ILogger Members

        /// <summary>
        /// Writes simple message with level
        /// </summary>
        /// <param name="message">Message to write</param>
        /// <param name="msgLevel">Message level</param>
        /// <param name="exception">Exception to write</param>
        /// <exception cref="InvalidOperationException">When write transaction failed</exception>
        public void WriteMessage(string message, MessageLevel msgLevel, Exception exception = null)
        {
            this._logger.WriteMessage(message, msgLevel, exception);
        }

        /// <summary>
        /// Writes formatted message with level
        /// </summary>
        /// <param name="msgLevel">Message level</param>
        /// <param name="msgTemplateId">Message template to write</param>
        /// <param name="exception">Exception to write</param>
        /// <param name="values">List of values to format them by template</param>
        /// <exception cref="InvalidOperationException">When write transaction failed</exception>
        /// <exception cref="ArgumentException">When values quantity does not match template input</exception>
        public void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, Exception exception, params object[] values)
        {
            this._logger.WriteMessageByTemplate(msgLevel, msgTemplateId, exception, values);
        }


        /// <summary>
        /// Writes formatted message with level
        /// </summary>
        /// <param name="msgLevel">Message level</param>
        /// <param name="msgTemplateId">Message template to write</param>
        /// <param name="values">List of values to format them by template</param>
        /// <exception cref="InvalidOperationException">When write transaction failed</exception>
        /// <exception cref="ArgumentException">When values quantity does not match template input</exception>
        public void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, params object[] values)
        {
            this._logger.WriteMessageByTemplate(msgLevel, msgTemplateId, values);
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a new copy of current instance of LogManager
        /// </summary>
        /// <returns>Instance of cloned object</returns>
        public object Clone()
        {
            var manager = new LoggerSelector()
            {
                _logger = this._logger
            };

            return manager;
        }

        #endregion

        #region Static members

        /// <summary>
        /// Gets instance of LogManager <see cref="LoggerSelector"/> class
        /// </summary>
        public static LoggerSelector Instance
        {
            get
            {
                lock (Mutex)
                {
                    if (logManager == null)
                    {
                        logManager = new LoggerSelector();
                        logManager.Initialize(null);
                    }
                }

                return logManager;
            }
        }

        /// <summary>
        /// Stores a sync object for static logic
        /// </summary>
        private static readonly object Mutex = new object();

        /// <summary>
        /// Stores a persistent entity of <see cref="LoggerSelector"/> object
        /// </summary>
        private static LoggerSelector logManager = default(LoggerSelector);
        #endregion

        /// <summary>
        /// Stores a sync object for class logic
        /// </summary>
        private readonly object _mutex2 = new object();

        /// <summary>
        /// Stores an instance of current logger
        /// </summary>
        private ILogger _logger = null;
    }
}
