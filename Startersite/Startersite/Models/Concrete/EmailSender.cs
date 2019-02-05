﻿using Startersite.Models.Abstract;
using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Startersite.Models.Concrete
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings emailSettings;

        public EmailSender()
        {
            emailSettings = new EmailSettings();
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