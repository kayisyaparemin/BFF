using BFF.Core.Data;
using BFF.Models.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace BFF.API.Core.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        public Task<BaseResponse<int>> DeleteAsync(int id);
        public Task<List<TEntity>> GetFilteredAsync(ODataQueryOptions<TEntity> options);
        public Task<BaseResponse<List<TEntity>>> GetAllAsync();
        public Task<BaseResponse<List<TEntity>>> GetByIdAsync(int id);
        public Task<BaseResponse<List<TEntity>>> GetByIdsAsync(List<int> ids);
        public Task<BaseResponse<int>> InsertAsync<TDtoInsert>(TDtoInsert dtoInsert);
        public Task<BaseResponse<int>> UpdateAsync<TDtoUpdate>(TDtoUpdate dtoUpdate);
    }
}
