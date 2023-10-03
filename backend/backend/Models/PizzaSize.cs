using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class PizzaSize
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}
