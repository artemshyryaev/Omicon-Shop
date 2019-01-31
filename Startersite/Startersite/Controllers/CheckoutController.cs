using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult ShippingInformationStep()
        {
            return View(new ShippingInformationModel());
        }
    }
}