using backend.DTOs.Requests;
using backend.Models;

namespace backend.Services.Interfaces
{
    public interface IPizzaOrderService
    {
        Task<PizzaOrder> CreateOrderAsync(PizzaOrderRequestDto orderDto);
        Task<PizzaOrder> GetOrderByIdAsync(int id);
        Task<IEnumerable<PizzaOrder>> GetAllOrdersAsync();
        Task<decimal> CalculateOrderCostAsync(PizzaPriceCalculationRequestDto orderDto);
        Task<IEnumerable<PizzaSize>> GetAvailableSizesAsync();
        Task<IEnumerable<Topping>> GetAvailableToppingsAsync();
    }
}
