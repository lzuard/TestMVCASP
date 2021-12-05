using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class ClientDto: DtoBase
    {
        /// <summary>
        /// Возвращает или восстанавливает идентификатор адреса.
        /// </summary>
        public int AddressId { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает ИНН клиента.
        /// </summary>
        public int IndividualTaxpayerNumber { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает имя организации клиента.
        /// </summary>
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает расчетный счет клиента.
        /// </summary>
        public string CheckingAccount { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает номер телефона клиента.
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает электронную почту клиента.
        /// </summary>
        public string Email { get; set; }
    }
}