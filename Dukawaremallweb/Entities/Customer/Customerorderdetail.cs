using Dukawaremallweb.Models.Cart;
using Dukawaremallweb.Models.Shop;

namespace Dukawaremallweb.Entities.Customer
{
    public class Customerorderdetail
    {
        public long Customerid { get; set; }
        public List<Item>? CartItems { get; set; }
        public long Deliveryid { get; set; }
        public decimal Orderamount { get; set; }
    }
}
