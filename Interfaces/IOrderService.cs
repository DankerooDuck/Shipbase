using ShipBase.Models;
using System.Collections.Generic;

namespace ShipBase.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderById(int orderId);
        IEnumerable<Order> GetOrders();
    }
}
