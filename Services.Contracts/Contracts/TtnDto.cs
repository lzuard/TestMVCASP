using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class TtnDto: DtoBase
    {
        /// <summary>
        /// Возвращает или восстанавливает идентификатор (номер) ТТН.
        /// </summary>
        public string TtnID { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает тип ТТН
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает форму ТТН.
        /// </summary>
        public string Form { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает дату оформления.
        /// </summary>
        public string Date { get; set; } //TODO: date format
    }
}