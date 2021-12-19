using System.Threading.Tasks;
using Contracts.Contracts.Employee;
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

        public Task<OperationResult<bool>> TryAuthorization(string login, long passwordHash)
        {
            if (login == "admin" && passwordHash == ("123123").GetHashCode())
            {
                return Task.FromResult(new OperationResult<bool>(true));
            }
            
            //bool result = await Context.Employees.AnyAsync(x => x.Password == passwordHash && x.Login == login);

            return Task.FromResult(new OperationResult<bool>(false));
        }
    }
}