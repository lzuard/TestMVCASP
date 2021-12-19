using System;

namespace Contracts.Contracts.Supply
{
    public class SupplyRecordDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор поставщика
        /// </summary>
        public int SupplierId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор сотрудника
        /// </summary>
        public int EmployeeId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор ТК
        /// (идентификатор контрагента)
        /// </summary>
        public int TransportCompanyId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает идентификатор ТТН
        /// </summary>
        public int TtnId { get; set; }
        
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