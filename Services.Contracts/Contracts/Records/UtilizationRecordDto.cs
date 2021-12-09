using System;
using Contracts.Contracts.Base;

namespace Contracts.Contracts.Records
{
    public class UtilizationRecordDto: RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор сотрудника
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Возвращает или устанавливает идентификатор ТТН
        /// </summary>
        public string TtnId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает идентификатор утилизатора
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