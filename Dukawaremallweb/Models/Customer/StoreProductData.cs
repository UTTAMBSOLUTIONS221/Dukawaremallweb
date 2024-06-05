namespace Dukawaremallweb.Models.Customer
{
    public class StoreProductData
    {
        public long Productid { get; set; }
        public string? Productname { get; set; }
        public string? Productdescription { get; set; }
        public decimal WProductprice { get; set; }
        public decimal RProductprice { get; set; }
        public string? Productimageurl { get; set; }
        public long Categoryid { get; set; }
        public string? Categoryname { get; set; }
        public long Subcategoryid { get; set; }
        public string? Subcategoryname { get; set; }
        public long Productbrandid { get; set; }
        public string? Productbrandname { get; set; }
        public int Availablestock { get; set; }
        public int Restockthreshold { get; set; }
        public int Maxstockthreshold { get; set; }
        public bool Onreorder { get; set; }
        public string? Productcode { get; set; }
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
        public string? Createdby { get; set; }
        public string? Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
