using Startersite.IManagers;
using Startersite.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using Startersite.Logs;
using Startersite.ReplacementTags;

namespace Startersite.Managers
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings emailSettings;
        SmtpClient smtpClient;
        CreateLogFiles logFiles;
        ResourceReader resourceReader;

        public EmailSender(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
            smtpClient = new SmtpClient();
            logFiles = new CreateLogFiles();
            resourceReader = new ResourceReader("Startersite.Resources");
        }

        public void SendOrderConfirmationEmail(Order order)
        {
            try
            {
                var mailMessage = Render(order);
                Send(mailMessage);
            }
            catch (Exception ex)
            {
                logFiles.CreateErrorLog(ex.Message);
            }
        }

        void Send(MailMessage mailMessage)
        {
            using (smtpClient)
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(
                    emailSettings.MailFromAddress, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = SpecifyMailRoot();
                    smtpClient.EnableSsl = false;
                }

                smtpClient.Send(mailMessage);
            }
        }

        MailMessage Render(Order order)
        {
            StringBuilder body = new StringBuilder();

            body.AppendLine(resourceReader.GetResourceValueByKey("OrderConfirmation_Body"));

            emailSettings.MailToAddress = order.OrderInformation.Email ?? "temp@email.com";

            MailMessage mailmessage = new MailMessage();

            mailmessage.From = new MailAddress(emailSettings.MailFromAddress);
            mailmessage.To.Add(emailSettings.MailToAddress);
            mailmessage.Subject = "New order was sucessfully send!";
            mailmessage.Body = body.ToString();

            if (emailSettings.WriteAsFile)
                mailmessage.BodyEncoding = Encoding.UTF8;

            return mailmessage;
        }

        string SpecifyMailRoot()
        {
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, @"Mail");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}