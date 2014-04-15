//-----------------------------------------------------------------------
// <copyright file="IBootstrapper.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------	  	  

namespace PriorityHealth.Core.Application
{
    public interface IInitializer
    {
        void Initialize(EnvironmentProfile environment);
    }

}
