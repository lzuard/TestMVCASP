using Contracts.Contracts.Category;
using Contracts.Contracts.StaticObjects;

namespace Services.Infrastructure.Services.Reports
{
    public class CostOrderAndProductListListItemDto
    {
        /// <summary>
        /// Возвращает или устанавливает артикул
        /// </summary>
        public int ProductArt { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает производителя
        /// </summary>
        public string Manufacture { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает название товара
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает тип упаковки
        /// </summary>
        public ProductPackageType PackageType { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает категорию 
        /// </summary>
        public CategoryDto Category { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество на складе
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает цену за единицу
        /// </summary>
        public decimal Price { get; set; }
    }
}