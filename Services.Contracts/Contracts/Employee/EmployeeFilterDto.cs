using System;

namespace Contracts.Contracts.Employee
{
    public class EmployeeFilterDto
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор сотрудника
        /// </summary>
        public int? EmployeeId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает фамилию 
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Возвращает или устанавливает имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Возвращает или устанавливает отчество.
        /// </summary>
        public string ThirdName { get; set; }

        /// <summary>
        /// Возвращает или устанавливает дату рождения.
        /// </summary>
        public DateTimeOffset? BirthDate { get; set; }

        /// <summary>
        /// Возвращает или устанавливает номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Возвращает или устанавливает пароль.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Возвращает или устанавливает уволен ли сотрудник.
        /// </summary>
        public bool? IsFired { get; set; }
    }
}