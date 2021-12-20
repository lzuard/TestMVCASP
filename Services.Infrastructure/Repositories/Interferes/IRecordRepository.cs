using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories.Interferes
{
    public interface IRecordRepository<TModelDto> where TModelDto : RecordDtoBase
    {
        public Task<OperationResult<List<TModelDto>>> GetAll();
        
        public Task<OperationResult<TModelDto>> Get(int modelId);
        
        public Task<OperationResult<TModelDto>> Create(TModelDto model);
        
        public Task<OperationResult<TModelDto>> Update(TModelDto model);
        
        public Task<OperationResult<bool>> Delete(int modelId);
    }
}