using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Contracts.Agent;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class AgentRepository : RepositoryBase<AgentDto>
    {
        public AgentRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<OperationResult<IEnumerable<AgentDto>>> GetAll()
        {
            IEnumerable<AgentDto> result = await Context.Agents
                .Include(x => x.Address)
                .Include(x => x.Type)
                .ToListAsync();

            return OperationResult<IEnumerable<AgentDto>>.GetSuccessResult(result);
        }

        public override async Task<OperationResult<AgentDto>> Get(int modelId)
        {
            AgentDto model = await Context.Agents
                .Include(x => x.Address)
                .Include(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == modelId);

            if (model == null)
            {
                string error = $"{typeof(AgentDto)} with id {modelId} not found";

                return OperationResult<AgentDto>.GetUnsuccessfulResult(error);
            }

            return OperationResult<AgentDto>.GetSuccessResult(model);
        }

        public async Task<OperationResult<IEnumerable<AgentDto>>> GetByFilter(AgentFilterDto filterDto)
        {
            IEnumerable<AgentDto> result = await Context.Agents
                .Include(x => x.Type)
                .Include(x => x.Address)
                .Where(x =>
                    (x.Id == filterDto.AgentId || filterDto.AgentId == null) &&
                    (x.Type.Id == filterDto.TypeId || filterDto.TypeId == null) &&
                    (x.Address.Id == filterDto.AddressId || filterDto.AddressId == null) &&
                    (x.OrganizationName == filterDto.OrganizationName || filterDto.OrganizationName == null) &&
                    (x.CheckingAccount == filterDto.CheckingAccount || filterDto.CheckingAccount == null) &&
                    (x.IndividualTaxpayerNumber == filterDto.IndividualTaxpayerNumber ||
                     filterDto.IndividualTaxpayerNumber == null) &&
                    (x.Phone == filterDto.Phone || filterDto.Phone == null) &&
                    (x.Email == filterDto.Email || filterDto.Email == null))
                .ToListAsync();

            return new OperationResult<IEnumerable<AgentDto>>(result);
        }
    }
}