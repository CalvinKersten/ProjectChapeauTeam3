using ChapeauDAL;
using ChapeauModel;
using System.Collections.Generic;

namespace ChapeauService
{
    internal class OrderService
    {
        private OrderDao orderdb;

        public OrderService()
        {
            orderdb = new OrderDao();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = orderdb.GetAllOrders();
            return orders;
        }
    }

}
