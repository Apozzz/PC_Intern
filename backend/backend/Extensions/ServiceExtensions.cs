using backend.Data.Repositories;
using backend.Services;
using backend.Services.Interfaces;

namespace backend.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddTransient<IPizzaOrderService, PizzaOrderService>();
            services.AddTransient<IOrderPricingService, OrderPricingService>();
        }

        public static void RegisterDataLayer(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
