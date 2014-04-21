//-----------------------------------------------------------------------
// <copyright file="AppContext.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  	  
namespace PriorityHealth.Demo.Application
{
    using Core.Services;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.Http;
    using System.Web.Http.Dependencies;    

    /// <summary>
    /// Context of current application that is running.  This is shared across threads in IIS
    /// </summary>
    public class AppContext
    {

        #region Singleton
        private static AppContext _context;

        /// <summary>
        /// Current context of the application
        /// </summary>
        public static AppContext Current
        {
            get
            {
                return _context ?? (_context = GetContext());
            }
        }

        private static AppContext GetContext()
        {
            AppContext context = Resolver.GetService(typeof(AppContext)) as AppContext;
            return context ?? new AppContext();
        }
        #endregion

        #region Static 
        /// <summary>
        /// Get the current dependency resolver for the application
        /// </summary>
        public static IDependencyResolver Resolver
        {
            get
            {
                return GlobalConfiguration.Configuration.DependencyResolver;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Current environment
        /// </summary>
        //public EnvironmentPH Environment { get; private set; }

        /// <summary>
        /// Application settings from config 
        /// </summary>
        public AppSettings Settings { get; private set; }

        /// <summary>
        /// Current logger being used by the application
        /// </summary>
        [Inject]
        public ILogger Logger { get; set; }

        /// <summary>
        /// Current cache provider being used by the application
        /// </summary>
        [Inject]
        public ICacheProvider Cache { get; set; }

        /// <summary>
        /// Current version of the application
        /// </summary>
        public string AppVersion
        {
            get
            {                
                return BuildManager.GetGlobalAsaxType().BaseType.Assembly.GetName().Version.ToString();
            }
        }
        
        #endregion

        public AppContext()
        {
            Settings = new AppSettings();
        }
        
        public AppContext(ILogger logger, ICacheProvider cache)
        {            
            //Environment = new EnvironmentPH();
            Logger = logger;
            Cache = cache;
            Settings = new AppSettings();
        }
       
    }
}