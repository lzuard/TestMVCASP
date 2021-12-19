using System.Threading.Tasks;
using Contracts.Contracts.Records;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.SearchParameters;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class EmployeeService: RecordServiceBase<EmployeeRepository, EmployeeRecordDto>
    {
        public EmployeeService(EmployeeRepository recordRepository) : base(recordRepository)
        {
        }
        
        public async Task<OperationResult<bool>> TryAuthorization(
            EmployeeLoginSearchParameters searchParameters)
        {
            string login = searchParameters.Login;
            int passwordHash = searchParameters.Password.GetHashCode();
            
            return await Repository.TryAuthorization(login, passwordHash);
        }
    }
}