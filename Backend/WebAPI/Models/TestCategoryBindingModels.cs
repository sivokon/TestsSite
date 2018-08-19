using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TestCategoryBindingModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Title must have max Length of 50 symbols")]
        public string Title { get; set; }
    }
}