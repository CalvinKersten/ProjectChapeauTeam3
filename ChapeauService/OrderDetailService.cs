using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class OrderDetailService
    {
        private OrderDetailDao orderDetaildb;

        public OrderDetailService()
        {
            orderDetaildb = new OrderDetailDao();
        }

        public List<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> orderDetails = orderDetaildb.GetAllOrderDetails();
            return orderDetails;
        }

        public List<OrderDetail> RunningOrders()
        {
            List<OrderDetail> orderDetails = orderDetaildb.GetRunningOrders();
            return orderDetails;
        }
        public List<OrderDetail> CompletedOrders()
        {
            List<OrderDetail> orderDetails = orderDetaildb.GetCompletedOrders();
            return orderDetails;
        }

        public List<OrderDetail> KitchenOrders()
        {
            List<OrderDetail> orderDetails = orderDetaildb.GetKitchenOrder();
            return orderDetails;
        }

        public void ChangeOrderStatus(OrderStatus status, List<OrderDetail> orderDetails)
        {
            orderDetaildb.ChangeOrderStatus(status, orderDetails);
        }
       
    }
}
