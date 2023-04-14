using BFF.API.Helpers;
using BFF.Core.Data;
using BFF.Core.Data.Entities.BaseImp;
using BFF.Core.Repository;
using BFF.Models.Entities;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BFF.API.Core.Service
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : ActiveOnEntityBase,IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly MapHelper _mapper;
        public BaseService(IRepository<TEntity> repository, MapHelper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<int>> DeleteAsync(int id)
        {
            var response = new BaseResponse<int>();
            var entity = await _repository.GetById(id);
            entity.DeleionAuditing();
            await _repository.Update(entity);
            response.Data = entity.Id;
            return response;
        }

        public async Task<BaseResponse<List<TEntity>>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<List<TEntity>>();
            response.Data[0] = await _repository.GetById(id);
            return response;
        }

        public async Task<BaseResponse<List<TEntity>>> GetByIdsAsync(List<int> ids)
        {
            var response = new BaseResponse<List<TEntity>>();
            response.Data = await _repository.GetByIds(ids);
            return response;
        }

        public async Task<BaseResponse<int>> InsertAsync<TDtoInsert>(TDtoInsert dtoInsert)
        {
            var entity = _mapper.MapToEntity<TDtoInsert, TEntity>(dtoInsert);
            var response = new BaseResponse<int>();
            response.Data = entity.Id;
            await _repository.Insert(entity);
            return response;
        }

        public async Task<BaseResponse<int>> UpdateAsync<TDtoUpdate>(TDtoUpdate dtoUpdate)
        {
            var entity = _mapper.MapToEntity<TDtoUpdate, TEntity>(dtoUpdate);
            var response = new BaseResponse<int>();
            response.Data = entity.Id;
            await _repository.Update(entity);
            return response;
        }

        public async Task<List<TEntity>> GetFilteredAsync(ODataQueryOptions<TEntity> options)
        {
            return await _repository.GetFiltered(options);
        }

        public async Task<BaseResponse<List<TEntity>>> GetAllAsync()
        {
            var response = new BaseResponse<List<TEntity>>();
            response.Data = await _repository.GetAll();
            return response;
        }
    }

}
