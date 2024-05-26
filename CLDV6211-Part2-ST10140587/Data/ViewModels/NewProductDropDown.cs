
using CLDV6211_Part2_ST10140587.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CLDV6211_Part2_ST10140587.Data.ViewModels 
{ 
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }
    }
}
