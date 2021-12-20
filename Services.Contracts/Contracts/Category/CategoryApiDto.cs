namespace Contracts.Contracts.Category
{
    public class CategoryApiDto
    {
        /// <summary>
        /// Возвращает или устанавливает название категории.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор родительской категории.
        /// </summary>
        public int? ParentCategoryId { get; set; }
    }
}