using Dukawaremallweb.Apiservices;
using Dukawaremallweb.Apiservices.Communications;
using Dukawaremallweb.Entities.Auth;
using Dukawaremallweb.Entities.Customer;
using Dukawaremallweb.Helpers;
using Dukawaremallweb.Models.Auth;
using Dukawaremallweb.Models.Cart;
using Dukawaremallweb.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Dukawaremallweb.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly Uttambsolutioncustomerauthservices bl;
        private readonly Uttambsolutioncommunicationsservices comm;
        private readonly Uttambsolutionsettingsservices sett;
        public CustomerController(IConfiguration config)
        {
            bl = new Uttambsolutioncustomerauthservices(config);
            comm = new Uttambsolutioncommunicationsservices(config);
            sett = new Uttambsolutionsettingsservices(config);
        }
        #region User Signin
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Signinuser(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signinuser(Userloginmodel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var resp = await bl.Validatecustomer(model);
            if (resp.RespStatus == 0)
            {
                SetUserLoggedIn(resp, false);

                //if (resp.LoginStatus == (int)UserLoginStatus.VerifyAccount)
                //{
                //    return RedirectToAction("VerifyAccount", "Account", new { Usercode = resp.Userid, Phonenumber = resp.Phone });
                //}
                return RedirectToLocal(returnUrl, resp);
            }
            else if (resp.RespStatus == 401)
            {
                Warning(resp.RespMessage, true);
            }
            else
            {
                ModelState.AddModelError(string.Empty, resp.RespMessage);
            }
            return View();

        }
        #endregion


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Registersystemcustomers()
        {
            ViewData["Systemoutletslists"] = sett.UnauthGetSystemDropDownData(ListModelType.SystemOutlets).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).Where(x => x.Text == "DUKAWARE MALL").ToList();
            ViewData["Systemphonecodelists"] = sett.UnauthGetSystemDropDownData(ListModelType.SystemPhoneCodes).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Registersystemcustomers(SystemCustomer model)
        {
            var resp = await bl.Unauthaddsystemcorcustomer(model);
            if (resp.RespStatus == 0)
            {
                if (resp.Data1 == "Insert")
                {
                    await comm.Sendcustomerregistrationemail(resp.Data2, resp.Data3, resp.Data4, resp.Data5);
                }
            }
            return Json(resp);
        }
        //Setup customer shop

        [HttpGet]
        public IActionResult Setupcustomershop(long Customerid)
        {
            ViewData["Systemphonecodelists"] = sett.GetSystemDropDownData(SessionCustomerData.Token, ListModelType.SystemPhoneCodes).Result.Select(x => new SelectListItem { Text = x.Text, Value = x.Value }).ToList();
            Systemcustomershop model = new Systemcustomershop();
            model.Customerid = Customerid;
            return PartialView(model);
        }
        public async Task<JsonResult> Setupcustomershopdaata(Systemcustomershop model)
        {
            var resp = await bl.Setupcustomershopdaata(SessionCustomerData.Token, model);
            return Json(resp);
        }

        #region Forgot Password
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Forgotpassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Forgotpassword(StaffForgotPassword model)
        {
            var resp = await bl.Forgotpasswordpost(model);
            if (resp.Customermodel.CustomerId != null)
            {
                var commresp = await comm.Sendcustomerresendpasswordemail(resp.Customermodel.Fullname, resp.Customermodel.Emailaddress, resp.Customermodel.Passwords, resp.Customermodel.Passwordsharsh);
                if (commresp.RespStatus == 0)
                {
                    resp.RespStatus = 0;
                    resp.RespMessage = "Email sent";
                    return RedirectToAction("Signinuser");
                }
                else
                {
                    resp.RespStatus = 1;
                    resp.RespMessage = "Email not sent";
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, resp.RespMessage);
            }
            return View(model);

        }
        #endregion

        #region Uttamb solutions Shop Products
        [HttpGet]
        public async Task<JsonResult> Systemstoreproductdata(string query, int offset, int limit)
        {
            var data = await bl.Getsystemstoreproductdata(SessionCustomerData.Token);
            var customerdata = await bl.GetCustomerProfiledata(SessionCustomerData.Token, SessionCustomerData.Customermodel.CustomerId);
            List<string> productCards = new List<string>();

            foreach (var item in data)
            {
                string productName = item.Productname.Length > 15 ? item.Productname.Substring(0, 15) + "..." : item.Productname;

                string cardHtml = $@"
                        <div class='col-xl-3 col-lg-4 col-sm-6 mb-3'>
                            <div class='card text-center h-80 m-0'>
                                <img class='card-img-top mb-0' src='{item.Productimageurl}' alt='Product Image {item.Productname}' height='100'>
                                <div class='card-body'>
                                    <h5 class='card-title text-sm nowrap text-nowrap mb-0'>{productName}</h5>
                                    <p class='card-text text-xs mb-0'>{item.Categoryname}</p>
                                    <p class='card-text text-sm mb-0'>{item.Subcategoryname}</p>
                                    <p class='card-text text-sm mb-0'>Ksh.  {item.RProductprice.ToString("#,##0.00")}</p>
                                    {(customerdata.Isshop ? "<a href='#' class='add-to-shop btn btn-info btn-sm mb-0' data-productid='" + item.Productid + "' data-toggle='modal' data-target='#Uttambsolutionsshopproductmodal'>Add to shop</a>" : "")}
                                </div>
                            </div>
                        </div>";
                productCards.Add(cardHtml);
            }

            // Split the product cards into rows with 4 columns each
            List<string> productRows = new List<string>();
            for (int i = 0; i < productCards.Count; i += 4)
            {
                productRows.Add("<div class='row'>" + string.Join("", productCards.GetRange(i, Math.Min(4, productCards.Count - i))) + "</div>");
            }

            return Json(string.Join("", productRows));
        }


        public async Task<JsonResult> Addsystemshopproductdata(Shopproducts model)
        {
            model.Shopid = SessionCustomerData.Customermodel.Shopid;
            var Resp = await bl.Addsystemshopproductdata(SessionCustomerData.Token, model);
            return Json(Resp);
        }
        [HttpGet]
        public async Task<JsonResult> GetUttambSolutionShopProductsById(string query, int offset, int limit)
        {
            var data = await bl.GetUttambSolutionShopProductsByShopId(SessionCustomerData.Token, SessionCustomerData.Customermodel.Shopid);
            List<string> productCards = new List<string>();
            foreach (var item in data)
            {
                string productName = item.Productname.Length > 15 ? item.Productname.Substring(0, 15) + "..." : item.Productname;

                string cardHtml = $@"
                        <div class='col-xl-4 col-lg-5 col-sm-10 mb-3'>
                            <div class='card text-center h-80 m-0'>
                                <img class='card-img-top mb-0' src='{item.Productimageurl}' alt='Product Image {item.Productname}' height='100'>
                                <div class='card-body'>
                                    <h5 class='card-title text-sm nowrap text-nowrap mb-0'>{productName}</h5>
                                    <p class='card-text text-xs mb-0'>{item.Categoryname}</p>
                                    <p class='card-text text-sm mb-0'>{item.Subcategoryname}</p>
                                    <p class='card-text text-sm mb-0'>Ksh.  {item.Productprice.ToString("#,##0.00")}</p>
                                    <a href='#' class='add-to-shop btn btn-info btn-sm mb-0' data-productid='{item.Productid}' data-toggle='modal' data-target='#Uttambsolutionsshopproductmodal'>Edit</a>
                                </div>
                            </div>
                        </div>";
                productCards.Add(cardHtml);
            }

            // Split the product cards into rows with 4 columns each
            List<string> productRows = new List<string>();
            for (int i = 0; i < productCards.Count; i += 3)
            {
                productRows.Add("<div class='row'>" + string.Join("", productCards.GetRange(i, Math.Min(3, productCards.Count - i))) + "</div>");
            }

            return Json(string.Join("", productRows));
        }

        [HttpGet]
        public async Task<JsonResult> GetUttambSolutionShopProductsDataById(string query, int offset, int limit)
        {
            var data = await bl.GetUttambSolutionShopProductsByShopId(SessionCustomerData.Token, SessionCustomerData.Customermodel.Shopid);
            List<string> productCards = new List<string>();
            foreach (var item in data)
            {
                string productName = item.Productname.Length > 15 ? item.Productname.Substring(0, 15) + "..." : item.Productname;

                string cardHtml = $@"
                        <div class='col-xl-2 col-lg-3 col-sm-6 mb-3'>
                            <div class='card text-center h-80 m-0'>
                                <img class='card-img-top mb-0' src='{item.Productimageurl}' alt='Product Image {item.Productname}' height='100'>
                                <div class='card-body'>
                                    <h5 class='card-title text-sm nowrap text-nowrap mb-0'>{productName}</h5>
                                    <p class='card-text text-xs mb-0'>{item.Categoryname}</p>
                                    <p class='card-text text-sm mb-0'>{item.Subcategoryname}</p>
                                    <p class='card-text text-sm mb-0'>Ksh.  {item.Productprice.ToString("#,##0.00")}</p>
                                    <a href='#' class='add-to-shop btn btn-info btn-sm mb-0' data-productid='{item.Productid}' data-toggle='modal' data-target='#Uttambsolutionsshopproductmodal'>Edit</a>
                               </div>
                            </div>
                        </div>";
                productCards.Add(cardHtml);
            }

            // Split the product cards into rows with 4 columns each
            List<string> productRows = new List<string>();
            for (int i = 0; i < productCards.Count; i += 4)
            {
                productRows.Add("<div class='row'>" + string.Join("", productCards.GetRange(i, Math.Min(4, productCards.Count - i))) + "</div>");
            }

            return Json(string.Join("", productRows));
        }


        [HttpGet]
        public async Task<JsonResult> GetUttambSolutionShopProducts(string query, int offset, int limit)
        {
            var data = await bl.GetUttambSolutionShopProducts(SessionCustomerData.Token);
            return Json(data);
        }
        #endregion

        #region Customers Shop
        [HttpGet]
        public IActionResult Myshopdata()
        {
            return View();
        }
        #endregion

        #region Customers Cart
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Customercart()
        {
            List<Item> cartItems = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View(cartItems);
        }
        #endregion

        #region Customers Checkout
        [HttpGet]
        public IActionResult Customercheckout()
        {
            List<Item> cartItems = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View(cartItems);
        }
        public async Task<JsonResult> Confirmcustomercheckout(long Deliveryid)
        {
            Customerorderdetail model = new Customerorderdetail();
            model.Deliveryid = Deliveryid;
            model.Customerid = SessionCustomerData.Customermodel.CustomerId;
            model.Orderamount = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart").Sum(x => x.Product.Productprice * x.Quantity);
            model.CartItems = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            List<Item> cartItems = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            var Resp = await bl.Createcustomerorderdetail(SessionCustomerData.Token, model);
            return Json(Resp);
        }

        [HttpGet]
        public IActionResult Customerorderdetail(long Orderid)
        {
            return View();
        }
        #endregion

        #region Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion


        #region Other Methods

        private async void SetUserLoggedIn(Customermodelresponce user, bool rememberMe)
        {
            string userData = JsonConvert.SerializeObject(user);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Customermodel.CustomerId.ToString()),
                new Claim(ClaimTypes.Name, user.Customermodel.Fullname),
                new Claim("FullNames", user.Customermodel.Fullname),
                new Claim("Token", user.Token),
                new Claim("userData", userData),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = new DateTimeOffset?(DateTime.UtcNow.AddMinutes(30))
            });
        }
        private IActionResult RedirectToLocal(string returnUrl, Customermodelresponce customer)
        {
            if (customer.Customermodel.Designation == "Shopowner")
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(HomeController.Customershop), "Home", new { area = "" });
                }
            }
            else
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(HomeController.Flatowner), "Home", new { area = "" });
                }
            }
        }
        #endregion
    }
}
