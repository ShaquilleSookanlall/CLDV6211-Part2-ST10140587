using CLDV6211_Part2_ST10140587.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLDV6211_Part2_ST10140587.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
