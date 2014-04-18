//-----------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
namespace PriorityHealth.Core.Domain.Model
{
    public interface IEntity<T> : IEntity where T : IEntity<T>
    {

    }

    public interface IEntity
    {
        bool IsNew();
    }
}
