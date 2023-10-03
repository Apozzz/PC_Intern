namespace backend.DTOs.Requests
{
    public class PizzaOrderRequestDto
    {
        public int SizeId { get; set; }
        public List<int> ToppingIds { get; set; } = new List<int>();
    }
}
