using Contracts.Contracts.Base;

namespace Contracts.Contracts
{
    public class TcDto: DtoBase
    {
        /// <summary>
        /// Возвращает или восстанавливает идентификатор ТК.
        /// </summary>
        public int TransportCompanyID { get; set; }

        /// <summary>
        /// Возвращает или восстанавливает идентификатор адреса.
        /// </summary>
        public int AddressId { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает ИНН .
        /// </summary>
        public int IndividualTaxpayerNumber { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает имя организации .
        /// </summary>
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает расчетный счет .
        /// </summary>
        public string CheckingAccount { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает номер телефона .
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Возвращает или восстанавливает электронную почту .
        /// </summary>
        public string Email { get; set; }
    }
}