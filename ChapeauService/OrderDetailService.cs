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

        public List<OrderDetail> GetAllOrderDetails()
        {
            List<OrderDetail> orderDetails = orderDetaildb.GetAllOrderDetails();
            return orderDetails;
        }
    }
}
