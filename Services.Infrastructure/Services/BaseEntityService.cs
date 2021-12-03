using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;
using Services.Infrastructure.Repositories.Interferes;
using Services.Infrastructure.Services.Interferes;

namespace Services.Infrastructure.Services
{
    public class BaseEntityService<TRepository, TModelDto> : IEntityService<TModelDto>
        where TRepository : IBaseRepository<TModelDto>
        where TModelDto : DtoBase
    {
        private readonly TRepository _repository;

        public BaseEntityService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<(bool IsSuccess, IEnumerable<TModelDto> Result)>TryGetAll()
        {
            List<TModelDto> result = await _repository.GetAll();

            return (true, result);
        }

        public async Task<(bool IsSuccess, TModelDto Result)> TryGet(int modelId)
        {
            TModelDto result = await _repository.Get(modelId);

            return result == null ? (false, null) : (true, result);
        }

        public async Task<(bool IsSuccess, TModelDto Result)> TryCreate(TModelDto model)
        {
            TModelDto result = await _repository.Create(model);

            return result == null ? (false, null) : (true, result);
        }

        public async Task<(bool IsSuccess, TModelDto Result)> TryUpdate(TModelDto model)
        {
            TModelDto result = await _repository.Update(model);

            return result == null ? (false, null) : (true, result);
        }

        public async Task<(bool IsSuccess, object Result)> TryDelete(int modelId)
        {
            bool result = await _repository.Delete(modelId);

            return (result, null);
        }
    }
}