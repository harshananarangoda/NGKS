using NGKS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Dependencies;

namespace NGKS.Web.Infrastructure.Extensions
{
    /// <summary>
    /// Class: RequestMessageExtension
    /// </summary>
    public static class RequestMessageExtension
    {
        /// <summary>
        /// Get membership service
        /// </summary>
        /// <param name="request">httprequestmessage</param>
        /// <returns>IMembership Service</returns>
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        /// <summary>
        /// Get Service
        /// </summary>
        /// <typeparam name="TService">Generic Service</typeparam>
        /// <param name="request">HttpRequestMessage</param>
        /// <returns>TService</returns>
        public static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}