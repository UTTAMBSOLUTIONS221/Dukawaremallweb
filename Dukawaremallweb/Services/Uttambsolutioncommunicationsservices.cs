using Dukawaremallweb.Helpers;
using Dukawaremallweb.Models;
using Dukawaremallweb.Models.Communications;
using Dukawaremallweb.Services;
using Newtonsoft.Json;
using System.Text;

namespace Dukawaremallweb.Apiservices.Communications
{
    public class Uttambsolutioncommunicationsservices
    {
        EmailSenderHelper emlsnd = new EmailSenderHelper();
        Encryptdecrypt sec = new Encryptdecrypt();
        Uttambsolutionsettingsservices comm;
        string BaseUrl = "";
        public Uttambsolutioncommunicationsservices(IConfiguration config)
        {
            BaseUrl = Util.Currenttenantbaseurlstring(config);
            comm = new Uttambsolutionsettingsservices(config);
        }

        public async Task<Genericmodel> Sendcustomerregistrationemail(string Fullname, string Emailaddress,string Password,string PasswordHash)
        {
            Genericmodel Resp = new Genericmodel();
            var commtempdata = await comm.GetSystemCommunicationTemplateData(true, "CustomerRegistration");
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
        public async Task<Genericmodel> Sendcustomerresendpasswordemail(string Fullname, string Emailaddress, string Password, string PasswordHash)
        {
            Genericmodel model = new Genericmodel();
            var commtempdata = await comm.GetSystemCommunicationTemplateData(true, "Forgotpasswords");
            if (commtempdata != null)
            {
                StringBuilder StrBodyEmail = new StringBuilder(commtempdata.Templatebody);
                StrBodyEmail.Replace("@CompanyLogo", commtempdata.Modulelogo);
                StrBodyEmail.Replace("@CompanyName", commtempdata.Module);
                StrBodyEmail.Replace("@CompanyEmail", commtempdata.Moduleemail);
                StrBodyEmail.Replace("@Fullname", Fullname);
                StrBodyEmail.Replace("@Username", Emailaddress);
                StrBodyEmail.Replace("@Password", sec.Decrypt(Password, PasswordHash));
                StrBodyEmail.Replace("@CurrentYear", DateTime.Now.Year.ToString());
                string message = StrBodyEmail.ToString();
                bool data = emlsnd.UttambsolutionssendemailAsync(Emailaddress, commtempdata.Templatesubject, message, true);
                if (data)
                {
                    model.RespStatus = 0;
                    model.RespMessage = "Email Sent";
                }
                else
                {
                    model.RespStatus = 1;
                    model.RespMessage = "Email not Sent";
                }
            }
            else
            {
                model.RespStatus = 1;
                model.RespMessage = "Template not found!";
            }
            return model;
        }
    }
}
