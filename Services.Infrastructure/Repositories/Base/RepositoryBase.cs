using System.Collections.Generic;
using Contracts.Contracts.Base;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Interferes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Infrastructure.Repositories.Base
{
    public class RepositoryBase<TModelDto> : IRepository<TModelDto> where TModelDto : DtoBase
    {
        protected readonly ApplicationContext Context;

        public RepositoryBase(ApplicationContext context)
        {
            Context = context;
        }
        
        public virtual async Task<List<TModelDto>> GetAll()
        {
            return await Context.Set<TModelDto>().ToListAsync();
        }

        public virtual async Task<TModelDto> Get(int modelId)
        {
            TModelDto model = await Context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == modelId);

            return model;
        }

        public virtual async Task<TModelDto> Create(TModelDto model)
        {
            await Context.Set<TModelDto>().AddAsync(model);
            await Context.SaveChangesAsync();
            
            return model;
        }

        public virtual async Task<TModelDto> Update(TModelDto model)
        {
            TModelDto toUpdateModel = await Context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == model.Id);
            
            if (toUpdateModel == null)
            {
                return null;
            }
            
            toUpdateModel = model;
            
            Context.Update(toUpdateModel);
            
            await Context.SaveChangesAsync();
            
            return toUpdateModel;
        }

        public virtual async Task<bool> Delete(int modelId)
        {
            TModelDto toDeleteModel = await Context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == modelId);

            if (toDeleteModel == null)
            {
                return false;
            }
            
            Context.Set<TModelDto>().Remove(toDeleteModel);
            
            await Context.SaveChangesAsync();

            return true;
        }
    }
}