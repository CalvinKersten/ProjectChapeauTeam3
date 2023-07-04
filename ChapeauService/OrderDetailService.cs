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
        public int GetItemAmount(int menuItemID)
        {
            int itemAmount = orderDetaildb.GetItemAmount(menuItemID);
            return itemAmount;
        }
        public void ChangingOrderStatus(OrderDetail order, OrderStatus OrderStatus)
        {
            orderDetaildb.ChangeOrderStatus(order, OrderStatus);
        }
        public List<Order> ReadOrdersForKitchenBar(Catagory itemCatagory, OrderStatus orderItemState)
        {
            return orderDetaildb.GetAllOrderForKitchenAndBar(itemCatagory, orderItemState);
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetaildb.AddOrderDetail(orderDetail);
        }

    }
}
