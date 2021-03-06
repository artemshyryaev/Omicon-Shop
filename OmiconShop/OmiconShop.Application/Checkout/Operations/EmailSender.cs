﻿using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using OmiconShop.Application.Logs;
using OmiconShop.Application.ReplacementTags;
using OmiconShop.Domain.Entities;

namespace OmiconShop.Application.Checkout.Operations
{
    public class EmailSender
    {
        public EmailSettings emailSettings;
        SmtpClient smtpClient;
        ReplacementTagsProcessor replacementTagsProcessor;

        public EmailSender(EmailSettings emailSettings, SmtpClient smtpClient, 
            ReplacementTagsProcessor replacementTagsProcessor)
        {
            this.emailSettings = emailSettings;
            this.smtpClient = smtpClient;
            this.replacementTagsProcessor = replacementTagsProcessor;
        }

        public async Task SendOrderConfirmationEmail(Order order)
        {
            try
            {
                var mailMessage = Render(order);
                await SendAsync(mailMessage);
            }
            catch (Exception ex)
            {
                CreateLogFiles logFiles = new CreateLogFiles();
                await logFiles.CreateErrorLog(ex.Message);
            }
        }

        async Task SendAsync(MailMessage mailMessage)
        {
            using (smtpClient)
            {
                smtpClient.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["Email.UseSsl"]);
                smtpClient.Host = WebConfigurationManager.AppSettings["Email.ServerName"];
                smtpClient.Port = Convert.ToInt32(WebConfigurationManager.AppSettings["Email.ServerPort"]);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(
                    emailSettings.MailFromAddress, WebConfigurationManager.AppSettings["Email.Password"]);

                if (Convert.ToBoolean(WebConfigurationManager.AppSettings["Email.WriteAsFile"]))
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = SpecifyMailRoot();
                    smtpClient.EnableSsl = false;
                }

                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        MailMessage Render(Order order)
        {
            StringBuilder body = new StringBuilder();

            body.Append(replacementTagsProcessor.GetReplacedText(order));

            emailSettings.MailToAddress = order.User.Email ?? "temp@email.com";

            MailMessage mailmessage = new MailMessage();

            mailmessage.From = new MailAddress(emailSettings.MailFromAddress);
            mailmessage.To.Add(emailSettings.MailToAddress);
            mailmessage.Subject = "New order was sucessfully send!";
            mailmessage.Body = body.ToString();
            mailmessage.IsBodyHtml = true;

            if (Convert.ToBoolean(WebConfigurationManager.AppSettings["Email.WriteAsFile"]))
                mailmessage.BodyEncoding = Encoding.UTF8;

            return mailmessage;
        }

        string SpecifyMailRoot()
        {
            string path = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\Mail\\");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}