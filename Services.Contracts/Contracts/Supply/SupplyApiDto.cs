using System;
using System.Collections.Generic;
using Contracts.Contracts.ProductSupply;

namespace Contracts.Contracts.Supply
{
    public class SupplyApiDto
    {
        /// <summary>
        /// Возвращает или устанавливает поставщика
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ТК
        /// (идентификатор контрагента)
        /// </summary>
        public int TransportCompanyId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ТТН
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

        /// <summary>
        /// Возвращает или устанавливает список продуктов и их количесвто
        /// </summary>
        public List<ProductSupplyApiDto> SupplyProducts { get; set; } = new();
    }
}