namespace backend.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPizzaOrderRepository PizzaOrders { get; }
        IToppingRepository Toppings { get; }
        IPizzaSizeRepository PizzaSizes { get; }

        /// <summary>
        /// Saves changes made across repositories
        /// </summary>
        /// <returns></returns>
        Task<int> CompleteAsync();
    }
}
