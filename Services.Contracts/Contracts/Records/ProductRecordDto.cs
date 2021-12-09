using System.Security.Cryptography;
using Contracts.Contracts.Base;
using Contracts.Contracts.StaticObjects;

namespace Contracts.Contracts.Records
{
    public class ProductRecordDto: RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает артикул
        /// </summary>
        public int Art { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает производителя
        /// </summary>
        public string Manufacture { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает название товара
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает тип товара
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает категорию 
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает подкатегорию
        /// </summary>
        public string Subcategory { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает тип упаковки
        /// </summary>
        public ProductPackageType PackageType { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество в упаковке
        /// </summary>
        public int PackageNumber { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество на складе
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает цену за единицу
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает минимальный заказ
        /// </summary>
        public int MinimalOrder { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает вес
        /// </summary>
        public float Weight { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает высоту
        /// </summary>
        public float Height { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает ширину
        /// </summary>
        public float Width { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает длину
        /// </summary>
        public float Length { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает описание
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает уценен ли товар
        /// </summary>
        public bool IsDiscount { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает причину уценки
        /// </summary>
        public string Reason { get; set; }
    }
}