using Contracts.Contracts.Base;

namespace Contracts.Contracts.Records
{
    public class ProductSupplyRecordDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор поставки
        /// </summary>
        public int SupplyId { get; set; }
        
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