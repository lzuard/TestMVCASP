using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;
using Services.Infrastructure.Repositories.Interferes;
using Services.Infrastructure.Services.Interferes;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services.Base
{
    public class RecordServiceBase<TRepository, TModelDto> : IRecordService<TModelDto>
        where TRepository : IRecordRepository<TModelDto>
        where TModelDto : RecordDtoBase
    {
        protected readonly TRepository Repository;

        public RecordServiceBase(TRepository recordRepository)
        {
            Repository = recordRepository;
        }

        public virtual async Task<OperationResult<List<TModelDto>>>TryGetAll()
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