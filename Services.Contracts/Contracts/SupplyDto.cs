using System;
using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class SupplyDto : DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор поставки
        /// </summary>
        public int SupplyID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор поставщика
        /// </summary>
        public int SupplierID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор сотрудника
        /// </summary>
        public int EmployeeID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор ТК
        /// </summary>
        public int TransportCompanyID { get; set; }

        /// <summary>
        /// Восстанавливает или возвращает идентификатор ТТН
        /// </summary>
        public string TtnID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает платежного документа
        /// </summary>
        public string PaymentDocument { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает дату поставки
        /// </summary>
        public DateTime SupplyDate { get; set; }

        /// <summary>
        /// Восстанавливает или возвращает принято ли поставка
        /// </summary>
        public bool IsAccepted { get; set; }

        /// <summary>
        /// Восстанавливает или возвращает примечание
        /// </summary>
        public string Extra { get; set; }
        
        
    }
}