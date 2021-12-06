using System.Security.Cryptography;
using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class ProductDto: DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор товара
        /// </summary>
        public int ProductID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает артикул
        /// </summary>
        public int Art { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает производителя
        /// </summary>
        public string Manufacture { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает название товара
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает тип товара
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает  категорию 
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает подкатегорию
        /// </summary>
        public string Subcategory { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает тип упаковки
        /// </summary>
        public string PackageType { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает количество в упаковке
        /// </summary>
        public int PackageNumber { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает количество на складе
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает цену за единицу
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает минимальный заказ
        /// </summary>
        public int MinimalOrder { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает вес
        /// </summary>
        public double Weight { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает высоту
        /// </summary>
        public double Height { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает ширину
        /// </summary>
        public double Width { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает длину
        /// </summary>
        public double Length { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает описание
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает уценен ли товар
        /// </summary>
        public bool IsDiscount { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает причину уценки
        /// </summary>
        public string Reason { get; set; }
    }
}