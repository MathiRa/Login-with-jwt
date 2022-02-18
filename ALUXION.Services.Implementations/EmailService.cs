using ALUXION.Services.Interfaces;
using ALUXION.Settings;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Text;

namespace ALUXION.Services.Implementations
{
    public class EmailService : IEmailService
    {

        private readonly ALUXIONSettings _settings;

        private SendGridClient client;
        private EmailAddress from;
        public EmailService(IOptions<ALUXIONSettings> settings)
        {
            _settings = (ALUXIONSettings)settings.Value;
            client = new SendGridClient(_settings.EmailSendKey);
            from = new EmailAddress(_settings.EmailFrom, "ALUXION");
        }

        public async Task ValidateUser(string token, string mailTo)
        {
            try
            {
                string subject = "Validate User ALUXION";
                EmailAddress to = new EmailAddress(mailTo, "ALUXION");
                string htmlContent = File.ReadAllText(_settings.EmailTemplatePath + "activateUser.html");
                string link = _settings.UrlDev + "validate-user?mail=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(mailTo)) + "&token=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
                SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
                msg.AddSubstitution("-name-", mailTo);
                msg.AddSubstitution("-link-", link);

                Response response = await client.SendEmailAsync(msg).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception("Email not send");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task ResetPassword(string token, string mailTo)
        {
            try
            {
                string subject = "Reset Password ALUXION";
                EmailAddress to = new EmailAddress(mailTo, "ALUXION");
                string content = "";
                string htmlContent = System.IO.File.ReadAllText(_settings.EmailTemplatePath + "resetPassword.html");
                string link = _settings.UrlDev + "reset-password?mail=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(mailTo)) + "&token=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(token));

                SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, content, htmlContent);
                msg.AddSubstitution("-link-", link);

                Response response = await client.SendEmailAsync(msg).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception("Email not send");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
         
        }

        public async Task ConfirmPurchase(string mailTo,int quantity,decimal price)
        {
            try
            {
                string subject = "Purchase";
                EmailAddress to = new EmailAddress(mailTo, "ALUXION");
                string content = "";
                string htmlContent = System.IO.File.ReadAllText(_settings.EmailTemplatePath + "purchase.html");

                SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, content, htmlContent);
                msg.AddSubstitution("-quantity-", quantity.ToString());
                msg.AddSubstitution("-price-", price.ToString());
                msg.AddSubstitution("-total-", (quantity * price).ToString());

                Response response = await client.SendEmailAsync(msg).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception("Email not send");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
