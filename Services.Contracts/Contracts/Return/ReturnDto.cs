using System;
using Contracts.Contracts.Employee;
using Contracts.Contracts.Order;
using Contracts.Contracts.Ttn;

namespace Contracts.Contracts.Return
{
    public class ReturnDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор заказа
        /// </summary>
        public OrderDto Order { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает ТТН
        /// </summary>
        public TtnDto Ttn { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public EmployeeDto Employee { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает дату возврата
        /// </summary>
        public DateTime ReturnDate { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает акт возврата
        /// </summary>
        public string ReturnAct { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор заказа
        /// </summary>
        public bool IsAccepted { get; set; }
    }
}