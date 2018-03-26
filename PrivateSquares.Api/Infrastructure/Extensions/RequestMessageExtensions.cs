using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Repositories;
using PrivateSquares.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace PrivateSquares.Api.Infrastructure.Extensions
{
    public static class RequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        internal static IEntityRepository<T> GetDataRepository<T>(this HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetService<IEntityRepository<T>>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}
