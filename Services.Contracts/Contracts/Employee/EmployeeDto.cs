using System;

namespace Contracts.Contracts.Employee
{
    public class EmployeeDto : RecordDtoBase
    {
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
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Возвращает или устанавливает номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Возвращает или устанавливает пароль.
        /// </summary>
        public long Password { get; set; }


        /// <summary>
        /// Возвращает или устанавливает логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Возвращает или устанавливает уволен ли сотрудник.
        /// </summary>
        public bool IsFired { get; set; }
    }
}