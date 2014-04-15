
//-----------------------------------------------------------------------
// <copyright file="IAppSettings.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
namespace PriorityHealth.Core.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes generic container for application settings
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Get a converted value of a configuration value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T Get<T>(string name);
        /// <summary>
        /// Get a converted value of a configuration value or a default value if configuration value fails or isn't set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T Get<T>(string name, T defaultValue);
        /// <summary>
        /// Get the string value of a configuration value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string Get(string name);
    }
}
