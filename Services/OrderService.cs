using Microsoft.EntityFrameworkCore;
using ShipBase.Interfaces;
using ShipBase.Models;
using System;

namespace ShipBase.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.OrderID == orderId);
        }
        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }
    }
}
