using AutoMapper;
using backend.Controllers;
using backend.DTOs.Responses;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Backend_Test
{
    public class OrdersControllerTests
    {
        private OrdersController _controller;
        private Mock<IPizzaOrderService> _orderServiceMock;
        private Mock<IMapper> _mapperMock;

        public OrdersControllerTests()
        {
            _orderServiceMock = new Mock<IPizzaOrderService>();
            _mapperMock = new Mock<IMapper>();

            _controller = new OrdersController(_orderServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetOrderById_ValidId_ReturnsOkResultWithOrder()
        {
            int testOrderId = 1;
            var testOrder = new PizzaOrder
            {
                Id = testOrderId,
                Size = new PizzaSize { Name = "Medium" },
                Toppings = new List<Topping>
                {
                    new Topping { Name = "Cheese" },
                    new Topping { Name = "Pepperoni" }
                },
                TotalCost = 14.5m
            };

            var expectedResponseDto = new PizzaOrderResponseDto
            {
                Id = testOrderId,
                SizeName = "Medium",
                ToppingNames = new List<string> { "Cheese", "Pepperoni" },
                TotalCost = 14.5m
            };

            _orderServiceMock.Setup(s => s.GetOrderByIdAsync(testOrderId))
                             .ReturnsAsync(testOrder);

            _mapperMock.Setup(m => m.Map<PizzaOrderResponseDto>(testOrder))
                       .Returns(expectedResponseDto);

            var result = await _controller.GetOrderById(testOrderId);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PizzaOrderResponseDto>(okResult.Value);
            Assert.Equal(expectedResponseDto.Id, returnValue.Id);
            Assert.Equal(expectedResponseDto.SizeName, returnValue.SizeName);
            Assert.Equal(expectedResponseDto.TotalCost, returnValue.TotalCost);
            Assert.True(expectedResponseDto.ToppingNames.All(t => returnValue.ToppingNames.Contains(t)));
        }
    }
}
