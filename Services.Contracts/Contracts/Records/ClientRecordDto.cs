using Contracts.Contracts.Base;

namespace Contracts.Contracts.Records
{
    public class ClientRecordDto: RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает идентификатор адреса.
        /// </summary>
        public int AddressId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает ИНН клиента.
        /// </summary>
        public string IndividualTaxpayerNumber { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает имя организации клиента.
        /// </summary>
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает расчетный счет клиента.
        /// </summary>
        public string CheckingAccount { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер телефона клиента.
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает электронную почту клиента.
        /// </summary>
        public string Email { get; set; }
    }
}