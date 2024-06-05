using Dukawaremallweb.Models.Shop;
using Newtonsoft.Json;

namespace Dukawaremallweb.Services
{
    public class Dukawaremallservices
    {
        string BaseUrl = "";
        public Dukawaremallservices(IConfiguration config)
        {
            BaseUrl = Util.Currenttenantbaseurlstring(config);
        }

        public async Task<IEnumerable<ShopProductDetailData>> GetUttambSolutionShopProducts()
        {
            IEnumerable<ShopProductDetailData> Data = new List<ShopProductDetailData>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StoreManagement/UnAuthGetUttambSolutionShopProducts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<ShopProductDetailData>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<ShopProductDetailData> Getsingleproductdatabyid(long Productid)
        {
            ShopProductDetailData Data = new ShopProductDetailData();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StoreManagement/GetUttambSolutionShopProductById/" + Productid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<ShopProductDetailData>(apiResponse);
                }
            }
            return Data;
        }


    }
}
