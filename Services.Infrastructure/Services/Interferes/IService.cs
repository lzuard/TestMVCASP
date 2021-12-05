using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services.Interferes
{
    public interface IService<TModelDto> where TModelDto : DtoBase
    {
        public Task<OperationResult<List<TModelDto>>> TryGetAll();
        
        public Task<OperationResult<TModelDto>> TryGet(int modelId);
        
        public Task<OperationResult<TModelDto>>TryCreate(TModelDto model);
        
        public Task<OperationResult<TModelDto>> TryUpdate(TModelDto model);
        
        public Task<OperationResult<bool>> TryDelete(int modelId);
    }
}