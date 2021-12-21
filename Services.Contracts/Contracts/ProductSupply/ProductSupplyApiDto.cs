namespace Contracts.Contracts.ProductSupply
{
    public class ProductSupplyApiDto
    {
        /// <summary>
        /// Возвращает или устанавливает товара
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество товара
        /// </summary>
        public int Quantity { get; set; }
    }
}