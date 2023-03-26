using BFF.Core.Data;
using BFF.Models.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Services
{
    public interface ICategoryService
    {
        public Task<BaseResponse<int>> DeleteAsync(int id);
        public Task<BaseResponse<List<Category>>> GetAllCategoriesAsync(ODataQueryOptions<Category> options);
        public Task<BaseResponse<Category>> GetCategoryAsync(int id);
        public Task<BaseResponse<List<Category>>> GetCategoriesAsync(List<int> ids);
        public Task<BaseResponse<int>> InsertAsync(Category entity);
        public Task<BaseResponse<int>> UpdateAsync(Category entity);
    }
}
