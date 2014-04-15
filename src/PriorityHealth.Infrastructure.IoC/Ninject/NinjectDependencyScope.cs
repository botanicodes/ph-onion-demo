//-----------------------------------------------------------------------
// <copyright file="NinjectDependencyScope.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------


namespace PriorityHealth.Infrastructure.IoC
{
    using Ninject.Syntax;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http.Dependencies;

    /// <summary>
    /// Implementation of .net's IDependency scope using ninject
    /// </summary>
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot _resolver;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="resolver"></param>
        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            _resolver = resolver;
        }

        /// <summary>
        /// Gets configured service of a specific type
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(System.Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return _resolver.TryGet(serviceType);
        }

        /// <summary>
        /// Gets a list of services configured for a type
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<object> GetServices(System.Type serviceType)
        {
            if (_resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return _resolver.GetAll(serviceType);
        }

        /// <summary>
        /// Dispose of the scope
        /// </summary>
        public void Dispose()
        {
            var disposable = _resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();
            _resolver = null;
        }
    }
}