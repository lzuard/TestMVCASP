using Contracts.Contracts.Employee;
using Contracts.Contracts.Product;
using Contracts.Contracts.Utilization;

namespace Contracts.Contracts.ProductUtil
{
    public class ProductUtilDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// Возвращает или устанавливает утилизации
        /// </summary>
        public UtilizationDto Utilization { get; set; }

        /// <summary>
        /// Возвращает или устанавливает товара
        /// </summary>
        public ProductDto Product { get; set; }

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