using backend.Data.Repositories;
using backend.DTOs.Requests;
using backend.Models;
using backend.Services;
using Moq;

namespace Backend_Test
{
    public class PizzaOrderServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<OrderPricingService> _pricingServiceMock;
        private PizzaOrderService _service;

        public PizzaOrderServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _pricingServiceMock = new Mock<OrderPricingService>();
            _service = new PizzaOrderService(_unitOfWorkMock.Object, _pricingServiceMock.Object);
        }

        [Fact]
        public async Task CreateOrderAsync_InvalidPizzaSize_ThrowsException()
        {
            var orderDto = new PizzaOrderRequestDto
            {
                SizeId = 1,
                ToppingIds = new List<int> { 1, 2, 3 }
            };

            _unitOfWorkMock.Setup(u => u.PizzaSizes.GetByIdAsync(It.IsAny<int>()))
                           .ReturnsAsync((PizzaSize)null);

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateOrderAsync(orderDto));
        }

        [Fact]
        public async Task CreateOrderAsync_InvalidToppings_ThrowsException()
        {
            var orderDto = new PizzaOrderRequestDto
            {
                SizeId = 1,
                ToppingIds = new List<int> { 1, 2, 3 }
            };

            _unitOfWorkMock.Setup(u => u.PizzaSizes.GetByIdAsync(It.IsAny<int>()))
                           .ReturnsAsync(new PizzaSize{ Name = "Small"});

            _unitOfWorkMock.Setup(u => u.Toppings.GetToppingsByIdsAsync((List<int>)It.IsAny<IEnumerable<int>>()))
                           .ReturnsAsync(new List<Topping> { new Topping { Name = "Chilli"}, new Topping { Name = "Pepper" }});

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateOrderAsync(orderDto));
        }

        [Fact]
        public async Task CreateOrderAsync_ValidInputs_ReturnsNewOrder()
        {
            var orderDto = new PizzaOrderRequestDto
            {
                SizeId = 1,
                ToppingIds = new List<int> { 1, 2, 3 }
            };

            var mockSize = new PizzaSize { Name = "Medium" };
            var mockToppings = new List<Topping>
            {
                new Topping { Name = "Cheese" },
                new Topping { Name = "Mushroom" },
                new Topping { Name = "Pepperoni" }
            };

            _unitOfWorkMock.Setup(u => u.PizzaSizes.GetByIdAsync(It.IsAny<int>()))
                           .ReturnsAsync(mockSize);

            _unitOfWorkMock.Setup(u => u.Toppings.GetToppingsByIdsAsync((List<int>)It.IsAny<IEnumerable<int>>()))
                           .ReturnsAsync(mockToppings);
            _unitOfWorkMock.Setup(u => u.PizzaOrders.AddAsync(It.IsAny<PizzaOrder>()))
               .Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.CompleteAsync())
                .ReturnsAsync(1);

            var result = await _service.CreateOrderAsync(orderDto);

            Assert.NotNull(result);
            Assert.Equal(3, result.Toppings.Count);
        }

        [Fact]
        public async Task CalculateOrderCostAsync_InvalidSize_ReturnsToppingsCost()
        {
            var orderDto = new PizzaPriceCalculationRequestDto
            {
                SizeId = 1,
                ToppingIds = new List<int> { 1, 2, 3 }
            };

            _unitOfWorkMock.Setup(u => u.PizzaSizes.GetByIdAsync(It.IsAny<int>()))
                           .ReturnsAsync((PizzaSize)null);
            _unitOfWorkMock.Setup(u => u.Toppings.GetToppingsByIdsAsync((List<int>)It.IsAny<IEnumerable<int>>()))
               .ReturnsAsync(new List<Topping> {
                   new Topping { Name = "Cheese" },
                   new Topping { Name = "Mushroom" },
                   new Topping { Name = "Pepperoni" }
               });

            var expectedCost = orderDto.ToppingIds.Count * 1m;
            var result = await _service.CalculateOrderCostAsync(orderDto);

            Assert.Equal(expectedCost, result);
        }

        [Fact]
        public async Task CalculateOrderCostAsync_ValidInputs_ReturnsCorrectCost()
        {
            var orderDto = new PizzaPriceCalculationRequestDto
            {
                SizeId = 1,
                ToppingIds = new List<int> { 1, 2, 3 }
            };

            var mockSize = new PizzaSize { Name = "Medium" };
            var mockToppings = new List<Topping>
            {
                new Topping { Name = "Cheese" },
                new Topping { Name = "Mushroom" },
                new Topping { Name = "Pepperoni" }
            };

            _unitOfWorkMock.Setup(u => u.PizzaSizes.GetByIdAsync(It.IsAny<int>()))
                           .ReturnsAsync(mockSize);

            _unitOfWorkMock.Setup(u => u.Toppings.GetToppingsByIdsAsync((List<int>)It.IsAny<IEnumerable<int>>()))
                           .ReturnsAsync(mockToppings);

            var result = await _service.CalculateOrderCostAsync(orderDto);

            Assert.Equal(13m, result);
        }
    }
}
