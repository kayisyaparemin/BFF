using BFF.Core.Data;
using BFF.Models.Entities;
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Services
{
    public interface IProductService
    {
        public Task<BaseResponse<int>> DeleteAsync(int id);
        public Task<BaseResponse<List<Product>>> GetAllProductsAsync(ODataQueryOptions<Product> options);
        public Task<BaseResponse<Product>> GetProductAsync(int id);
        public Task<BaseResponse<List<Product>>> GetProductsAsync(List<int> ids);
        public Task<BaseResponse<int>> InsertAsync(Product entity);
        public Task<BaseResponse<int>> UpdateAsync(Product entity);
    }
}
