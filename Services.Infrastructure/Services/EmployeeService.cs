using System.Threading.Tasks;
using Contracts.Contracts.Employee;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class EmployeeService: RecordServiceBase<EmployeeRepository, EmployeeDto>
    {
        public EmployeeService(EmployeeRepository recordRepository) : base(recordRepository)
        {
        }
        
        public async Task<OperationResult<bool>> TryAuthorization(
            EmployeeAuthenticationParametersDto searchParametersDto)
        {
            string login = searchParametersDto.Login;
            int passwordHash = searchParametersDto.Password.GetHashCode();
            
            return await Repository.TryAuthorization(login, passwordHash);
        }
    }
}