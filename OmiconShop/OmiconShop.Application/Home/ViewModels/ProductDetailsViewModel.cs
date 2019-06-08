using System;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.Home.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }

        public CommentViewModel Comment { get; set; }
    }
}