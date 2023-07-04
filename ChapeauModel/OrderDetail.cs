using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int OrderDetailID { get; set; }
        public int ItemQuantity { get; set; }
        public DateTime OrderTime { get; set; }
        public Table Table { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Comment { get; set; }
        public MenuItem MenuItem { get; set; }
        public OrderDetail()
        {
            this.Table = new Table();
            this.MenuItem = new MenuItem();
        }
        public OrderDetail(int orderID, int orderDetailID, int itemQuantity, DateTime orderTime, OrderStatus orderStatus, string comment, MenuItem menuItem, Table Table)
        {
            this.OrderID = orderID;
            this.OrderDetailID = orderDetailID;
            this.ItemQuantity = itemQuantity;
            this.OrderTime = orderTime;
            this.OrderStatus = orderStatus;
            this.Comment = comment;
            this.MenuItem = menuItem;
            this.Table = Table;
        }

    }
}
