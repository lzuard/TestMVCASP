using System;

namespace Contracts.Contracts.Utilization
{
    public class UtilizationApiDto
    {
        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ТТН
        /// </summary>
        public int TtnId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает утилизатора
        /// </summary>
        public int UtilizerId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает акт утилизации
        /// </summary>
        public string UtilizationAct { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает дату отгрузки
        /// </summary>
        public DateTime ShipmentDate { get; set; }
    }
}