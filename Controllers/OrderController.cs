using Microsoft.AspNetCore.Mvc;
using ShipBase.Models;
using Microsoft.AspNetCore.Authorization;
using ShipBase.Interfaces;
using ShipBase.Services;

namespace ShipBase.Controllers

{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View(new Order());
        private IOrderRepository repository;
        private Cart cart;
        private IOrderService _orderService;
        public OrderController(IOrderRepository repoService, Cart cartService, IOrderService orderService)
        {
            repository = repoService;
            cart = cartService;
            _orderService = orderService;
        }

        [Authorize(Roles = "Admin")]
        public ViewResult List() => View(repository.Orders.Where(o => !o.Shipped));

        public IActionResult Index()
        {
            return View(repository.Orders);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult MarkShipped(int orderID)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Order order = repository.Orders.FirstOrDefault(o => o.OrderID == orderID);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray(); repository.SaveOrder(order); cart.Clear();
                ViewBag.Order = order;
                return View("Completed");
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
        public IActionResult Check(int orderId)
        {
            //var order = _orderService.GetOrderById(orderId);
            Order order = repository.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        public IActionResult Input()
        {
            return View();
        }
    }
}