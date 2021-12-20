using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Supply;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class SupplyRepository : RepositoryBase<SupplyDto>
    {
        public SupplyRepository(ApplicationContext context) : base(context)
        {
        }
        
        public override async Task<OperationResult<IEnumerable<SupplyDto>>> GetAll()
        {
            IEnumerable<SupplyDto> result = await Context.Supplies
                .Include(x => x.Supplier)
                .Include(x => x.Employee)
                .Include(x => x.TransportCompany)
                .Include(x => x.Ttn)
                .ToListAsync();

            return OperationResult<IEnumerable<SupplyDto>>.GetSuccessResult(result);
        }

        public override async Task<OperationResult<SupplyDto>> Get(int modelId)
        {
            SupplyDto model = await Context.Supplies
                .Include(x => x.Supplier)
                .Include(x => x.Employee)
                .Include(x => x.TransportCompany)
                .Include(x => x.Ttn)
                .FirstOrDefaultAsync(x => x.Id == modelId);

            if (model == null)
            {
                string error = $"{typeof(SupplyDto)} with id {modelId} not found";

                return OperationResult<SupplyDto>.GetUnsuccessfulResult(error);
            }

            return OperationResult<SupplyDto>.GetSuccessResult(model);
        }
    }
}