using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Base;
using Services.Infrastructure.Repositories.Interferes;
using Services.Infrastructure.Services.Interferes;

namespace Services.Infrastructure.Services.Base
{
    public class ServiceBase<TRepository, TModelDto> : IService<TModelDto>
        where TRepository : IRepository<TModelDto>
        where TModelDto : DtoBase
    {
        protected readonly TRepository Repository;

        public ServiceBase(TRepository repository)
        {
            Repository = repository;
        }

        public virtual async Task<(bool IsSuccess, IEnumerable<TModelDto> Result)>TryGetAll()
        {
            List<TModelDto> result = await Repository.GetAll();

            return (true, result);
        }

        public virtual async Task<(bool IsSuccess, TModelDto Result)> TryGet(int modelId)
        {
            TModelDto result = await Repository.Get(modelId);

            return (result != null, result);
        }

        public virtual async Task<(bool IsSuccess, TModelDto Result)> TryCreate(TModelDto model)
        {
            TModelDto result = await Repository.Create(model);

            return (result != null, result);
        }

        public virtual async Task<(bool IsSuccess, TModelDto Result)> TryUpdate(TModelDto model)
        {
            TModelDto result = await Repository.Update(model);

            return (result != null, result);
        }

        public virtual async Task<(bool IsSuccess, object Result)> TryDelete(int modelId)
        {
            bool result = await Repository.Delete(modelId);

            return (result, null);
        }
    }
}