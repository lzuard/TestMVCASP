using System;
using Contracts.Contracts.StaticObjects;

namespace Services.Infrastructure.Services.Reports
{
    public class ClientOrderListListItemDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int OrderId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string TransportCompanyName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }
        
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