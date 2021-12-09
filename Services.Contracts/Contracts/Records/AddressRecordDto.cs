using Contracts.Contracts.Base;

namespace Contracts.Contracts.Records
{
    public class AddressRecordDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает индекс.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Возвращает или устанавливает субъект.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Возвращает или устанавливает населенный пункт.
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает улицу.
        /// </summary>
        public string Street { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер дома.
        /// </summary>
        public string House { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер строения.
        /// </summary>
        public string Building { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер корпуса.
        /// </summary>
        public string Housing { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер помещения.
        /// </summary>
        public string Room { get; set; }
    }
}