using Contracts.Contracts.Employee;

namespace Services.Infrastructure.Utils
{
    public static class Helpers
    {
        public static string GetEmployeeFormatName(EmployeeDto employee)
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