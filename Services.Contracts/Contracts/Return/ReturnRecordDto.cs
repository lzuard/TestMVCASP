using System;

namespace Contracts.Contracts.Records
{
    public class ReturnRecordDto: RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор возврата
        /// </summary>
        public int ReturnId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор ТТН
        /// </summary>
        public int TtnId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор сотрудника
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