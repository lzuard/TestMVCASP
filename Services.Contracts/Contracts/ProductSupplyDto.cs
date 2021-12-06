using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class ProductSupplyDto : DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор поставки
        /// </summary>
        public int SupplyID { get; set; }
        
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