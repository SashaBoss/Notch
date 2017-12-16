namespace Notch.Infrastructure.Logging
{
    using System;

    /// <summary>
    /// Represents interface of Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes simple message with level
        /// </summary>
        /// <param name="message">Message to write</param>
        /// <param name="msgLevel">Message level</param>
        /// <param name="exception">Exception to write</param>
        /// <exception cref="InvalidOperationException">When write transaction failed</exception>
        void WriteMessage(string message, MessageLevel msgLevel, Exception exception = null);

        /// <summary>
        /// Writes formatted message with level
        /// </summary>
        /// <param name="msgLevel">Message level</param>
        /// <param name="msgTemplateId">Message template to write</param>
        /// <param name="exception">Exception to write</param>
        /// <param name="values">List of values to format them by template</param>
        /// <exception cref="InvalidOperationException">When write transaction failed</exception>
        /// <exception cref="ArgumentException">When values quantity does not match template input</exception>
        void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, Exception exception, params object[] values);

        /// <summary>
        /// Writes formatted message with level
        /// </summary>
        /// <param name="msgLevel">Message level</param>
        /// <param name="msgTemplateId">Message template to write</param>
        /// <param name="values">List of values to format them by template</param>
        /// <exception cref="InvalidOperationException">When write transaction failed</exception>
        /// <exception cref="ArgumentException">When values quantity does not match template input</exception>
        void WriteMessageByTemplate(MessageLevel msgLevel, string msgTemplateId, params object[] values);
    }
}
