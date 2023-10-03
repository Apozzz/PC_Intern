using backend.Models;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class OrderPricingService : IOrderPricingService
    {
        public decimal CalculateOrderCost(PizzaOrder order)
        {
            decimal baseCost = GetBaseCost(order.Size);
            decimal toppingsCost = order.Toppings.Count * 1;

            decimal total = baseCost + toppingsCost;

            if (order.Toppings.Count > 3)
            {
                total *= 0.9m;  // Applying a discount for orders with more than 3 toppings
            }

            return total;
        }

        private decimal GetBaseCost(PizzaSize? size)
        {
            if (size == null)
            {
                return 0m;
            }

            switch (size.Name)
            {
                case "Small":
                    return 8m;
                case "Medium":
                    return 10m;
                case "Large":
                    return 12m;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
