using Contracts.Contracts.Product;
using Contracts.Contracts.Supply;

namespace Contracts.Contracts.ProductSupply
{
    public class ProductSupplyDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает поставки
        /// </summary>
        public SupplyDto Supply { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает товара
        /// </summary>
        public ProductDto Product{ get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество товара
        /// </summary>
        public int Quantity { get; set; }
    }
}