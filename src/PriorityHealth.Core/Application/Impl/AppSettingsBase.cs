//-----------------------------------------------------------------------
// <copyright file="AppSettingsBase.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------	  
	  
namespace Core.Application
{
    using System;
    using System.Configuration;
    using Core.Common.Extensions;

    public abstract class AppSettingsBase : IAppSettings
    {

        /// <summary>
        /// Get a converted value of a configuration value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual T Get<T>(string name)
        {
            return Get<T>(name, default(T));
        }

        /// <summary>
        /// Get a converted value of a configuration value or a default value if configuration value fails or isn't set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public virtual T Get<T>(string name, T defaultValue)
        {
            T value = ConfigurationManager.AppSettings.GetValue<T>(name);
            if (null == value)
                return defaultValue;
            else
                return value;
        }

        /// <summary>
        /// Get the string value of a configuration value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual string Get(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
