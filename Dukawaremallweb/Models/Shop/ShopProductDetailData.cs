namespace Dukawaremallweb.Models.Shop
{
    public class ShopProductDetailData
    {
        public long Shopid { get; set; }
        public string? Shopname { get; set; }
        public string? Phonenumber { get; set; }
        public long Productid { get; set; }
        public string? Productname { get; set; }
        public string? Productdescription { get; set; }
        public decimal WProductprice { get; set; }
        public decimal RProductprice { get; set; }
        public decimal Productprice { get; set; }
        public decimal Oldproductprice { get; set; }
        public bool Ishirepurchase { get; set; }
        public decimal Depositamount { get; set; }
        public decimal Interestrate { get; set; }
        public string? Productstatus { get; set; }
        public string? Productimageurl { get; set; }
        public long Categoryid { get; set; }
        public string? Categoryname { get; set; }
        public long Subcategoryid { get; set; }
        public string? Subcategoryname { get; set; }
        public long Productbrandid { get; set; }
        public string? Productbrandname { get; set; }
        public decimal Availablestock { get; set; }
        public decimal Restockthreshold { get; set; }
        public decimal Maxstockthreshold { get; set; }
        public bool Onreorder { get; set; }
        public string? Productcode { get; set; }
    }
}
