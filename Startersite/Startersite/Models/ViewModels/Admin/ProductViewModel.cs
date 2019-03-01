using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Models.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter valid name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Enter valid description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Enter valid price")]
        public int Price { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Enter valid type")]
        public string Type { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageUrl { get; set; }
    }
}