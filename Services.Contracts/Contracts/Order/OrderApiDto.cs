using System;
using Contracts.Contracts.StaticObjects;

namespace Contracts.Contracts.Order
{
    public class OrderApiDto
    {
        /// <summary>
        /// Возвращает или устанавливает клиента
        /// (идентификатор контрагента)
        /// </summary>
        public int ClientId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор сотрудника
        /// </summary>
        public int EmployeeId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор ТК
        /// </summary>
        public int TransportCompanyId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор адреса
        /// </summary>
        public int AddressId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор ТТН
        /// </summary>
        public int TtnId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер платежного документа
        /// </summary>
        public string PaymentDocument { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает дату заказа
        /// </summary>
        public DateTime OrderingDate { get; set; } 
        
        /// <summary>
        /// Возвращает или устанавливает дату отгрузки
        /// </summary>
        public DateTime ShipmentDate { get; set; } 
        
        /// <summary>
        /// Возвращает или устанавливает дату доставки
        /// </summary>
        public DateTime DeliveryDate { get; set; } 
        
        /// <summary>
        /// Возвращает или устанавливает статус заказа
        /// </summary>
        public OrderStatus Status { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает принято ли ТК
        /// </summary>
        public bool IsAcceptTransportCompany { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает принято ли клиентом
        /// </summary>
        public bool IsAcceptClient { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает примечание
        /// </summary>
        public string Extra { get; set; }
    }
}