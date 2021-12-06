using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class ProductUtilDto: DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор товара в утилизации
        /// </summary>
        public int ProductUtilID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор сотрудника
        /// </summary>
        public int EmployeeID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор утилизации
        /// </summary>
        public int UtilizationID { get; set; }

        /// <summary>
        /// Восстанавливает или возвращает идентификатор товара
        /// </summary>
        public int ProductID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает количество товара
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает причину утилизации
        /// </summary>
        public string Reason { get; set; }
    }
}