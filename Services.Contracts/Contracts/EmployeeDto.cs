using System;
using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class EmployeeDto: DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает фамилию 
        /// </summary>
        public string SecondName { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает имя
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает отчество
        /// </summary>
        public string ThirdName { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает дату рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает пароль
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает уволен ли сотрудник
        /// </summary>
        public bool IsFired { get; set; }
    }
}