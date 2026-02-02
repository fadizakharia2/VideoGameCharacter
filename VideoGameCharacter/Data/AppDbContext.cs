using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Models;

namespace VideoGameCharacter.Data
{
    // you can also use public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) if you prefer not to use generics
    public class AppDbContext : DbContext
    {
       public DbSet<Character> Characters => Set<Character>();

        // constructor to pass options to the base DbContext class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            
        }
        
    }
}
