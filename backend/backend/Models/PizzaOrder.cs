namespace backend.Models
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public required PizzaSize? Size { get; set; }
        public ICollection<Topping> Toppings { get; set; } = new List<Topping>();
        public decimal TotalCost { get; set; }
    }
}
