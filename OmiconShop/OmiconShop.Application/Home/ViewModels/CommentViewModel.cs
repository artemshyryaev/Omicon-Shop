using System;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OmiconShop.Application.Home.ViewModels
{
    public class CommentViewModel
    {
        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}
