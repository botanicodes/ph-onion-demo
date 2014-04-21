namespace Core.Common.Extensions
{
    using Core.Services.Conversion;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Get a value from the collection and convert the value to the type specified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="key"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static T GetValue<T>(this NameValueCollection collection, string key, IStringConverter converter)
        {
            string strValue = collection[key];
            if (!String.IsNullOrEmpty(strValue))
            {
                return converter.Convert<T>(strValue);
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Get a value from the collection and convert the value to the type specified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<T>(this NameValueCollection collection, string key)
        {
            return collection.GetValue<T>(key, new StringConverter());
        }
    }
}
