//-----------------------------------------------------------------------
// <copyright file="IStringConverter.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------	  	  
namespace Core.Services.Conversion
{
    public interface IStringConverter
    {
        /// <summary>
        /// Convert string value to generic type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <returns></returns>
        T Convert<T>(string value);
        /// <summary>
        /// Convert string value to generic type and return default value if null or error occurs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T Convert<T>(string value, T defaultValue);
    }
}
