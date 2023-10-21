using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace doctorly.calender.Services
{
    public class EmailService : IEmail
    {
        private string _sendGrindApiKey = "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";
        private string _sendGrindEmail = "donotreply@legends-stock.com";
        private string _sendGrindName = "Doctorly Test";

        public async Task Send(string email, string subject, string body) {

            var apiKey = _sendGrindApiKey;
            var fromName = _sendGrindName;
            var fromEmail = _sendGrindEmail;

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(email, string.Empty);
            var plainTextContent = "";
            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            try
            {
                await client.SendEmailAsync(msg).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
