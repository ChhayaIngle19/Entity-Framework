using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public PizzaSize Size { get; set; }
        public bool IsGlutenFree { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }

    public enum PizzaSize { Small, Medium, Large }
}
