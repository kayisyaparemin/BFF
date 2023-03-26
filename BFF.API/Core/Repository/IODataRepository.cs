
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Core.Repository
{
    public interface IODataRepository<T> where T : class
    {
        Task<List<T>> GetAll(ODataQueryOptions<T> options);
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task<List<T>> GetByIds(IEnumerable<int> ids);
    }


}
