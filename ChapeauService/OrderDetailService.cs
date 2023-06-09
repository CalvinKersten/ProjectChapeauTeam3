using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    internal class OrderDetailService
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
    }
}
