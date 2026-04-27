using Microsoft.EntityFrameworkCore;
using RecipeCollection.Models;

namespace RecipeCollection.Services
{
    public class RecipeCollectionDbContext : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Recipe> Recipes => Set<Recipe>();

        private readonly string databasePath;

        public RecipeCollectionDbContext(string databasePath)
        {
            this.databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Filename={databasePath}");
    }
}
