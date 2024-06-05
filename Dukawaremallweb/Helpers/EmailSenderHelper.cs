using System.Net.Mail;
using System.Net;

namespace Dukawaremallweb.Helpers
{
    public class EmailSenderHelper
    {
        public bool UttambsolutionssendemailAsync(string to, string subject, string body, bool IsBodyHtml)
        {
            string senderEmail = "";
            string appPassword = "";

            MailMessage mail = new MailMessage(senderEmail, to);
            mail.IsBodyHtml = IsBodyHtml;
            mail.Subject = subject;
            mail.Body = body;

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, appPassword);

                try
                {
                    smtpClient.Send(mail);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
