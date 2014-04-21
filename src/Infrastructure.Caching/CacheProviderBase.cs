
//-----------------------------------------------------------------------
// <copyright file="CacheProviderBase.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  
namespace PriorityHealth.Infrastructure.Caching
{
    using PriorityHealth.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Base class for implementing a cache provider
    /// </summary>
    /// <typeparam name="TCache"></typeparam>
    public abstract class CacheProviderBase<TCache> : ICacheProvider
    {
        public const int DefaultCacheDurationInMinutes = 60;

        /// <summary>
        /// Duration in which cached values will be available
        /// </summary>
        public int CacheDuration
        {
            get;
            set;
        }        
        /// <summary>
        /// Cache object used to store values
        /// </summary>
        protected TCache Cache {get; set; }

        #region CTOR
        public CacheProviderBase()
        {
            CacheDuration = DefaultCacheDurationInMinutes;
            Cache = InitCache();
        }
        public CacheProviderBase(int durationInMinutes)
        {
            CacheDuration = durationInMinutes;
            Cache = InitCache();
        }
        #endregion

        #region Abstract Methods
        protected abstract TCache InitCache();
        public abstract T Get<T>(string key);
        public abstract void Set<T>(string key, T value);
        public abstract void Set<T>(string key, T value, int duration);
        public abstract void Remove(string key);
        public abstract bool Contains(string key);
        public abstract IEnumerable<KeyValuePair<string, object>> GetAll();
        #endregion
        

    }
}
