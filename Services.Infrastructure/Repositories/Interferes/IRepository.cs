using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;

namespace Services.Infrastructure.Repositories.Interferes
{
    public interface IRepository<TModelDto> where TModelDto : DtoBase
    {
        public Task<List<TModelDto>> GetAll();
        
        public Task<TModelDto> Get(int modelId);
        
        public Task<TModelDto> Create(TModelDto model);
        
        public Task<TModelDto> Update(TModelDto model);
        
        public Task<bool> Delete(int modelId);
    }
}