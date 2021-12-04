using System.Collections.Generic;
using Contracts.Contracts.Base;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Interferes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Infrastructure.Repositories
{
    public class RepositoryBase<TModelDto> : IRepository<TModelDto> where TModelDto : DtoBase
    {
        private readonly ApplicationContext _context;

        public RepositoryBase(ApplicationContext context)
        {
            _context = context;
        }
        
        public virtual async Task<List<TModelDto>> GetAll()
        {
            return await _context.Set<TModelDto>().ToListAsync();
        }

        public virtual async Task<TModelDto> Get(int modelId)
        {
            TModelDto model = await _context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == modelId);

            return model;
        }

        public virtual async Task<TModelDto> Create(TModelDto model)
        {
            await _context.Set<TModelDto>().AddAsync(model);
            await _context.SaveChangesAsync();
            
            return model;
        }

        public virtual async Task<TModelDto> Update(TModelDto model)
        {
            TModelDto toUpdateModel = await _context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == model.Id);
            
            if (toUpdateModel == null)
            {
                return null;
            }
            
            toUpdateModel = model;
            
            _context.Update(toUpdateModel);
            
            await _context.SaveChangesAsync();
            
            return toUpdateModel;
        }

        public virtual async Task<bool> Delete(int modelId)
        {
            TModelDto toDeleteModel = await _context.Set<TModelDto>().FirstOrDefaultAsync(x => x.Id == modelId);

            if (toDeleteModel == null)
            {
                return false;
            }
            
            _context.Set<TModelDto>().Remove(toDeleteModel);
            
            await _context.SaveChangesAsync();

            return true;
        }
    }
}