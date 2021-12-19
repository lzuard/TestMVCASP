using System;
using Contracts.Contracts.Address;
using Contracts.Contracts.Agent;
using Contracts.Contracts.Employee;
using Contracts.Contracts.StaticObjects;
using Contracts.Contracts.Ttn;

namespace Contracts.Contracts.Order
{
    public class OrderDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает клиента
        /// (идентификатор контрагента)
        /// </summary>
        public AgentDto Client { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public EmployeeDto Employee { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор ТК
        /// </summary>
        public AgentDto TransportCompany { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор адреса
        /// </summary>
        public AddressDto Address { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор ТТН
        /// </summary>
        public TtnDto Ttn { get; set; }
        
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