using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;

namespace Services.Infrastructure.Services.Interferes
{
    public interface IEntityService<TModelDto> where TModelDto : DtoBase
    {
        public Task<(bool IsSuccess, IEnumerable<TModelDto> Result)> TryGetAll();
        
        public Task<(bool IsSuccess, TModelDto Result)> TryGet(int modelId);
        
        public Task<(bool IsSuccess, TModelDto Result)>TryCreate(TModelDto model);
        
        public Task<(bool IsSuccess, TModelDto Result)> TryUpdate(TModelDto model);
        
        public Task<(bool IsSuccess, object Result)> TryDelete(int modelId);
    }
}