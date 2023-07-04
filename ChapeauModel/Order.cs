using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public List<OrderDetail> orderDetails { get; set; }

        public OrderDetail OrderDetail { get; set; }
        public int OrderID { get; set; }

        public Table Table { get; set; }
       // public int TableID { get; set; }
       public Order()
        {
            OrderDetail = new OrderDetail();
            orderDetails = new List<OrderDetail>();
            Table = new Table();
        }

        public Order(List<OrderDetail> orderDetails, int OrderID, DateTime Time, Table Table)
        {
            this.orderDetails = orderDetails;
            this.OrderID = OrderID;
            this.Table = Table;
           // this.TableID = TableID;
        }
    }
}
