using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeverageProject.Models.ViewModels
{
    public class ProductCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage = "You must select a category and a kind")]
        public string Category { get; set; }
        [Required]
        public string Kind { get; set; }
    }
}