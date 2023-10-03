namespace backend.DTOs.Responses
{
    public class PizzaOrderResponseDto
    {
        public int Id { get; set; }
        public required string SizeName { get; set; }
        public List<string> ToppingNames { get; set; } = new List<string>();
        public decimal TotalCost { get; set; }
    }
}
