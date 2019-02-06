﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startersite.Models.Abstract
{
    public interface IEmailSender
    {
        void SendOrderConfirmationEmail(Order order);
    }
}
