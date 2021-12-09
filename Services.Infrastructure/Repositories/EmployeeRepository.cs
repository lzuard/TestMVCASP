using System.Threading.Tasks;
using Contracts.Contracts.Records;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class EmployeeRepository : RecordRepositoryBase<EmployeeRecordDto>
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<OperationResult<bool>> TryAuthorization(string login, long passwordHash)
        {
            bool result = await Context.Employees.AnyAsync(x => x.Password == passwordHash && x.Login == login);

            return new OperationResult<bool>(result);
        }
    }
}