using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int MenuItemID { get; set; }

        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
        public Catagory ItemCatagory { get; set; }
        public int Stock { get; set; }
    }
    public enum Catagory { Food = 1, NonAlcDrink, AlcDrink }
}
