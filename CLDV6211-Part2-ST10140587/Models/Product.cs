using CLDV6211_Part2_ST10140587.Data.Base;
using CLDV6211_Part2_ST10140587.Data.Enums;
using System.ComponentModel.DataAnnotations;


namespace CLDV6211_Part2_ST10140587.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Full name is required")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "Product requires a price")]
        public double ProductPrice { get; set; }

        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "The product should have a category")]
        public ProductCategory ProductCategory { get; set; }

        [Display(Name = "Product Availability")]
        [Required(ErrorMessage = "The product should have an availability")]
        public string ProductAvailability { get; set; }

        [Display(Name = "Product Image URL")]
        [Required(ErrorMessage = "Profile picture required")]
        public string ProductImage { get; set; }
    }
}