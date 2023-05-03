using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShipBase.Models;
using ShipBase.Models.ViewModels;

namespace ShipBase.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 100;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, string searchQuery, int page = 1)
        {
            var viewModel = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => (category == null || p.Category == category))
                    .Where(p => searchQuery == null || p.Name.Contains(searchQuery))
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e =>
                        e.Category == category).Count()
                },

                CurrentCategory = category,
                SearchQuery = searchQuery
            };

            return View(viewModel);
        }
        public ViewResult Search(string searchQuery, int page = 1)
        {
            var viewModel = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => searchQuery == null || p.Name.Contains(searchQuery))
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = searchQuery == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Name.Contains(searchQuery)).Count()
                },
                SearchQuery = searchQuery
            };

            return View(viewModel);
        }


        public IActionResult Details(int id)
        {
            var product = repository.Products.FirstOrDefault(p => p.ProductID == id);
            

            if (product == null)
            {
                return NotFound();
            }

            // Pass ProductId to he Create action of the ReviewController
            ViewData["ProductId"] = id;

            var reviews = repository.Reviews.Where(repository => repository.ProductID == id).ToList();

            /*var viewModel = new ProductViewModel
            {
                Product = product,
                Reviews = reviews
            };*/

            return View(product);
        }

#pragma warning restore CS8601 // Possible null reference assignment.
    }
}
