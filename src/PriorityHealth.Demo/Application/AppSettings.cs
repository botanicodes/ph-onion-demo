//-----------------------------------------------------------------------
// <copyright file="AppSettings.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  	  

namespace PriorityHealth.Demo.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Application;
    using Core.Common.Extensions;
    using System.Configuration;

    public class AppSettings : AppSettingsBase
    {       

        /// <summary>
        /// Current environment that the application is running in
        /// </summary>
        public EnvironmentProfile Environment
        {
            get
            {
                return Get<EnvironmentProfile>("Application:Environment", EnvironmentProfile.Development);
            }
        }
               
    }
}