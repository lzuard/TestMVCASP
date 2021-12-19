using System;
using Contracts.Contracts.Agent;
using Contracts.Contracts.Employee;
using Contracts.Contracts.Ttn;

namespace Contracts.Contracts.Utilization
{
    public class UtilizationDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает сотрудника
        /// </summary>
        public EmployeeDto Employee { get; set; }

        /// <summary>
        /// Возвращает или устанавливает ТТН
        /// </summary>
        public TtnDto Ttn { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает утилизатора
        /// </summary>
        public AgentDto Utilizer { get; set; }
        
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