using Dukawaremallweb.Entities.Cart;
using Dukawaremallweb.Helpers;
using Dukawaremallweb.Models;
using Dukawaremallweb.Models.Cart;
using Dukawaremallweb.Models.Shop;
using Dukawaremallweb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Dukawaremallweb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Dukawaremallservices bl;
        public HomeController(IConfiguration config)
        {
            bl = new Dukawaremallservices(config);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await bl.GetUttambSolutionShopProducts();
            return View(data);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Productdetails(long Productid)
        {
            var productdata = await bl.Getsingleproductdatabyid(Productid);
            return PartialView(productdata);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Productdetail(long Productid)
        {
            var productdata = await bl.Getsingleproductdatabyid(Productid);
            return View(productdata);
        }

        [HttpGet]
        public async Task<IActionResult> Customershop()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Flatowner()
        {

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonResult> GetUttambSolutionShopProducts(string query, int offset, int limit)
        {
            var data = await bl.GetUttambSolutionShopProducts();
            List<string> productCards = new List<string>();
            foreach (var item in data)
            {
                string productName = item.Productname.Length > 15 ? item.Productname.Substring(0, 15) + "..." : item.Productname;

                string cardHtml = $@"
                        <div class='col-xl-2 col-lg-3 col-sm-6 mb-3'>
                            <a asp-action='Productdetails' asp-controller='Home' asp-area='' asp-route-Productid='{item.Productid}' data-target='#FuelcardsystemModal' data-toggle='modal' data-backdrop='static' data-keyboard='false'>
                                <div class='card text-center h-80 m-0'>
                                    <div class='card-body'>
                                        <img class='card-img-top mb-0' src='{item.Productimageurl}' alt='Product Image {item.Productname}'>
                                        <h5 class='card-text text-sm nowrap text-nowrap mb-0'>{productName}</h5>
                                        <h5 class='card-text text-sm'>{item.Shopname}</h5>
                                        <p class='card-text text-xs mb-0'>{item.Categoryname}</p>
                                        <p class='card-text text-sm mb-0'>{item.Subcategoryname}</p>
                                        <p class='card-text text-xs text-nowrap mb-0 nowrap'><span class='text-decoration-line-through'>Ksh. {item.Oldproductprice.ToString("#,##0.00")}</span>&nbsp;&nbsp <span>Ksh. {item.Productprice.ToString("#,##0.00")}</span></p>
                                        <a href='#' class='add-to-cart btn btn-xs btn-outline-info text-info font-weight-bold text-uppercase text-center' data-productid='{item.Productid}'  data-shopid='{item.Shopid}'>Add to cart</a>
                                    </div>
                                </div>
                            </a>
                        </div>";
                productCards.Add(cardHtml);
            }

            // Split the product cards into rows with 4 columns each
            List<string> productRows = new List<string>();
            for (int i = 0; i < productCards.Count; i += 6)
            {
                productRows.Add("<div class='row'>" + string.Join("", productCards.GetRange(i, Math.Min(6, productCards.Count - i))) + "</div>");
            }

            return Json(string.Join("", productRows));
        }



        #region Shop Cart
        [AllowAnonymous]
        public async Task<JsonResult> Addtocart(Shoppingcartdata model)
        {
            ShopProductDetailData productdata = new ShopProductDetailData();
            productdata = await bl.Getsingleproductdatabyid(model.ProductId);

            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productdata, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(model.ProductId);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productdata, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return Json(new Genericmodel { RespStatus = 0, RespMessage = "Item Added" });
        }

        /// <summary>
        /// Incrementing the number of units on the cart item and counting the amount
        /// </summary>
        /// <param name="Productcode"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<JsonResult> Incrementitem(Shoppingcartdata model)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(model.ProductId);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Json(new Genericmodel { RespStatus = 0, RespMessage = "Item Added" });
        }
        /// <summary>
        /// Redecuce the number of units bought and when the unit is one we just remove the record
        /// </summary>
        /// <param name="Productcode"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<JsonResult> Decrementitem(Shoppingcartdata model)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(model.ProductId);
            if (index != -1 && cart[index].Quantity != 1)
            {
                cart[index].Quantity--;
            }
            else
            {
                cart.RemoveAt(index);
            }
            if (cart.Sum(item => item.Quantity) == 0)
            {
                HttpContext.Session.Clear();
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Json(new Genericmodel { RespStatus = 0, RespMessage = "Item Substracted" });
        }
        /// <summary>
        /// Remove item on the index from the cart
        /// </summary>
        /// <param name="Productcode"></param>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        public async Task<JsonResult> Removeitem(Shoppingcartdata model)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(model.ProductId);
            cart.RemoveAt(index);
            if (cart.Count == 0)
            {
                HttpContext.Session.Clear();
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return Json(new Genericmodel { RespStatus = 0, RespMessage = "Item Deleted" });
        }

        private int isExist(long id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Productid.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

    }
}
