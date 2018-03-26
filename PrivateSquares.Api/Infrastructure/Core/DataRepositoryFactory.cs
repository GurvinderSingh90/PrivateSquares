using PrivateSquares.Api.Infrastructure.Extensions;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Repositories;
using System.Net.Http;

namespace PrivateSquares.Api.Infrastructure.Core
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public IEntityRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new()
        {
            return request.GetDataRepository<T>();
        }
    }

    public interface IDataRepositoryFactory
    {
        IEntityRepository<T> GetDataRepository<T>(HttpRequestMessage request) where T : class, IEntityBase, new();
    }
}
