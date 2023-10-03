using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly PizzaDbContext _context;

        public ToppingRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topping>> GetAllAsync()
        {
            return await _context.Toppings.ToListAsync();
        }

        public async Task<IEnumerable<Topping>> GetToppingsByIdsAsync(List<int> toppingsIds)
        {
            return await _context.Toppings.Where(t => toppingsIds.Contains(t.Id)).ToListAsync();
        }
    }
}
