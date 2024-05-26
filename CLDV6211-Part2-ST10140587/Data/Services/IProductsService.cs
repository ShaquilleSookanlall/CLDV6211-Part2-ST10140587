
using CLDV6211_Part2_ST10140587.Data.Base;
using CLDV6211_Part2_ST10140587.Data.ViewModels;
using CLDV6211_Part2_ST10140587.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLDV6211_Part2_ST10140587.Data.Services
{
    public interface IProductsService : IEntityBaseRepository<Product>
    {
    }
}
