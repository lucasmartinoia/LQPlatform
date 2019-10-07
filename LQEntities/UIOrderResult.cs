using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    /// <summary>
    /// Devuelve  los datos para visualizar datos del ordenes para el INOMCORE
    /// </summary>
    public class UIOrderResult
    {

        [Key]
        public int OrderID { get; set; }
        public int? OrderNumber { get; set; }
        public string BrokerID { get; set; }
        public string ChannelID { get; set; }
        public string OperatorID { get; set; }
        public string ClientID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int? MarketOrderID { get; set; }
        public string Action { get; set; }
        public DateTime LastUpdate { get; set; }
        public string ProductType { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public int? LinkOrderID { get; set; }
        public int? BackOfficeTradeID { get; set; }
        public string OrderType { get; set; }
        public string FundID { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string RescueType { get; set; }
        public decimal? Shares { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; }
        public string CustodyAccountNo { get; set; }
        public bool? Scheduled { get; set; }
        public int? OnlyMigration { get; set; }
        public string Prenote { get; set; }
        public float? ExchangeRate;
        public string OperationsStockTicket { get; set; }
        public int? ExternalReference { get; set; }
        public string FundDescription { get; set; }
        public string DescriptionOrder { get; set; }
        public string DescriptionStatus { get; set; }
        public string Link { get; set; }
        
    }
}
