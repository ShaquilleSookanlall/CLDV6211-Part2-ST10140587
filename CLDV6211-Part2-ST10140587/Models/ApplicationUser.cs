
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CLDV6211_Part2_ST10140587.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
