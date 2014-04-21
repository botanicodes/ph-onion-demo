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

    public abstract class AppSettingsBase : IAppSettings
    {
        private Services.Conversion.IStringConverter _converter;

        /// <summary>
        /// Used to convert string values into other data types
        /// </summary>
        public Services.Conversion.IStringConverter Converter
        {
            get
            {
                return _converter ?? (_converter = new Services.Conversion.StringConverter());
            }
        }

        /// <summary>
        /// Get a converted value of a configuration value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Get<T>(string name)
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
        public T Get<T>(string name, T defaultValue)
        {
            var strValue = Get(name);
            if (!String.IsNullOrEmpty(strValue))
            {
                return Converter.Convert<T>(strValue);
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Get the string value of a configuration value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Get(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
