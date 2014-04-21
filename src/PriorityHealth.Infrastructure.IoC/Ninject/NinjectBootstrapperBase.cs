//-----------------------------------------------------------------------
// <copyright file="NinjectBootstrapperBase.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  
namespace Infrastructure.IoC
{
    using System;
    using System.Web;
    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;    
    using System.Web.Http.Dependencies;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Core.Application;

    /// <summary>
    /// Abstract class used for bootstrapping ninject for an application
    /// </summary>
    public abstract class NinjectBootstrapperBase :
        Ninject.Web.Common.Bootstrapper
    {

        public NinjectBootstrapperBase()
            : base()
        {
            
        }

        /// <summary>
        /// Default bootstrap init that will create default kernel
        /// </summary>
        public virtual void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Initialize(CreateAndRegisterKernel);            
        }       

        /// <summary>
        /// Create the kernel that will manage the application
        /// </summary>
        /// <returns></returns>
        protected virtual IKernel CreateAndRegisterKernel()
        {

            IKernel kernel = new StandardKernel();

            RegisterApp(kernel);
            SetupDependencies(kernel);

            return kernel;
        }

        /// <summary>
        /// Register Ninject with MVC4 application
        /// </summary>
        protected virtual void RegisterApp(IKernel kernel)
        {
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

        }

        /// <summary>
        /// Register the rest of the dependencies in the application
        /// </summary>
        /// <param name="kernel"></param>
        protected abstract void SetupDependencies(IKernel kernel);

    }


}
