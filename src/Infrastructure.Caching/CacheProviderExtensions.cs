
//-----------------------------------------------------------------------
// <copyright file="CacheProviderExtensions.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  
namespace Infrastructure.Caching
{
    using Core.Services;
    using System;

    /// <summary>
    /// Extension methods for working with a cache provider
    /// </summary>
    public static class CacheProviderExtensions
    {
        /// <summary>
        /// Generate a key from a set of defining values
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="parts"></param>
        /// <returns></returns>
        public static string GenerateKey(this ICacheProvider cache, params object[] parts)
        {
            return String.Join(":", parts);
        }
    }
}
