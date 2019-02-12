using Startersite.IManagers;
using Startersite.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Startersite.Managers
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings emailSettings;

        public EmailSender(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void SendOrderConfirmationEmail(Order order)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(
                    emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("The order was sucessfully processed!")
                    .AppendLine("----")
                    .AppendLine("Items:");

                foreach (var line in order.BasketLine)
                {
                    body.Append($"{line.ProductName}" + " " + $"{line.Qty}" + " " + $"{line.Price}" + "$");
                }

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

                MailMessage mailmessage = new MailMessage(emailSettings.MailFromAddress, emailSettings.MailToAddress,
                    "New order was sucessfully send!", body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailmessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailmessage);
            }
        }
    }
}