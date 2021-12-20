using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Contracts.Employee;
using Contracts.Contracts.Ttn;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class TtnRepository : RepositoryBase<TtnDto>
    {
        public TtnRepository(ApplicationContext context) : base(context)
        {
        }
        
        public async Task<OperationResult<IEnumerable<TtnDto>>> GetByFilter(TtnFilterDto filterDto)
        {
            IEnumerable<TtnDto> result = await Context.Ttns.Where(ttn =>
                    (ttn.Id == filterDto.TtnId|| filterDto.TtnId == null) &&
                    (ttn.Number == filterDto.Number|| filterDto.Number == null) &&
                    (ttn.Type == filterDto.Type || filterDto.Type == null) &&
                    (ttn.Form == filterDto.Form || filterDto.Form == null) &&
                    (ttn.Date == filterDto.Date || filterDto.Date == null))
                .ToListAsync();

            return new OperationResult<IEnumerable<TtnDto>>(result);
        }
    }
}