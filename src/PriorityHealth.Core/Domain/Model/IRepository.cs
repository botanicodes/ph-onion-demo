//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------
	  
	  
namespace PriorityHealth.Core.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : IEntity<T>
    {
        T Get(object id);

        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T FindOneBy(Func<T, bool> predicate);

        IQueryable<T> Query();

        IQueryable<T> Query(Expression<Func<T, bool>> predicate);

        void Store(T entity);

        void Delete(T entity);
    }
}
