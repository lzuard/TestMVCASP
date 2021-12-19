namespace Contracts.Contracts.Category
{
    public class CategoryDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает название категории.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает родительской категории.
        /// </summary>
        public CategoryDto ParentCategory { get; set; }
    }
}