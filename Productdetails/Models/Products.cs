using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Productdetails.Models
{
    public class Products
    {
        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "PrdouctID required")]
        [DataType(DataType.Text)]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "PrdouctName required")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Display(Name = "Rate")]
        [Required(ErrorMessage = "Rate required")]
        [DataType(DataType.Text)]
        public decimal Rate { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description required")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Display(Name = "CategoryName")]
        [Required(ErrorMessage = "CategoryName required")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

    }
}