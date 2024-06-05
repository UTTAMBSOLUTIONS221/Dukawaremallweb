namespace Dukawaremallweb.Models.Auth
{
    public class Customermodelresponce
    {
        public int RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public string? Token { get; set; }
        public Customermodeldataresponce? Customermodel { get; set; }
    }
}
