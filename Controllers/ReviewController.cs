using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ShipBase.Models;
using Microsoft.AspNetCore.Authorization;
using ShipBase.Models.ViewModels;

namespace ShipBase.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReviewController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var product = await _context.Products.FindAsync(reviewViewModel.ProductID);

                if (User == null || product == null)
                {
                    return NotFound();
                }

                var review = new Review
                {
                    ProductID = reviewViewModel.ProductID,
                    Product = product,
                    User = user,
                    PostedDate = DateTime.Now,
                    Title = reviewViewModel.Title,
                    Comment = reviewViewModel.Comment,
                    Rating = reviewViewModel.Rating,
                };
                

                _context.Add(review);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Product", new { id = reviewViewModel.ProductID });
            }
            Console.WriteLine("bugged m8");
            return View(reviewViewModel);
        }

        public IActionResult Create(int productId)
        {
            // Create a new review and set the ProductId to the passed in productId
            var reviewViewModel = new ReviewViewModel { ProductID = productId };

            return View(reviewViewModel);
        }
    }
}
