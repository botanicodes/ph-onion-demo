//-----------------------------------------------------------------------
// <copyright file="IObjectStore.cs" company="Spectrum Health">
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

    public interface IObjectStore
    {
        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <param name="value">Cached value. Default(T) if
        /// item doesn't exist.</param>
        /// <returns>Cached item as type</returns>
        T Get<T>(string key);

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="value">Item to be cached</param>
        /// <param name="key">Name of item</param>
        void Set<T>(string key, T value);

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs WITH a cache duration set in minutes
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Item to be cached</param>
        /// <param name="value">Name of item</param>
        /// <param name="duration">Cache duration in minutes</param>
        void Set<T>(string key, T value, int duration);

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>        
        void Remove(string key);

        /// <summary>
        /// Does the cache contain a value for the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(string key);

        /// <summary>
        /// Get all values in the cache
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, object>> GetAll();

    }
}
