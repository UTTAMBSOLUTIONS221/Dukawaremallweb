namespace Dukawaremallweb.Entities.Customer
{
    public class Shopproducts
    {
        public long Shopproductid { get; set; }
        public long Productid { get; set; }
        public long Shopid { get; set; }
        public decimal Productprice { get; set; }
        public bool Ishirepurchase { get; set; }
        public decimal Depositamount { get; set; }
        public decimal Interestrate { get; set; }
        public string? Productstatus { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
