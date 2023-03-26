using BFF.Core.Data;
using BFF.Models.Entities;
using BFF.Repositories;
using Microsoft.AspNetCore.OData.Query;

namespace BFF.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseResponse<int>> DeleteAsync(int id)
        {
            var response = new BaseResponse<int>();
            var entity = await _categoryRepository.GetById(id);
            entity.DeleionAuditing();
            await _categoryRepository.Update(entity);
            response.Data = entity.Id;
            return response;

        }

        public async Task<BaseResponse<Category>> GetCategoryAsync(int id)
        {
            var response = new BaseResponse<Category>();
            response.Data = await _categoryRepository.GetById(id);
            return response;
        }

        public async Task<BaseResponse<List<Category>>> GetCategoriesAsync(List<int> ids)
        {
            var response = new BaseResponse<List<Category>>();
            response.Data = await _categoryRepository.GetByIds(ids);
            return response;
        }

        public async Task<BaseResponse<int>> InsertAsync(Category entity)
        {
            var response = new BaseResponse<int>();
            response.Data = entity.Id;
            await _categoryRepository.Insert(entity);
            return response;
        }

        public async Task<BaseResponse<int>> UpdateAsync(Category entity)
        {
            var response = new BaseResponse<int>();
            response.Data = entity.Id;
            await _categoryRepository.Update(entity);
            return response;
        }

        public async Task<BaseResponse<List<Category>>> GetAllCategoriesAsync(ODataQueryOptions<Category> options)
        {
            var response = new BaseResponse<List<Category>>();
            response.Data = await _categoryRepository.GetAll(options);
            return response;
        }
    }
}
