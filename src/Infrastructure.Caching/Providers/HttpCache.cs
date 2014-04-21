//-----------------------------------------------------------------------
// <copyright file="HttpCache.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  

namespace PriorityHealth.Infrastructure.Caching.Providers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Caching;

    /// <summary>
    /// HttpRuntime cache implementation of ICacheProvider
    /// </summary>
    public class HttpCache : CacheProviderBase<Cache>
    {
        protected override Cache InitCache()
        {
            return HttpRuntime.Cache;
        }

        public override T Get<T>(string key)
        {
            try
            {
                if (Cache[key] == null)
                {
                    return default(T);                    
                }

                return (T)Cache[key];
            }
            catch
            {
                return default(T);                
            }            
        }

        public override void Set<T>(string key, T value)
        {
            Set<T>(key, value, CacheDuration);
        }

        public override void Set<T>(string key, T value, int duration)
        {
            Cache.Insert(
                key,
                value,
                null,
                DateTime.Now.AddMinutes(duration),
                TimeSpan.Zero);
        }

        public override void Remove(string key)
        {
            Cache.Remove(key);
        }

        public override bool Contains(string key)
        {
            return Cache[key] != null;
        }

        public override IEnumerable<KeyValuePair<string, object>> GetAll()
        {
            foreach (DictionaryEntry item in Cache)
            {
                yield return new KeyValuePair<string, object>(item.Key as string, item.Value);
            }

        }
    }
}
