using backend.Models;
using backend.Services;

namespace Backend_Test
{
    public class OrderPricingServiceTests
    {
        private readonly OrderPricingService _service;

        public OrderPricingServiceTests()
        {
            _service = new OrderPricingService();
        }

        [Fact]
        public void CalculateOrderCost_WithNoToppings_ReturnsBaseCost()
        {
            var order = new PizzaOrder
            {
                Size = new PizzaSize { Name = "Medium" },
                Toppings = new List<Topping>()
            };

            var result = _service.CalculateOrderCost(order);

            Assert.Equal(10m, result);
        }

        [Fact]
        public void CalculateOrderCost_WithFourToppings_ApplyDiscount()
        {
            var order = new PizzaOrder
            {
                Size = new PizzaSize { Name = "Large" },
                Toppings = new List<Topping>
                {
                    new Topping { Name = "Cheese" },
                    new Topping { Name = "Pepperoni" },
                    new Topping { Name = "Mushroom" },
                    new Topping { Name = "Olives" }
                }
            };

            var result = _service.CalculateOrderCost(order);

            // Base cost (12) + 4 toppings cost (4) = 16
            // Applying 10% discount: 16 * 0.9 = 14.4
            Assert.Equal(14.4m, result);
        }

        [Fact]
        public void CalculateOrderCost_WithThreeToppings_NoDiscount()
        {
            var order = new PizzaOrder
            {
                Size = new PizzaSize { Name = "Medium" },
                Toppings = new List<Topping>
                {
                    new Topping { Name = "Cheese" },
                    new Topping { Name = "Pepperoni" },
                    new Topping { Name = "Mushroom" }
                }
            };

            var result = _service.CalculateOrderCost(order);

            // Base cost (10) + 3 toppings cost (3) = 13
            Assert.Equal(13m, result);
        }

        [Fact]
        public void CalculateOrderCost_InvalidSize_ThrowsException()
        {
            var order = new PizzaOrder
            {
                Size = new PizzaSize { Name = "ExtraLarge" }, // An unexpected size
                Toppings = new List<Topping>()
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => _service.CalculateOrderCost(order));
        }

        [Fact]
        public void CalculateOrderCost_NullSize_ReturnsToppingsCost()
        {
            var order = new PizzaOrder
            {
                Size = null,
                Toppings = new List<Topping>
                {
                    new Topping { Name = "Cheese" }
                }
            };

            var result = _service.CalculateOrderCost(order);

            // No base cost + 1 topping cost (1) = 1
            Assert.Equal(1m, result);
        }
    }
}
