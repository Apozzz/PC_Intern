using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repositories
{
    public class PizzaSizeRepository : IPizzaSizeRepository
    {
        private readonly PizzaDbContext _context;

        public PizzaSizeRepository(PizzaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PizzaSize>> GetAllAsync()
        {
            return await _context.PizzaSizes.ToListAsync();
        }

        public async Task<PizzaSize?> GetByIdAsync(int id)
        {
            return await _context.PizzaSizes.FindAsync(id);
        }
    }
}
