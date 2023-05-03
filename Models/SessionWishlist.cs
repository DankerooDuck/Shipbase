using Newtonsoft.Json;
using ShipBase.Infrastructure;
namespace ShipBase.Models
{
    public class SessionWishlist : Wishlist
    {
        public static Wishlist GetWishlist(IServiceProvider services)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            SessionWishlist wishlist = session?.GetJson<SessionWishlist>("Wishlist")
            ?? new SessionWishlist();
#pragma warning disable CS8601 // Possible null reference assignment.
            wishlist.Session = session;
#pragma warning restore CS8601 // Possible null reference assignment.
            return wishlist;
        }
        [JsonIgnore]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ISession Session { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Wishlist", this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Wishlist", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Wishlist");
        }
    }
}