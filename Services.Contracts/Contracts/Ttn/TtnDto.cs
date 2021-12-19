using System;
using Contracts.Contracts.StaticObjects;

namespace Contracts.Contracts.Ttn
{
    public class TtnDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает тип ТТН.
        /// </summary>
        public TtnType Type { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает форму ТТН.
        /// </summary>
        public string Form { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает дату оформления.
        /// </summary>
        public DateTime Date { get; set; }
    }
}