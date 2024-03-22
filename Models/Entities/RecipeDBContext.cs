using Microsoft.EntityFrameworkCore;

namespace RecipeDB.Models.Entities
{
    public class RecipeDBContext : DbContext
    {
        public RecipeDBContext(DbContextOptions<RecipeDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
