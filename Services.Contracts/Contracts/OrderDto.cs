using System;
using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class OrderDto: DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор заказа
        /// </summary>
        public int OrderID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор клиента
        /// </summary>
        public int ClientID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор сотрудника
        /// </summary>
        public int EmployeeID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор ТК
        /// </summary>
        public int TransportCompanyID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор адреса
        /// </summary>
        public int AddressID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор ТТН
        /// </summary>
        public string TtnID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает платежного документа
        /// </summary>
        public string PaymentDocument { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает дату заказа
        /// </summary>
        public DateTime OrderingDate { get; set; } 
        
        /// <summary>
        /// Восстанавливает или возвращает дату отгрузки
        /// </summary>
        public DateTime ShipmentDate { get; set; } 
        
        /// <summary>
        /// Восстанавливает или возвращает доставки
        /// </summary>
        public DateTime DeliveryDate { get; set; } 
        
        /// <summary>
        /// Восстанавливает или возвращает статус заказа
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает принято ли ТК
        /// </summary>
        public bool IsAcceptTransportCompany { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает принято ли клиентом
        /// </summary>
        public bool IsAcceptClient { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает примечание
        /// </summary>
        public string Extra { get; set; }
        
        
    }
}