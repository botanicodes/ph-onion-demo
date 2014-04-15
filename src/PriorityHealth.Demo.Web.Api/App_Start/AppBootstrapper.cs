
//-----------------------------------------------------------------------
// <copyright file="AppBootstrapper.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  	 
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PriorityHealth.Demo.Web.Api.AppBootstrapper), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PriorityHealth.Demo.Web.Api.AppBootstrapper), "Stop")]
namespace PriorityHealth.Demo.Web.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Core.Application;

    public static class AppBootstrapper
    {
        private static IBootstrapper _bootstrapper;
        private static EnvironmentProfile _environment;

        static AppBootstrapper()
        {
            Init();
            Configure();
        }

        /// <summary>
        /// Run prior to application start
        /// </summary>
        public static void Start()
        {            
            _bootstrapper.Initialize(_environment);                
        }

        /// <summary>
        /// Run when the application shuts down
        /// </summary>
        public static void Stop()
        {
            //Do whatever necessary during stopping the application
            _bootstrapper.Dispose(_environment);   
            
        }

        /// <summary>
        /// Initialize the bootstrapper
        /// </summary>
        private static void Init()
        {
            _environment = EnvironmentProfile.Local;
            _bootstrapper = new PriorityHealth.Configuration.Bootstrapper();
        }

        /// <summary>
        /// Configure the bootstrapper
        /// </summary>
        private static void Configure()
        {
            _bootstrapper
                .InitUsing<Application.Bootstrap.NinjectBootstrapper>()
                .InitUsing<Application.Bootstrap.MainInitializer>()
                .DisposeUsing<Application.Bootstrap.NinjectBootstrapper>();
        }
    }
}