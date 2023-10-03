using backend.Models;

namespace backend.Data
{
    public static class PizzaDbContextExtensions
    {
        public static void Seed(this PizzaDbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            context.Toppings.AddRange(
                new Topping { Id = 1, Name = "Pepperoni" },
                new Topping { Id = 2, Name = "Mushrooms" },
                new Topping { Id = 3, Name = "Cheese" },
                new Topping { Id = 4, Name = "Spinach" }
            );

            context.PizzaSizes.AddRange(
                new PizzaSize { Id = 1, Name = "Small", Price = 8.00m },
                new PizzaSize { Id = 2, Name = "Medium", Price = 10.00m },
                new PizzaSize { Id = 3, Name = "Large", Price = 12.00m }
            );

            context.SaveChanges();
        }
    }
}
