using InventoryWebMvc.Data;
using InventoryWebMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventoryWebMvc.Services
{
    public class ProductService
    {
        private readonly InventoryWebMvcContext _context;

        public ProductService(InventoryWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
