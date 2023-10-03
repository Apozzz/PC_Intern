using backend.Models;

namespace backend.Data.Repositories
{
    public interface IPizzaSizeRepository
    {
        Task<IEnumerable<PizzaSize>> GetAllAsync();
        Task<PizzaSize?> GetByIdAsync(int id);
    }
}
