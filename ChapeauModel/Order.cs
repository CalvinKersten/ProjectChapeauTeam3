using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public decimal TotalPrice { get; set; }
        public int EmployeeID { get; set; }
        public int InvoiceID { get; set; }
        public int OrderDetailID { get; set; }
        public int MenuItemID { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Table Table { get; set; }
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
        }
    }
}