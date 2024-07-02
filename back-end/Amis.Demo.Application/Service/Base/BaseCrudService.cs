using MISA.WebFresher062023.Demo.Application;
using MISA.WebFresher062023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher062023.Demo.Application
{
    public abstract class BaseCrudService<TEntity, TKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyService<TEntity, TKey, TEntityDto>, ICrudService<TKey, TEntityDto, TEntityCreateDto, TEntityUpdateDto> where TEntityDto : class where TEntityCreateDto : class where TEntityUpdateDto : class where TEntity : TEntity<TKey>
    {
        protected readonly ICrudRepository<TEntity, TKey> CrudRepository;
        protected BaseCrudService(ICrudRepository<TEntity, TKey> repository) : base(repository)
        {
            CrudRepository = repository;
        }
        public async Task<TEntityDto> InsertAsync(TEntityCreateDto entityCreateDto)
        {
            var entity = await MapEntityCreateDtoToEntity(entityCreateDto);
            await CrudRepository.InsertAsync(entity);
            var result = MapEntityToEntityDto(entity);
            return result;

        }

        public async Task<TEntityDto> UpdateAsync(TKey id, TEntityUpdateDto entityUpdateDto)
        {
            var entity = await MapEntityUpdateDtoToEntity(entityUpdateDto);
            await CrudRepository.InsertAsync(entity);
            var result = MapEntityToEntityDto(entity);
            return result;
        }
        public async Task<int> DeleteAsync(TKey id)
        {
            var entity = await CrudRepository.GetAsync(id);
            var result = await CrudRepository.DeleteAsync(entity);
            return result;
        }

        public Task<int> DeleteManyAsync(List<TKey> ids)
        {
            throw new NotImplementedException();
        }
        public abstract Task<TEntity> MapEntityCreateDtoToEntity(TEntityCreateDto entityCreateDto);
        public abstract Task<TEntity> MapEntityUpdateDtoToEntity(TEntityUpdateDto entityUpdateDto);

        public Task AddAsync<TEntityCreateDto1>(TEntityCreateDto1 entityCreateDto) where TEntityCreateDto1 : class
        {
            throw new NotImplementedException();
        }
    }
}
