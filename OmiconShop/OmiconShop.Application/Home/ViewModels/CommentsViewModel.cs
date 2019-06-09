using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Home.ViewModels
{
    public class CommentsViewModel
    {
        [Display(Name = "Enter your comment")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}
