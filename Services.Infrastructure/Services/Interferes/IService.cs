using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services.Interferes
{
    public interface IService<TModelDto> where TModelDto : RecordDtoBase
    {
        public Task<OperationResult<IEnumerable<TModelDto>>> TryGetAll();
        
        public Task<OperationResult<TModelDto>> TryGet(int modelId);
        
        public Task<OperationResult<TModelDto>>TryCreate(TModelDto model);
        
        public Task<OperationResult<TModelDto>> TryUpdate(TModelDto model);
        
        public Task<OperationResult<bool>> TryDelete(int modelId);
    }
}