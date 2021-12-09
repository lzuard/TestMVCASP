using Contracts.Contracts.Base;

namespace Contracts.Contracts.Records
{
    public class TcRecordDto: RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор адреса.
        /// </summary>
        public int AddressId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает ИНН.
        /// </summary>
        public string IndividualTaxpayerNumber { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает имя организации.
        /// </summary>
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает расчетный счет.
        /// </summary>
        public string CheckingAccount { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер телефона.
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает электронную почту.
        /// </summary>
        public string Email { get; set; }
    }
}