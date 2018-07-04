using System.Data.Entity;
using Smartwebs.Cookbook.Domain.Recipes;

namespace Smartwebs.Cookbook.Ef
{
    public class CookbookDbContext : DbContext
    {
        public CookbookDbContext() : base ("CookbookDbContext")
        {
            
        }

        public CookbookDbContext(string connectionString) : base(connectionString)
        {
            
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeVersion> RecipeVersions { get; set; }
    }
}