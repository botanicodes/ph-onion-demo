//-----------------------------------------------------------------------
// <copyright file="IBootstrapper.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  
namespace Core.Application
{
    public interface IBootstrapper : IInitializer, IDisposer
    {
        /// <summary>
        /// Add an initializer to the bootstrapper
        /// </summary>
        /// <typeparam name="TInitialize"></typeparam>
        /// <returns></returns>
        IBootstrapper InitUsing<TInitialize>() where TInitialize : IInitializer;
        /// <summary>
        /// Add a disposer to the bootstrapper
        /// </summary>
        /// <typeparam name="TDispose"></typeparam>
        /// <returns></returns>
        IBootstrapper DisposeUsing<TDispose>() where TDispose : IDisposer;
        /// <summary>
        /// Add initializer to the bootstrapper
        /// </summary>
        /// <param name="initializer"></param>
        /// <returns></returns>
        IBootstrapper AddInitializer(IInitializer initializer);
        /// <summary>
        /// Add a disposer to the bootstrapper
        /// </summary>
        /// <param name="shutDown"></param>
        /// <returns></returns>
        IBootstrapper AddDisposer(IDisposer shutDown);
    }
}
