using backend.Models;

namespace backend.Services.Interfaces
{
    public interface IOrderPricingService
    {
        decimal CalculateOrderCost(PizzaOrder order);
    }
}
