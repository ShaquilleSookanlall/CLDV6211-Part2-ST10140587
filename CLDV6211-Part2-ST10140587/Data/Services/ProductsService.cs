
using CLDV6211_Part2_ST10140587.Data.Base;
using CLDV6211_Part2_ST10140587.Data.ViewModels;
using CLDV6211_Part2_ST10140587.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CLDV6211_Part2_ST10140587.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        public ProductsService(AppDbContext context) : base(context) { }
    }
};
