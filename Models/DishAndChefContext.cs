using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class DishAndChefContext : DbContext
    {
        public DishAndChefContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Chef> Chefs { get; set; }
    }
}