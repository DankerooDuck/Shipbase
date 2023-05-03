using Microsoft.AspNetCore.Identity;

namespace GundamEvolutionDatabase.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FName { get; set; }
        public string? LName { get; set; }

        public string? UName { get; set; }

        public new string? Email { get; set; }

        public string? DateOfBirth { get; set; }
    }
}
