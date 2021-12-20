using System;
using Contracts.Contracts.Agent;
using Contracts.Contracts.Employee;
using Contracts.Contracts.Ttn;

namespace Contracts.Contracts.Supply
{
    public class SupplyDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает поставщика
        /// </summary>
        public AgentDto Supplier { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public EmployeeDto Employee { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает ТК
        /// (идентификатор контрагента)
        /// </summary>
        public AgentDto TransportCompany { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ТТН
        /// </summary>
        public TtnDto Ttn { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает платежного документа
        /// </summary>
        public string PaymentDocument { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает дату поставки
        /// </summary>
        public DateTime SupplyDate { get; set; }

        /// <summary>
        /// Возвращает или устанавливает принято ли поставка
        /// </summary>
        public bool IsAccepted { get; set; }

        /// <summary>
        /// Возвращает или устанавливает примечание
        /// </summary>
        public string Extra { get; set; }
    }
}