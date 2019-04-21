﻿using Startersite.IManagers;
using Startersite.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class FacetController : Controller
    {
        IProductRepositoryы productRepo;

        public FacetController(IProductRepositoryы productRepo)
        {
            this.productRepo = productRepo;
        }    

        [ChildActionOnly]
        public ActionResult Types(string selectedType = null)
        {
            ViewBag.Type = selectedType;
            IEnumerable<string> types = productRepo.Products.Select(p => p.Type).Distinct().OrderBy(x => x).ToList();

            return View(types);
        }
    }
}