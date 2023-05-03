using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ShipBase.Models;
using ShipBase.Models.ViewModels;
namespace ShipBase.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;
        public CartController(IProductRepository repo, Cart cartService)
    
{
        repository = repo;
        cart = cartService;
}
    public ViewResult Index(string returnUrl)
    {
        return View(new CartIndexViewModel
        {
            Cart = cart,
            ReturnUrl = returnUrl
        });
    }
    public RedirectToActionResult AddToCart(int productId, string returnUrl)
    {
            Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
                repository.DecreaseProductAmount(product, 1);
                if (product.Amount == -1)
                {
                    return RedirectToAction("Unavailable", "Home");
                }
                cart.AddItem(product, 1);
                
            }
        return RedirectToAction("Index", new { returnUrl });
    }
    [HttpPost]
    public IActionResult AddAllToCart(int[] productId, int[] quantity)
    {
        for (int i = 0; i < productId.Length; i++)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductID == productId[i]);
            if (product != null)
            {
                    repository.DecreaseProductAmount(product, quantity[i]);
                    if (product.Amount == -1)
                    {
                        return RedirectToAction("Unavailable", "Home");
                    }
                    cart.AddItem(product, quantity[i]);

                    
            }
        }

        return RedirectToAction("Index", "Cart");
    }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            
            Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            int quantity = cart.Lines.FirstOrDefault(x => x.Product.ProductID == productId)?.Quantity ?? 0;
            
            cart.RemoveLine(product);
            if (product != null)
            {
                cart.RemoveLine(product);
                repository.IncreaseProductAmount(product, quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
