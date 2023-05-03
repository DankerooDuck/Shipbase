using Newtonsoft.Json;
using ShipBase.Infrastructure;
namespace ShipBase.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
            ?? new SessionCart();
#pragma warning disable CS8601 // Possible null reference assignment.
            cart.Session = session;
#pragma warning restore CS8601 // Possible null reference assignment.
            return cart;
        }
        [JsonIgnore]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ISession Session { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}