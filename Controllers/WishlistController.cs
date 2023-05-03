using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ShipBase.Models;
using ShipBase.Models.ViewModels;
namespace ShipBase.Controllers
{
    public class WishlistController : Controller
    {
        private IProductRepository repository;
        private Wishlist wishlist;
        public WishlistController(IProductRepository repo, Wishlist wishlistService)

        {
            repository = repo;
            wishlist = wishlistService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new WishlistIndexViewModel
            {
                Wishlist = wishlist,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToWishlist(int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                wishlist.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromWishlist(int productId,
        string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                wishlist.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
