using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class UtilizationDto: DtoBase
    {
        /// <summary>
        /// Восстанавливает или возвращает идентификатор утилизации
        /// </summary>
        public int UtilizationID { get; set; }

        /// <summary>
        /// Восстанавливает или возвращает идентификатор сотрудника
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Восстанавливает или возвращает идентификатор ТТН
        /// </summary>
        public string TtnID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает идентификатор утилизатора
        /// </summary>
        public int UtilizerID { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает акта утилизации
        /// </summary>
        public string UtilizationAct { get; set; }
        
        /// <summary>
        /// Восстанавливает или возвращает дату отгрузки
        /// </summary>
        public string ShipmentDate { get; set; } //TODO: date type
    }
}