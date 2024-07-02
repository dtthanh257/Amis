using MISA.WebFresher062023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Application
{
    public abstract class BaseReadOnlyService<TEntity, TKey, TEntityDto> : IReadOnlyService<TKey, TEntityDto> where TEntity : TEntity<TKey> where TEntityDto : class
    {
        protected readonly IReadOnlyRepository<TEntity, TKey> Repository;
        public BaseReadOnlyService(IReadOnlyRepository<TEntity, TKey> repository)
        {
            Repository = repository;
        }
        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var entities = await Repository.GetAllAsync();
            var result = entities.Select(entity => MapEntityToEntityDto(entity)).ToList();
            return result;
        }

        public async Task<TEntityDto> GetAsync(TKey id)
        {
            var entity = await Repository.GetAsync(id);
            var result = MapEntityToEntityDto(entity);
            return result;
        }
        protected abstract TEntityDto MapEntityToEntityDto(TEntity entity);
    }
}
