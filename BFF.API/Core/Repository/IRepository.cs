
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetFiltered(ODataQueryOptions<T> options);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task<List<T>> GetByIds(IEnumerable<int> ids);
    }


}
