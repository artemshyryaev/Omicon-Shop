using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Managers
{
    public class EmailSettings
    {
        public string MailToAddress = "";
        public string MailFromAddress = "imenivenov@gmail.com";
        public bool UseSsl = true;
        public string Password = "bcec1234567890";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
    }
}