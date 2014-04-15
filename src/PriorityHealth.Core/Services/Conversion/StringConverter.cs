//-----------------------------------------------------------------------
// <copyright file="StringConverter.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------	  	  

namespace PriorityHealth.Core.Services.Conversion
{
    using System;
    using System.ComponentModel;

    public class StringConverter : IStringConverter
    {
        /// <summary>
        /// Convert string value to generic type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public T Convert<T>(string strValue)
        {
            return Convert(strValue, default(T));
        }

        /// <summary>
        /// Convert string value to generic type and return default value if null or error occurs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T Convert<T>(string strValue, T defaultValue)
        {
            T value = defaultValue;
            Type type = typeof(T);
            if (!String.IsNullOrEmpty(strValue))
            {
                try
                {
                    if (type.IsEnum)
                    {
                        value = (T)Enum.Parse(type, strValue);
                    }
                    else
                    {
                        var converter = TypeDescriptor.GetConverter(type);
                        value = (T)converter.ConvertFromString(strValue);
                    }

                }
                catch
                {
                    //if error return default(T)         
                }
            }
            return value;
        }
    }
}
