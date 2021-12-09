namespace Contracts.Contracts.StaticObjects
{
    public enum TtnType
    {
        /// <summary>
        /// Товарная.
        /// </summary>
        Commodity,
        
        /// <summary>
        /// Товарно-транспортная.
        /// </summary>
        CommodityAndTransport,
        
        /// <summary>
        /// Накладная на отпуск материалов на сторону.
        /// </summary>
        InvoiceIssueOfMaterials,
        
        /// <summary>
        /// Требование-накладная.
        /// </summary>
        RequirementWaybill
    }
}