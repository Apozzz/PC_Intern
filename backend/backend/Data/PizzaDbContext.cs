using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {
        }

        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }

        public DbSet<PizzaSize> PizzaSizes { get; set; }
    }
}
