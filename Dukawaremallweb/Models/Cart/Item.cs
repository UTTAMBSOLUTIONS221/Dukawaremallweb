using Dukawaremallweb.Models.Shop;

namespace Dukawaremallweb.Models.Cart
{
    public class Item
    {
        public ShopProductDetailData? Product { get; set; }

        public int Quantity { get; set; }
    }
}
