using Startersite.IManagers;
using Startersite.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using Startersite.Logs;

namespace Startersite.Managers
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings emailSettings;
        SmtpClient smtpClient;
        CreateLogFiles logFiles;

        public EmailSender(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
            smtpClient = new SmtpClient();
            logFiles = new CreateLogFiles();
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
            StringBuilder body = new StringBuilder()
                .AppendLine("The order was sucessfully processed!")
                .AppendLine("----")
                .AppendLine("Items:");

            foreach (var line in order.BasketLine)
                body.Append($"{line.ProductName}" + " " + $"{line.Qty}" + " " + $"{line.Price}" + "$");

            body.AppendFormat("Total value:" + $"{order.Total}")
            .AppendLine("---")
            .AppendLine("Shipping info:")
            .AppendLine(order.OrderInformation.Name)
            .AppendLine(order.OrderInformation.Surname)
            .AppendLine(order.OrderInformation.Address)
            .AppendLine(order.OrderInformation.Address2)
            .AppendLine(order.OrderInformation.City)
            .AppendLine(order.OrderInformation.Country)
            .AppendLine(order.OrderInformation.ZipCode);

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