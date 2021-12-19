namespace Contracts.Contracts.ProductUtil
{
    public class ProductUtilRecordDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор товара в утилизации
        /// </summary>
        public int ProductUtilId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор сотрудника
        /// </summary>
        public int EmployeeId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор утилизации
        /// </summary>
        public int UtilizationId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает идентификатор товара
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает количество товара
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает причину утилизации
        /// </summary>
        public string Reason { get; set; }
    }
}