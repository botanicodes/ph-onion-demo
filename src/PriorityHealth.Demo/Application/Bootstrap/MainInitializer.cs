//-----------------------------------------------------------------------
// <copyright file="MainInitializer.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  

namespace PriorityHealth.Demo.Application.Bootstrap
{
    using PriorityHealth.Core.Application;
    using PriorityHealth.Phonebook.Application.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [EnvironmentUsage(EnvironmentProfile.Any)]
    public class MainInitializer : IInitializer
    {
        private log4net.ILog _log;

        public void Initialize(EnvironmentProfile environment)
        {
            InitLogger();
            InitAutoMapper();
        }

        private void InitAutoMapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile<Configuration.Mapping.UserMappingProfile>();
                
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();

        }

        private void InitLogger()
        {
            _log = log4net.LogManager.GetLogger(System.Reflection.Assembly.GetExecutingAssembly(), "Default");
        }
    }
}
