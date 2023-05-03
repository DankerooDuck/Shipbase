using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GundamEvolutionDatabase.Models
{
    public class ApplicationDBContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options)
        {

        }

        public DbSet<Unit>? Units { get; set; }

        public DbSet<Ability>? Abilities { get; set; }

        public DbSet<Weapon>? Weapons { get; set; }

        public DbSet<Map>? Maps { get; set; }

        public DbSet<Season>? Seasons { get; set; }

        public DbSet<GameMode>? GameModes { get; set; }
    }
}
