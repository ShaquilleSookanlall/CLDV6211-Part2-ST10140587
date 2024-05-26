using Microsoft.AspNetCore.Mvc;
using CLDV6211_Part2_ST10140587;
using CLDV6211_Part2_ST10140587.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace CLDV6211_Part2_ST10140587.Controllers
{
    public class StoreController : Controller
    {
        private readonly AppDbContext _context;

        public StoreController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allStore = await _context.Products.ToListAsync();
            return View(allStore);
        }
    }
}