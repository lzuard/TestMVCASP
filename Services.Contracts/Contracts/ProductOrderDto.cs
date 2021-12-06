using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class ProductOrderDto: DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор заказа
        /// </summary>
        public int OrderID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор товара
        /// </summary>
        public int ProductID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает количество товара
        /// </summary>
        public int Number { get; set; }
    }
}