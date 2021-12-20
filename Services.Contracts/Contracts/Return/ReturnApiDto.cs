using System;

namespace Contracts.Contracts.Return
{
    public class ReturnApiDto
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает ТТН
        /// </summary>
        public int TtnId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public int EmployeeId { get; set; }
        
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