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
        OrderDetailDao orderDetaildb;

        public OrderDetailService()
        {
            orderDetaildb = new OrderDetailDao();
        }

        public void ChangingOrderStatus(OrderDetail order, OrderStatus OrderStatus)
        {
            orderDetaildb.ChangeOrderStatus(order, OrderStatus);
        }

        public List<Order> ReadOrdersForKitchenBar(Catagory itemCatagory, OrderStatus orderItemState)
        {
            return orderDetaildb.GetAllOrderForKitchenAndBar(itemCatagory, orderItemState);
        }
    }
}
