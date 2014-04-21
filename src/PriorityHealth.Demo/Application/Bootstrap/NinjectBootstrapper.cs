//-----------------------------------------------------------------------
// <copyright file="NinjectBootstrapper.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	 
namespace PriorityHealth.Demo.Application.Bootstrap
{
    using Core.Application;
    using Infrastructure.IoC;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Ninject;

    /// <summary>
    /// Used to setup and teardown ninject configuration
    /// </summary>
    public class NinjectBootstrapper : NinjectBootstrapperBase, IInitializer, IDisposer
    {

        protected override void SetupDependencies(Ninject.IKernel kernel)
        {
            kernel.Load<Configuration.IoC.AppServicesModule>();
            kernel.Load<Configuration.IoC.DomainServicesModule>();

        }

        /// <summary>
        /// Default bootstrap init that will create default kernel
        /// </summary>
        public virtual void Initialize(EnvironmentProfile environment)
        {
            Initialize();
        }

        /// <summary>
        /// Dispose the ninject service resolver
        /// </summary>
        /// <param name="environment"></param>
        public virtual void Dispose(EnvironmentProfile environment)
        {
            ShutDown();
        }
    }
}
