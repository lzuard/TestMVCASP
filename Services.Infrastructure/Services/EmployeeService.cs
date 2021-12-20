using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public override Task<OperationResult<EmployeeDto>> TryCreate(EmployeeDto model)
        {
            model.Password = HashPassword(model.Password);
            
            return base.TryCreate(model);
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
                    authorizationResult.Message = GetAuthorizationMessage(employee);
                }
                else
                {
                    authorizationResult.ResultAuthentication = false;
                }
                
                return new OperationResult<EmployeeAuthenticationResultDto>(authorizationResult);
            }

            return new OperationResult<EmployeeAuthenticationResultDto>(
                new OperationResult<EmployeeAuthenticationResultDto>.OperationResultError(result.Error.Message));
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

        private string GetAuthorizationMessage(EmployeeDto employee)
        {
            string firstName = employee.FirstName.ToUpper()[0] + ".";
            string thirdName = string.Empty;

            if (!string.IsNullOrEmpty(employee.ThirdName))
            {
                thirdName = employee.ThirdName[0] + ".";
            }

            string message = string.Format("{0} {1}{2}", employee.SecondName, firstName, thirdName);

            return message;
        }
    }
}