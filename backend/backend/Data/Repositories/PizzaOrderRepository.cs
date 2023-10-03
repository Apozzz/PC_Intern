using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories
{
    public class PizzaOrderRepository : IPizzaOrderRepository
    {
        private readonly PizzaDbContext _context;

        public PizzaOrderRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PizzaOrder order)
        {
            await _context.PizzaOrders.AddAsync(order);
        }

        public async Task<IEnumerable<PizzaOrder>> GetAllAsync()
        {
            return await _context.PizzaOrders
                .Include(o => o.Size)
                .Include(o => o.Toppings)
                .ToListAsync();
        }

        public async Task<PizzaOrder> GetByIdAsync(int id)
        {
            return await _context.PizzaOrders
                .Include(o => o.Size)
                .Include(o => o.Toppings)
                .FirstAsync(o => o.Id == id);
        }
    }
}
