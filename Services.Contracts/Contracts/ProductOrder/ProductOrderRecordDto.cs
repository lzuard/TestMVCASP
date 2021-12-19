
namespace Contracts.Contracts.ProductOrder
{
    public class ProductOrderRecordDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор товара
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество товара
        /// </summary>
        public int Quantity { get; set; }
    }
}