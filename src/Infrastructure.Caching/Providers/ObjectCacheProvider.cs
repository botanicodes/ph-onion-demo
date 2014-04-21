//-----------------------------------------------------------------------
// <copyright file="ObjectCacheProvider.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------


namespace Infrastructure.Caching.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Text;

    /// <summary>
    /// Base ObjectCache implementation of ICacheProvider
    /// </summary>
    /// <typeparam name="TCache"></typeparam>
    public abstract class ObjectCacheProvider<TCache> : CacheProviderBase<TCache> where TCache : ObjectCache
    {

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
            CacheItemPolicy policy = new CacheItemPolicy(){
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration)
            };
            if (Cache.Contains(key))
                Cache.Set(key, value, policy);
            else
                Cache.Add(key, value, policy);
            
        }

        public override void Remove(string key)
        {
            Cache.Remove(key);
        }

        public override bool Contains(string key)
        {
            return Cache.Contains(key);
        }

        public override IEnumerable<KeyValuePair<string, object>> GetAll()
        {
            return Cache;
        }
    }
}
