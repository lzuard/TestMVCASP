using System;
using Contracts.Contracts.StaticObjects;

namespace Contracts.Contracts.Ttn
{
    public class TtnFilterDto
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор ТТН.
        /// </summary>
        public int TtnId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер ТТН.
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает тип ТТН.
        /// </summary>
        public TtnType? Type { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает форму ТТН.
        /// </summary>
        public string Form { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает дату оформления.
        /// </summary>
        public DateTime? Date { get; set; }
    }
}