using Microsoft.AspNetCore.Mvc;
using ShipBase.Models;
namespace ShipBase.Components
{
    public class WishlistSummaryViewComponent : ViewComponent
    {
        private Wishlist wishlist;
        public WishlistSummaryViewComponent(Wishlist wishlistService)
        {
            wishlist = wishlistService;
        }
        public IViewComponentResult Invoke()
        {
            return View(wishlist);
        }
    }
}
