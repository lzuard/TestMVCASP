using Contracts.Contracts.Employee;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure.Services
{
    public class EmployeeService: ServiceBase<EmployeeRepository, EmployeeDto>
    {
        public EmployeeService(EmployeeRepository recordRepository) : base(recordRepository)
        {
        }

        public override async Task<OperationResult<IEnumerable<EmployeeDto>>> TryGetAll()
        {
            var result = await base.TryGetAll();

            if (result.IsSuccess)
            {
                foreach (EmployeeDto employee in result.Result)
                {
                    employee.Password = null;
                }
            }

            return result;
        }

        public override async Task<OperationResult<EmployeeDto>> TryGet(int modelId)
        {
            var result = await base.TryGet(modelId);

            if (result.IsSuccess)
            {
                result.Result.Password = null;
            }
            
            return result;
        }

        public override async Task<OperationResult<EmployeeDto>> TryUpdate(EmployeeDto model)
        {
            model.Password = HashPassword(model.Password);
            
            return await base.TryUpdate(model);
        }

        public override  async Task<OperationResult<EmployeeDto>> TryCreate(EmployeeDto model)
        {
            model.Password = HashPassword(model.Password);
            
            return await base.TryCreate(model);
        }

        public async Task<OperationResult<EmployeeAuthenticationResultDto>> TryAuthorization(
            EmployeeAuthenticationParametersDto searchParametersDto)
        {
            var filter = new EmployeeFilterDto
            {
                Login = searchParametersDto.Login,
                Password = HashPassword(searchParametersDto.Password)
            };

            OperationResult<IEnumerable<EmployeeDto>> result = await Repository.GetByFilter(filter);

            if (result.IsSuccess)
            {
                var authorizationResult = new EmployeeAuthenticationResultDto();
                
                if (result.Result.Any())
                {
                    EmployeeDto employee = result.Result.First();

                    authorizationResult.ResultAuthentication = true;
                    authorizationResult.Message = Helpers.GetEmployeeFormatName(employee);
                }
                else
                {
                    authorizationResult.ResultAuthentication = false;
                }
                
                return OperationResult<EmployeeAuthenticationResultDto>.GetSuccessResult(authorizationResult);
            }

            return OperationResult<EmployeeAuthenticationResultDto>.GetUnsuccessfulResult(result.Error.Message);
        }

        public string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}