using Dukawaremallweb.Helpers;
using Dukawaremallweb.Models;
using Dukawaremallweb.Models.Communications;
using Newtonsoft.Json;
using System.Text;

namespace Dukawaremallweb.Services
{
    public class Uttambsolutionsettingsservices
    {
        EmailSenderHelper emlsnd = new EmailSenderHelper();
        Encryptdecrypt sec = new Encryptdecrypt();
        string BaseUrl = "";
        public Uttambsolutionsettingsservices(IConfiguration config)
        {
            BaseUrl = Util.Currenttenantbaseurlstring(config);
        }
        #region Outlets
        #endregion

        #region Communications
        public async Task<Genericmodel> Sendcustomerregistrationemail(string Fullname, string Emailaddress, string Password, string PasswordHash)
        {
            Genericmodel Resp = new Genericmodel();
            var commtempdata = await GetSystemCommunicationTemplateData(true, "CustomerRegistration");
            if (commtempdata != null)
            {
                StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                StrBodyEmail.Replace("@CompanyLogo", "https://www.lenarjisse.com/images/no-image.png");
                StrBodyEmail.Replace("@CompanyName", "Uttamb Solutions");
                StrBodyEmail.Replace("@CompanyEmail", "sales@uttambsolutions.com");
                StrBodyEmail.Replace("@Fullname", Fullname);
                StrBodyEmail.Replace("@Username", Emailaddress);
                StrBodyEmail.Replace("@Password", sec.Decrypt(Password, PasswordHash));
                StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                string message = StrBodyEmail.ToString();
                bool data = emlsnd.UttambsolutionssendemailAsync(Emailaddress, commtempdata.Templatesubject, message, true);
                if (data)
                {
                    Resp.RespStatus = 0;
                    Resp.RespMessage = "Email Sent";
                }
                else
                {
                    Resp.RespStatus = 1;
                    Resp.RespMessage = "Email not Sent";
                }
            }
            else
            {
                Resp.RespStatus = 1;
                Resp.RespMessage = "Template not found!";
            }
            return Resp;
        }

        public async Task<SystemCommunicationTemplateModel> GetSystemCommunicationTemplateData(bool Isemail, string Templatename)
        {
            SystemCommunicationTemplateModel data = new SystemCommunicationTemplateModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/SettingManagement?Isemail=" + Isemail + "&Templatename=" + Templatename))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<SystemCommunicationTemplateModel>(apiResponse);
                }
            }
            return data;
        }

        #endregion

        #region Other Methods
        public async Task<List<ListModel>> GetSystemDropDownData(string Tokenbearer, ListModelType listType)
        {
            List<ListModel> list = new List<ListModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Tokenbearer);
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/SettingManagement/Systemdropdowns?listType=" + (int)listType))
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
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/SettingManagement/UnauthSystemdropdowns?listType=" + (int)listType))
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
                using (var response = await httpClient.GetAsync(BaseUrl + "/api/SettingManagement/SystemdropdownbyId?listType=" + (int)listType + "&Id=" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<ListModel>>(apiResponse);
                }
            }
            return list;
        }
        #endregion
    }
}
