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
    }
}
