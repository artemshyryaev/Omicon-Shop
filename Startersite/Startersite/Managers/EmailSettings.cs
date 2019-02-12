using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Managers
{
    public class EmailSettings
    {
        public string MailToAddress = "";
        public string MailFromAddress = "omicon-shop@gmail.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 465;
        public bool WriteAsFile = true;
        public string FileLocation = @"d:\temp\mails";
    }
}