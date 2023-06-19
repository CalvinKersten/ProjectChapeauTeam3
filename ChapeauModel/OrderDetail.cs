using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ItemQuantity { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderStatus { get; set; } //enum
        public string Comment { get; set; }
        
    }
}
