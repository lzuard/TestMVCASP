using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Contracts.Employee;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<EmployeeDto>
    {
        public EmployeeRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<OperationResult<IEnumerable<EmployeeDto>>> GetByFilter(
            EmployeeFilterDto filterDto)
        {
            IEnumerable<EmployeeDto> result = await Context.Employees.Where(employee =>
                    (employee.Id == filterDto.EmployeeId || filterDto.EmployeeId == null) &&
                    (employee.SecondName == filterDto.SecondName || filterDto.SecondName == null) &&
                    (employee.FirstName == filterDto.FirstName || filterDto.FirstName == null) &&
                    (employee.ThirdName == filterDto.ThirdName || filterDto.ThirdName == null) &&
                    (employee.BirthDate == filterDto.BirthDate || filterDto.BirthDate == null) &&
                    (employee.PhoneNumber == filterDto.PhoneNumber || filterDto.PhoneNumber == null) &&
                    (employee.IsFired == filterDto.IsFired || filterDto.IsFired == null) &&
                    (employee.Password == filterDto.Password || filterDto.Password == null) &&
                    (employee.Login == filterDto.Login || filterDto.Login == null))
                .ToListAsync();

            return new OperationResult<IEnumerable<EmployeeDto>>(result);
        }
    }
}