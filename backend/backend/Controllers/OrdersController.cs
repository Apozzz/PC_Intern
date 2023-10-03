using AutoMapper;
using backend.DTOs.Requests;
using backend.DTOs.Responses;
using backend.Services;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders")]
    public class OrdersController : Controller
    {
        private readonly IPizzaOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IPizzaOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(PizzaOrderRequestDto request)
        {
            var newOrder = await _orderService.CreateOrderAsync(request);
            var responseDto = _mapper.Map<PizzaOrderResponseDto>(newOrder);

            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, responseDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var responseDto = _mapper.Map<PizzaOrderResponseDto>(order);

            return Ok(responseDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderDtos = _mapper.Map<List<PizzaOrderResponseDto>>(orders);

            return Ok(orderDtos);
        }

        [HttpPost("calculate-cost")]
        public async Task<IActionResult> CalculateCost(PizzaPriceCalculationRequestDto request)
        {
            var cost = await _orderService.CalculateOrderCostAsync(request);
            return Ok(new { TotalCost = cost });
        }


        [HttpGet("available-sizes")]
        public async Task<IActionResult> GetAvailableSizes()
        {
            var sizes = await _orderService.GetAvailableSizesAsync();
            return Ok(sizes);
        }

        [HttpGet("available-toppings")]
        public async Task<IActionResult> GetAvailableToppings()
        {
            var toppings = await _orderService.GetAvailableToppingsAsync();
            var toppingDtos = _mapper.Map<List<ToppingResponseDto>>(toppings);
            return Ok(toppingDtos);
        }
    }
}
