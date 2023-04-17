using Microsoft.EntityFrameworkCore;
using Myllah_API.Models;

namespace Myllah_API.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        //public DbSet<Ingredient> Ingredients { get; set; }
        //public DbSet<Instruction> Instructions { get; set; }

    }
}
