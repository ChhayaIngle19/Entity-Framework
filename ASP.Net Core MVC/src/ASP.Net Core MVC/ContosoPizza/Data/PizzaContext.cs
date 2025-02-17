using Microsoft.EntityFrameworkCore;
namespace ContosoPizza.Data
{
    public class PizzaContext : DbContext
    {
        // Add a constructor that accepts DbContextOptions
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
        }
        public DbSet<ContosoPizza.Models.Pizza>? Pizzas { get; set; }

    }
}
