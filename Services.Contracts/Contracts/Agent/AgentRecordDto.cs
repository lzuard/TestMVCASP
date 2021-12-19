namespace Contracts.Contracts.Agent
{
    public class AgentRecordDto : RecordDtoBase
    {
        /// <summary>
        /// Возвращает или устанавливает электронную тип контрагента.
        /// </summary>
        public int TypeId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает электронную адресс контрагента.
        /// </summary>
        public int AddressId { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает имя организации контрагента.
        /// </summary>
        public string OrganizationName { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает расчетный счет контрагента.
        /// </summary>
        public string CheckingAccount { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает ИНН контрагента.
        /// </summary>
        public string IndividualTaxpayerNumber { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает номер телефона контрагента.
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Возвращает или устанавливает электронную почту контрагента.
        /// </summary>
        public string Email { get; set; }
    }
}