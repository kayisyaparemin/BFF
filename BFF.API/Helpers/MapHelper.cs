using AutoMapper;

namespace BFF.API.Helpers
{
    public class MapHelper
    {
        public TEntity MapToEntity<TDto, TEntity>(TDto dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TDto, TEntity>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TDto, TEntity>(dto);
        }

        public TDto MapToDto<TEntity, TDto>(TEntity entity)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TEntity, TDto>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<TEntity, TDto>(entity);
        }
    }
}
