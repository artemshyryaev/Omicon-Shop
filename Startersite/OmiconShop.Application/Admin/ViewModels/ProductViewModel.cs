using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OmiconShop.Application.Resources;

namespace OmiconShop.Application.Admin.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(ProductResources))]
        [Required(ErrorMessageResourceName = "NameValidation",
            ErrorMessageResourceType = typeof(ProductResources))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(ProductResources))]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceName = "DescriptionValidation",
            ErrorMessageResourceType = typeof(ProductResources))]
        public string Description { get; set; }

        [Display(Name = "Price", ResourceType = typeof(ProductResources))]
        [Range(0.01, double.MaxValue, ErrorMessageResourceName = "PriceValidation",
            ErrorMessageResourceType = typeof(ProductResources))]
        public int Price { get; set; }

        [Display(Name = "Type", ResourceType = typeof(ProductResources))]
        [Required(ErrorMessageResourceName = "TypeValidation",
            ErrorMessageResourceType = typeof(ProductResources))]
        public string Type { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageUrl { get; set; }
    }
}