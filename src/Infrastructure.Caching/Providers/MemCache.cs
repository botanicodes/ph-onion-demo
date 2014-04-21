//-----------------------------------------------------------------------
// <copyright file="MemCache.cs" company="Spectrum Health">
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
    /// MemoryCache implementation of ICacheProvider
    /// </summary>
    public class MemCache : ObjectCacheProvider<MemoryCache>
    {
        protected override MemoryCache InitCache()
        {
            return MemoryCache.Default;
        }
        
    }
}
