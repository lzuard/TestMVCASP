
using Contracts.Contracts.Order;
using Contracts.Contracts.Product;

namespace Contracts.Contracts.ProductOrder
{
    public class ProductOrderDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает заказа
        /// </summary>
        public OrderDto Order { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает товара
        /// </summary>
        public ProductDto Product { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество товара
        /// </summary>
        public int Quantity { get; set; }
    }
}