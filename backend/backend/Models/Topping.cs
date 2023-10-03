namespace backend.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();

    }
}
