
//-----------------------------------------------------------------------
// <copyright file="Log4NetLogger.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  
namespace PriorityHealth.Logging.Impl
{
    using log4net;
    using PriorityHealth.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Logging implementation using Log4Net
    /// </summary>
    public class Log4NetLogger : ILogger
    {         
         private static readonly ILog StaticLog = LogManager.GetLogger(typeof(Log4NetLogger));

        /// <summary>
        /// Instance of log4net logger
        /// </summary>
        protected ILog Log { get; set; }

        public Log4NetLogger()
        {
            Log = StaticLog ?? LogManager.GetLogger(typeof(Log4NetLogger));            
        }

        #region ILogger

        #endregion
        /// <inheritdoc/>
        public void Debug(string message)
        {
            Log.Debug(message);
        }

        /// <inheritdoc/>
        public void Debug(string messageFormat, params object[] messageArgs)
        {
            Log.DebugFormat(messageFormat, messageArgs);
        }

        /// <inheritdoc/>
        public void Info(string message)
        {
            Log.Info(message);
        }

        /// <inheritdoc/>
        public void Info(string messageFormat, params object[] messageArgs)
        {
            Log.InfoFormat(messageFormat, messageArgs);
        }

        /// <inheritdoc/>
        public void Warn(string message)
        {
            Log.Warn(message);
        }

        /// <inheritdoc/>
        public void Warn(string messageFormat, params object[] messageArgs)
        {
            Log.WarnFormat(messageFormat, messageArgs);
        }

        /// <inheritdoc/>
        public void Error(string message)
        {
            Log.Error(message);
        }

        /// <inheritdoc/>
        public void Error(string messageFormat, params object[] messageArgs)
        {
            Log.ErrorFormat(messageFormat, messageArgs);
        }

        /// <inheritdoc/>
        public void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        /// <inheritdoc/>
        public void Fatal(string message)
        {
            Log.Fatal(message);
        }

        /// <inheritdoc/>
        public void Fatal(string messageFormat, params object[] messageArgs)
        {
            Log.FatalFormat(messageFormat, messageArgs);
        }

        /// <inheritdoc/>
        public void Fatal(string message, Exception ex)
        {
            Log.Fatal(message, ex);
        }
    }
}
