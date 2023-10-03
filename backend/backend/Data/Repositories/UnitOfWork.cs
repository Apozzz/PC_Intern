namespace backend.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaDbContext _context;
        private PizzaOrderRepository _pizzaOrderRepository;
        private ToppingRepository _toppingRepository;
        private PizzaSizeRepository _pizzaSizeRepository;

        public UnitOfWork(PizzaDbContext context)
        {
            _context = context;
        }

        public IPizzaOrderRepository PizzaOrders => (IPizzaOrderRepository)(_pizzaOrderRepository ??= new PizzaOrderRepository(_context));
        public IToppingRepository Toppings => _toppingRepository ??= new ToppingRepository(_context);
        public IPizzaSizeRepository PizzaSizes => _pizzaSizeRepository ??= new PizzaSizeRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
