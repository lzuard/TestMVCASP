using System;
using System.Collections.Generic;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Interferes;
using System.Threading.Tasks;
using Contracts.Contracts;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories.Base
{
    public class RepositoryBase<TModelDto> : IRecordRepository<TModelDto> where TModelDto : RecordDtoBase
    {
        protected readonly ApplicationContext Context;

        public RepositoryBase(ApplicationContext context)
        {
            Context = context;
        }

        public virtual async Task<OperationResult<List<TModelDto>>> GetAll()
        {
            List<TModelDto> result = await Context.Set<TModelDto>().ToListAsync();

            return new OperationResult<List<TModelDto>>(result);
        }

        public virtual async Task<OperationResult<TModelDto>> Get(int modelId)
        {
            TModelDto model = await Context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == modelId);

            if (model == null)
            {
                string error = $"Model with id {modelId} not found";

                return new OperationResult<TModelDto>(new OperationResult<TModelDto>.OperationResultError(error));
            }

            return new OperationResult<TModelDto>(model);
        }

        public virtual async Task<OperationResult<TModelDto>> Create(TModelDto model)
        {
            int newId = 1;
            
            if (await Context.Set<TModelDto>().AnyAsync())
            {
                newId = await Context.Set<TModelDto>().MaxAsync(x => x.Id) + 1;
            }
            
            model.Id = newId;

            await Context.Set<TModelDto>().AddAsync(model);

            return await TrySaveChanges(model);
        }

        public virtual async Task<OperationResult<TModelDto>> Update(TModelDto model)
        {
            TModelDto toUpdateModel = await Context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == model.Id);

            if (toUpdateModel == null)
            {
                string error = $"Model with id {model.Id} not found";

                return new OperationResult<TModelDto>(new OperationResult<TModelDto>.OperationResultError(error));
            }

            model.Id = toUpdateModel.Id;
            toUpdateModel = model;

            Context.Update(toUpdateModel);

            return await TrySaveChanges(toUpdateModel);
        }

        public virtual async Task<OperationResult<bool>> Delete(int modelId)
        {
            TModelDto toDeleteModel = await Context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == modelId);

            if (toDeleteModel == null)
            {
                string error = $"Model with id {modelId} not found";

                return new OperationResult<bool>(new OperationResult<bool>.OperationResultError(error));
            }

            Context.Set<TModelDto>().Remove(toDeleteModel);

            return await TrySaveChanges(result: true);
        }

        protected async Task<OperationResult<TResult>> TrySaveChanges<TResult>(TResult result)
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return new OperationResult<TResult>(new OperationResult<TResult>.OperationResultError(ex.Message));
            }

            return new OperationResult<TResult>(result);
        }
    }
}