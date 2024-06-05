using Dukawaremallweb.Helpers;
using Dukawaremallweb.Models.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Dukawaremallweb.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Item> cartItems = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View("_Cartitem", cartItems);
        }
    }
}
