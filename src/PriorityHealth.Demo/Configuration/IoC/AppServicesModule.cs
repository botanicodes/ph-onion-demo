
//-----------------------------------------------------------------------
// <copyright file="AppServicesModule.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  
namespace PriorityHealth.Demo.Configuration.IoC
{
    using Ninject.Modules;
    using Core.Services;
    using Core.Services.Conversion;
    using Infrastructure.Caching.Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Setup IoC configuration for the variety of app services
    /// </summary>
    public class AppServicesModule : NinjectModule
    {

        public override void Load()
        {
            Bind<ILogger>().To<Logging.Impl.Log4NetLogger>();
            Bind<IStringConverter>().To<StringConverter>();
            Bind<ICacheProvider>().To<MemCache>();
        }
    }
}
