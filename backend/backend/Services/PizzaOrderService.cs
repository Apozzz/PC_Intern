using backend.Data.Repositories;
using backend.DTOs.Requests;
using backend.Models;
using backend.Services.Interfaces;

namespace backend.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderPricingService _pricingService;

        public PizzaOrderService(IUnitOfWork unitOfWork, IOrderPricingService pricingService)
        {
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
        }

        public async Task<PizzaOrder> CreateOrderAsync(PizzaOrderRequestDto orderDto)
        {
            var size = await _unitOfWork.PizzaSizes.GetByIdAsync(orderDto.SizeId);

            if (size == null)
            {
                throw new ArgumentException("Invalid pizza size provided.");
            }

            var toppings = await _unitOfWork.Toppings.GetToppingsByIdsAsync(orderDto.ToppingIds);

            if (toppings.Count() != orderDto.ToppingIds.Count)
            {
                throw new ArgumentException("One or more invalid toppings provided.");
            }

            var newOrder = new PizzaOrder
            {
                Size = size,
                Toppings = toppings.ToList()
            };

            newOrder.TotalCost = _pricingService.CalculateOrderCost(newOrder);
            await _unitOfWork.PizzaOrders.AddAsync(newOrder);
            await _unitOfWork.CompleteAsync();

            return newOrder;
        }

        public async Task<PizzaOrder> GetOrderByIdAsync(int id)
        {
            return await _unitOfWork.PizzaOrders.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PizzaOrder>> GetAllOrdersAsync()
        {
            return await _unitOfWork.PizzaOrders.GetAllAsync();
        }

        public async Task<decimal> CalculateOrderCostAsync(PizzaPriceCalculationRequestDto orderDto)
        {
            var size = await _unitOfWork.PizzaSizes.GetByIdAsync(orderDto.SizeId);
            var toppings = await _unitOfWork.Toppings.GetToppingsByIdsAsync(orderDto.ToppingIds);

            var order = new PizzaOrder
            {
                Size = size,
                Toppings = (ICollection<Topping>)toppings
            };

            return _pricingService.CalculateOrderCost(order);
        }
        public async Task<IEnumerable<PizzaSize>> GetAvailableSizesAsync()
        {
            return await _unitOfWork.PizzaSizes.GetAllAsync();
        }

        public async Task<IEnumerable<Topping>> GetAvailableToppingsAsync()
        {
            return await _unitOfWork.Toppings.GetAllAsync();
        }

    }
}
