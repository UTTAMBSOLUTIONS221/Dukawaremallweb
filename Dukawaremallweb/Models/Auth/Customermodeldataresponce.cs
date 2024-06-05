namespace Dukawaremallweb.Models.Auth
{
    public class Customermodeldataresponce
    {
        public long CustomerId { get; set; }
        public long Tenantid { get; set; }
        public long Outletid { get; set; }
        public string? Fullname { get; set; }
        public string? Emailaddress { get; set; }
        public long Phoneid { get; set; }
        public string? Phonenumber { get; set; }
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public string? IDNumber { get; set; }
        public string? Designation { get; set; }
        public string? Passwords { get; set; }
        public string? Passwordsharsh { get; set; }
        public string? CompanyAddress { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime CompanyIncorporationDate { get; set; }
        public string? CompanyRegistrationNo { get; set; }
        public string? CompanyPIN { get; set; }
        public string? CompanyVAT { get; set; }
        public DateTime Contractstartdate { get; set; }
        public DateTime Contractenddate { get; set; }
        public long StationId { get; set; }
        public long CountryId { get; set; }
        public int NoOfTransactionPerDay { get; set; }
        public decimal AmountPerDay { get; set; }
        public int ConsecutiveTransTimeMin { get; set; }
        public bool Isshop { get; set; }
        public long Shopid { get; set; }
        public string? Shopname { get; set; }
        public string? Shopphonenumber { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public bool Isverified { get; set; }
        public int Loginstatus { get; set; }
        public bool IsPortaluser { get; set; }
        public bool Changepassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? Profileimage { get; set; }
        public decimal Customerpoint { get; set; }
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
        public DateTime Lastpasswordchangedate { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
