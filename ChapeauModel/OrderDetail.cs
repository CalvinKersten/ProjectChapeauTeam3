using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderDetail
    {
        public int Order_DetailID { get; set; }
        public int Item_Quantity { get; set; }
        public TimeSpan Order_Time { get; set; }
      //  public enum Order_Status { get; set; }//enum
        public string Comment { get; set; }
        public MenuItem MenuItem { get; set; }

    }
}
