using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Return;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class ReturnRepository : RepositoryBase<ReturnDto>
    {
        public ReturnRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<OperationResult<IEnumerable<ReturnDto>>> GetAll()
        {
            IEnumerable<ReturnDto> result = await Context.Returns
                .Include(x => x.Order)
                .Include(x => x.Ttn)
                .Include(x => x.Employee)
                .ToListAsync();

            return OperationResult<IEnumerable<ReturnDto>>.GetSuccessResult(result);
        }

        public override async Task<OperationResult<ReturnDto>> Get(int modelId)
        {
            ReturnDto model = await Context.Returns
                .Include(x => x.Order)
                .Include(x => x.Ttn)
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Id == modelId);

            if (model == null)
            {
                string error = $"{typeof(ReturnDto)} with id {modelId} not found";

                return OperationResult<ReturnDto>.GetUnsuccessfulResult(error);
            }

            return OperationResult<ReturnDto>.GetSuccessResult(model);
        }
    }
}