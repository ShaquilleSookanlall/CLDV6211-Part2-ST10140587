
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace CLDV6211_Part2_ST10140587.Data.ViewModels
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "ProductImage")]
        [Required(ErrorMessage = "Image is required")]
        public string ProductImage { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }

        [Display(Name = "Price in R")]
        [Required(ErrorMessage = "Price is required")]
        public double ProductPrice { get; set; }

        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "Product Category is required")]
        public string ProductCategory { get; set; }

        [Display(Name = "Product Availability")]
        [Required(ErrorMessage = "The product must have an availability")]
        public string ProductAvailability { get; set; }


    }
}
