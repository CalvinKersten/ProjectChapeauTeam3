using ChapeauDAL;
using ChapeauModel;
using System.Collections.Generic;

namespace ChapeauService
{
    public class OrderService
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
        public int GetTableID(int orderID)
        {
            int tableID = orderdb.GetTableID(orderID);
            return tableID;
        }
        public List<Order> GetOrderForTable(int tableID)
        {
            List<Order> orderForTable = orderdb.GetOrderForTable(tableID);
            return orderForTable;
        }
        public void AddOrder(Order order)
        {
            orderdb.AddOrder(order);
        }
    }

}
