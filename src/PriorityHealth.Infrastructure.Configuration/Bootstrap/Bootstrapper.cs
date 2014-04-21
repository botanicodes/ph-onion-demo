//-----------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  

namespace Infrastructure.Configuration
{
    using Core.Application;
    using PriorityHealth.Demo.Application.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bootstrapper : IBootstrapper
    {
        #region Properties
        /// <summary>
        /// List of initializers
        /// </summary>
        protected List<IInitializer> Initializers { get; set; }
        /// <summary>
        /// List of disposers
        /// </summary>
        protected List<IDisposer> Disposers { get; set; }

        /// <summary>
        /// Environment to run modules for
        /// </summary>
        public EnvironmentProfile Environment { get; set; }
        #endregion

        #region CTOR
        public Bootstrapper() : this(EnvironmentProfile.Any)
        {
            
        }

        Bootstrapper(EnvironmentProfile environment)
        {
            Environment = environment;
            Initializers = new List<IInitializer>();
            Disposers = new List<IDisposer>();
        }
        #endregion

        #region IInitializer,IDisposer Methods

        /// <summary>
        /// Initialize the application's bootstrapper
        /// </summary>
        public void Initialize(EnvironmentProfile profile)
        {
            foreach (IInitializer initializer in Initializers)
                initializer.Initialize(profile);
        }

        /// <summary>
        /// Dispose of the application's bootstrapper
        /// </summary>
        public void Dispose(EnvironmentProfile profile)
        {
            foreach (IDisposer disposer in Disposers)
                disposer.Dispose(profile);
        }
        #endregion

        #region IBootstrapper Methods
        /// <summary>
        /// Add an initializer to the bootstrapper
        /// </summary>
        /// <typeparam name="TInitialize"></typeparam>
        /// <returns></returns>
        public IBootstrapper InitUsing<TInitialize>() where TInitialize : IInitializer
        {

            TInitialize initializer = Activator.CreateInstance<TInitialize>();

            return AddInitializer(initializer);
        }
        /// <summary>
        /// Add initializer to the bootstrapper
        /// </summary>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public IBootstrapper AddInitializer(IInitializer initializer)
        {
            if (initializer != null && IsForEnvironment(initializer.GetType()))
                Initializers.Add(initializer);

            return this;
        }

        /// <summary>
        /// Add disposer to the bootstrapper
        /// </summary>
        /// <typeparam name="TDispose"></typeparam>
        /// <returns></returns>
        public IBootstrapper DisposeUsing<TDispose>() where TDispose : IDisposer
        {
            TDispose shutdown = Activator.CreateInstance<TDispose>();

            return AddDisposer(shutdown);
        }

        /// <summary>
        /// Add disposer to the bootstrapper
        /// </summary>
        /// <param name="shutDown"></param>
        /// <returns></returns>
        public IBootstrapper AddDisposer(IDisposer shutDown)
        {
            if (shutDown != null && IsForEnvironment(shutDown.GetType()))
                Disposers.Add(shutDown);

            return this;
        }
        #endregion

        protected virtual bool IsForEnvironment(Type type)
        {
            IEnumerable<EnvironmentUsageAttribute> attributes = type.GetCustomAttributes(typeof(EnvironmentUsageAttribute), true)
                .OfType<EnvironmentUsageAttribute>();

            //Check to see if configured environment is any or type contains attribute that matches the current
            return Environment == EnvironmentProfile.Any 
                || attributes.Any(attr => attr.Environment == EnvironmentProfile.Any || (attr.Environment & Environment) == Environment);

        }

        
    }
}
