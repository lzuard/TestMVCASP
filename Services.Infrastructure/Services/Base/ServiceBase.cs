using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts;
using Services.Infrastructure.Repositories.Interferes;
using Services.Infrastructure.Services.Interferes;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services.Base
{
    public class ServiceBase<TRepository, TModelDto> : IService<TModelDto>
        where TRepository : IRecordRepository<TModelDto> where TModelDto : RecordDtoBase
    {
        protected readonly TRepository Repository;

        public ServiceBase(TRepository recordRepository)
        {
            Repository = recordRepository;
        }

        public virtual async Task<OperationResult<IEnumerable<TModelDto>>>TryGetAll()
        {
            return await Repository.GetAll();
        }

        public virtual async Task<OperationResult<TModelDto>> TryGet(int modelId)
        {
            return await Repository.Get(modelId);
        }

        public virtual async Task<OperationResult<TModelDto>> TryCreate(TModelDto model)
        {
            return await Repository.Create(model);
        }

        public virtual async Task<OperationResult<TModelDto>> TryUpdate(TModelDto model)
        {
            return await Repository.Update(model);
        }

        public virtual async Task<OperationResult<bool>> TryDelete(int modelId)
        {
            return await Repository.Delete(modelId);
        }
    }
}