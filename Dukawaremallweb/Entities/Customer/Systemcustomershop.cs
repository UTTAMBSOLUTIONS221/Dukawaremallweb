namespace Dukawaremallweb.Entities.Customer
{
    public class Systemcustomershop
    {
        public long Shopid { get; set; }
        public long Customerid { get; set; }
        public string? Shopname { get; set; }
        public long Phoneid { get; set; }
        public string? Shopphone { get; set; }
        public bool Isverified { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
