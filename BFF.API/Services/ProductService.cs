using BFF.Core.Data;
using BFF.Models.Entities;
using BFF.Repositories;
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<BaseResponse<int>> DeleteAsync(int id)
        {
           var response = new BaseResponse<int>();
           var entity =  await _productRepository.GetById(id);
           entity.DeleionAuditing();
           await _productRepository.Update(entity);
           response.Data = entity.Id;
           return response;
           
        }

        public async Task<BaseResponse<Product>> GetProductAsync(int id)
        {
            var response = new BaseResponse<Product>();
            response.Data = await _productRepository.GetById(id);
            return response;
        }

        public async Task<BaseResponse<List<Product>>> GetProductsAsync(List<int> ids)
        {
            var response = new BaseResponse<List<Product>>();
            response.Data = await _productRepository.GetByIds(ids);
            return response;
        }

        public async Task<BaseResponse<int>> InsertAsync(Product entity)
        {
            var response = new BaseResponse<int>();
            response.Data = entity.Id;
            await _productRepository.Insert(entity);
            return response;
        }

        public async Task<BaseResponse<int>> UpdateAsync(Product entity)
        {
            var response = new BaseResponse<int>();
            response.Data = entity.Id;
            await _productRepository.Update(entity);
            return response;
        }

        public async Task<BaseResponse<List<Product>>> GetAllProductsAsync(ODataQueryOptions<Product> options)
        {
            var response = new BaseResponse<List<Product>>();
            response.Data = await _productRepository.GetAll(options);
            return response;
        }

   
    }
}
