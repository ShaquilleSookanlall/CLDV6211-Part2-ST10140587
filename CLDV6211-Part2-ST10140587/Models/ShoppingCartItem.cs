
using CLDV6211_Part2_ST10140587.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLDV6211_Part2_ST10140587.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
