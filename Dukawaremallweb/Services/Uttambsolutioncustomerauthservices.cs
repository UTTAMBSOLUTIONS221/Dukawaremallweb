using Dukawaremallweb.Entities.Auth;
using Dukawaremallweb.Entities.Customer;
using Dukawaremallweb.Models;
using Dukawaremallweb.Models.Auth;
using Dukawaremallweb.Models.Customer;
using Dukawaremallweb.Models.Customers;
using Dukawaremallweb.Models.Shop;
using Newtonsoft.Json;
using System.Text;

namespace Dukawaremallweb.Apiservices
{
    public class Uttambsolutioncustomerauthservices
    {
        string BaseUrl = "";
        public Uttambsolutioncustomerauthservices(IConfiguration config)
        {
            BaseUrl = Util.Currenttenantbaseurlstring(config);
        }
        #region Login Customer
        public async Task<Customermodelresponce> Validatecustomer(Userloginmodel obj)
        {
            Customermodelresponce userModel = new Customermodelresponce { };
            var resp = await CUSTOMERPOSTTOAPILOGIN("/api/CustomerAuthentication/AuthenticateUttambSolutionCustomer", obj);
            if (resp.RespStatus == 0)
            {
                userModel = new Customermodelresponce
                {
                    Token = resp.Token,
                    Customermodel = resp.Customermodel,
                    RespStatus = resp.RespStatus,
                    RespMessage = resp.RespMessage,
                };
            }
            else
            {
                userModel.RespStatus = 401;
                userModel.RespMessage = "Incorrect Password!";
            }

            return userModel;
        }
        #endregion

        #region Customer Profile Data
        public async Task<Customermodeldataresponce> GetCustomerProfiledata(string Tokenbearer, long? CustomerId)
        {
            Customermodeldataresponce Customer = new Customermodeldataresponce();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/GetSystemCustomerProfiledata/" + CustomerId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Customer = JsonConvert.DeserializeObject<Customermodeldataresponce>(apiResponse);
                }
            }
            return Customer;
        }

        #endregion

        #region System Customer Data
        public async Task<IEnumerable<SystemCustomerModel>> Getsystemtenantcustomers(string Tokenbearer, int Offset, int Count)
        {
            IEnumerable<SystemCustomerModel> Customers = new List<SystemCustomerModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/GetSystemCustomerData/" + Offset + "/" + Count))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Customers = JsonConvert.DeserializeObject<IEnumerable<SystemCustomerModel>>(apiResponse);
                }
            }
            return Customers;
        }

        public async Task<Genericmodel> Unauthaddsystemcorcustomer(SystemCustomer obj)
        {
            Genericmodel resp = new Genericmodel();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + "/api/CustomerManagement/RegisterUnauthCustomerData", content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Genericmodel>(outPut);
                }
            }
            return resp;
        }
        public async Task<Genericmodel> Addsystemcorcustomer(string Tokenbearer, SystemCustomer obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/CustomerManagement/RegisterUnauthCustomerData", obj);
            return resp;
        }

        public async Task<SystemCustomer> GetSystemCustomerData(string Tokenbearer, long? CustomerId)
        {
            SystemCustomer Customer = new SystemCustomer();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/GetSystemCustomerData/" + CustomerId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Customer = JsonConvert.DeserializeObject<SystemCustomer>(apiResponse);
                }
            }
            return Customer;
        }
        public async Task<Genericmodel> Setupcustomershopdaata(string Tokenbearer, Systemcustomershop obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/CustomerManagement/Setupcustomershopdaata", obj);
            return resp;
        }


        #endregion

        #region Customer Forgot Password
        public async Task<Customermodelresponce> Forgotpasswordpost(StaffForgotPassword obj)
        {
            Customermodelresponce resp = new Customermodelresponce();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + "/api/CustomerAuthentication/Forgotuserpasswordpost", content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Customermodelresponce>(outPut);
                }
            }
            return resp;
        }
        #endregion

        #region System shop products
        public async Task<IEnumerable<StoreProductData>> Getsystemstoreproductdata(string Tokenbearer)
        {
            IEnumerable<StoreProductData> Data = new List<StoreProductData>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StoreManagement/GetUttambSolutionStoreProducts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<StoreProductData>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<Genericmodel> Addsystemshopproductdata(string Tokenbearer, Shopproducts obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/StoreManagement/CreateUttambSolutionShopProducts", obj);
            return resp;
        }
        public async Task<IEnumerable<ShopProductDetailData>> GetUttambSolutionShopProductsByShopId(string Tokenbearer, long Shopid)
        {
            IEnumerable<ShopProductDetailData> Data = new List<ShopProductDetailData>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StoreManagement/GetUttambSolutionShopProductsById/" + Shopid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<ShopProductDetailData>>(apiResponse);
                }
            }
            return Data;
        }
        public async Task<IEnumerable<ShopProductDetailData>> GetUttambSolutionShopProducts(string Tokenbearer)
        {
            IEnumerable<ShopProductDetailData> Data = new List<ShopProductDetailData>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/StoreManagement/GetUttambSolutionShopProducts"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<IEnumerable<ShopProductDetailData>>(apiResponse);
                }
            }
            return Data;
        }
        #endregion

        #region System Customer Order Details
        public async Task<Genericmodel> Createcustomerorderdetail(string Tokenbearer, Customerorderdetail obj)
        {
            var resp = await POSTTOAPI(Tokenbearer, "/api/Ordermanagement/CreateCustomerorderdetail", obj);
            return resp;
        }
        #endregion

        #region other methods
        public async Task<Genericmodel> UNAUTHPOSTTOAPI(string endpoint, dynamic obj)
        {
            Genericmodel resp = new Genericmodel();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Genericmodel>(outPut);
                }
            }
            return resp;
        }
        public async Task<Genericmodel> POSTTOAPI(string Tokenbearer, string endpoint, dynamic obj)
        {
            Genericmodel resp = new Genericmodel();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Genericmodel>(outPut);
                }
            }
            return resp;
        }
        public async Task<List<ListModel>> GetSystemDropDownData(string Tokenbearer, ListModelType listType)
        {
            List<ListModel> list = new List<ListModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/Systemdropdowns?listType=" + (int)listType))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<ListModel>>(apiResponse);
                }
            }
            return list;
        }
        public async Task<List<ListModel>> UnauthGetSystemDropDownData(ListModelType listType)
        {
            List<ListModel> list = new List<ListModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/CustomerManagement/UnauthSystemdropdowns?listType=" + (int)listType))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<ListModel>>(apiResponse);
                }
            }
            return list;
        }
        public async Task<List<ListModel>> GetSystemDropDownDataById(string Tokenbearer, ListModelType listType, long Id)
        {
            List<ListModel> list = new List<ListModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/SystemDropdown/SystemdropdownbyId?listType=" + (int)listType + "&Id=" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<ListModel>>(apiResponse);
                }
            }
            return list;
        }
        public async Task<Customermodelresponce> CUSTOMERPOSTTOAPILOGIN(string endpoint, dynamic obj)
        {
            Customermodelresponce resp = new Customermodelresponce();
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(BaseUrl + endpoint, content))
                {
                    string outPut = response.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<Customermodelresponce>(outPut);
                }
            }
            return resp;
        }
        #endregion

    }
}
