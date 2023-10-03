using backend.Models;

namespace backend.Data.Repositories
{
    public interface IToppingRepository
    {
        Task<IEnumerable<Topping>> GetAllAsync();
        Task<IEnumerable<Topping>> GetToppingsByIdsAsync(List<int> toppingsIds);
    }
}
