using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Utilization;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class UtilizationRepository : RepositoryBase<UtilizationDto>
    {
        public UtilizationRepository(ApplicationContext context) : base(context)
        {
        }
        
        public override async Task<OperationResult<IEnumerable<UtilizationDto>>> GetAll()
        {
            IEnumerable<UtilizationDto> result = await Context.Utilizations
                .Include(x => x.Employee)
                .Include(x => x.Utilizer)
                .Include(x => x.Ttn)
                .ToListAsync();

            return OperationResult<IEnumerable<UtilizationDto>>.GetSuccessResult(result);
        }

        public override async Task<OperationResult<UtilizationDto>> Get(int modelId)
        {
            UtilizationDto model = await Context.Utilizations
                .Include(x => x.Employee)
                .Include(x => x.Utilizer)
                .Include(x => x.Ttn)
                .FirstOrDefaultAsync(x => x.Id == modelId);

            if (model == null)
            {
                string error = $"{typeof(UtilizationDto)} with id {modelId} not found";

                return OperationResult<UtilizationDto>.GetUnsuccessfulResult(error);
            }

            return OperationResult<UtilizationDto>.GetSuccessResult(model);
        }
    }
}