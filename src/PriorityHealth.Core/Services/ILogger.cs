//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  

namespace Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Definition of a logger within the application
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);
        /// <summary>
        /// Log a formatted debug message
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="messageArgs"></param>
        void Debug(string messageFormat, params object[] messageArgs);

        /// <summary>
        /// Log an info message
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);
        /// <summary>
        /// Log a formatted info message
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="messageArgs"></param>
        void Info(string messageFormat, params object[] messageArgs);

        /// <summary>
        /// Log a warning message
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);
        /// <summary>
        /// Log a formatted warning message
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="messageArgs"></param>
        void Warn(string messageFormat, params object[] messageArgs);

        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);
        /// <summary>
        /// Log a formatted error message
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="messageArgs"></param>
        void Error(string messageFormat, params object[] messageArgs);
        /// <summary>
        /// Log an error message with an exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        void Error(string message, Exception ex);

        /// <summary>
        /// Log a fatal message
        /// </summary>
        /// <param name="message"></param>
        void Fatal(string message);

        /// <summary>
        /// Log a formatted fatal message
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="messageArgs"></param>
        void Fatal(string messageFormat, params object[] messageArgs);

        /// <summary>
        /// Log a fatal message with the associated exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        void Fatal(string message, Exception ex);
    }
}
