using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class ReturnDto: DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор возврата
        /// </summary>
        public int ReturnID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор заказа
        /// </summary>
        public int OrderID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор ТТН
        /// </summary>
        public string TtnID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор Сотрудника
        /// </summary>
        public int EmployeeID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает дату возврата
        /// </summary>
        public string ReturnDate { get; set; } //TODO: date type
        
        /// <summary>
        /// Восстанавливает или возвращает акт возврата
        /// </summary>
        public string ReturnAct { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор заказа
        /// </summary>
        public bool IsAccepted { get; set; }
    }
}