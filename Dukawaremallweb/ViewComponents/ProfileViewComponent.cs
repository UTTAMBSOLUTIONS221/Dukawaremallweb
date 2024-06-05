using Microsoft.AspNetCore.Mvc;
using Dukawaremallweb.Apiservices;

namespace Dukawaremallweb.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly Uttambsolutioncustomerauthservices bl;
        public ProfileViewComponent(IConfiguration config)
        {
            bl = new Uttambsolutioncustomerauthservices(config);
        }
        public async Task<IViewComponentResult> InvokeAsync(string Token, long Code)
        {
            var items = await bl.GetCustomerProfiledata(Token, Code);
            return View("_Myprofile", items);
        }
    }
}
