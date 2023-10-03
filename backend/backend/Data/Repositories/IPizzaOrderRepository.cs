using backend.Models;

namespace backend.Data.Repositories
{
    public interface IPizzaOrderRepository
    {
        Task<IEnumerable<PizzaOrder>> GetAllAsync();
        Task<PizzaOrder> GetByIdAsync(int id);
        Task AddAsync(PizzaOrder order);
    }
}
