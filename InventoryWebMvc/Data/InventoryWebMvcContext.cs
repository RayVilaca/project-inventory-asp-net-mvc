#nullable disable
using Microsoft.EntityFrameworkCore;
using InventoryWebMvc.Models;

namespace InventoryWebMvc.Data
{
    public class InventoryWebMvcContext : DbContext
    {
        public InventoryWebMvcContext (DbContextOptions<InventoryWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Input> Input { get; set; }

        public DbSet<Output> Output { get; set; }
    }
}
