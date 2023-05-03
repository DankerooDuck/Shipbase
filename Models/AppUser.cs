using Microsoft.AspNetCore.Identity;
namespace ShipBase.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; }
    }
}
