//-----------------------------------------------------------------------
// <copyright file="DomainServicesModule.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Jared Dickson</author>
// </copyright>
//-----------------------------------------------------------------------

namespace PriorityHealth.Demo.Configuration.IoC
{
    using Ninject.Modules;
    using PriorityHealth.Core.Domain.Model.Users;
    using PriorityHealth.EntityFramework.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DomainServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}
