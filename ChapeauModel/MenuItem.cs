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

        public int ItemCatagory { get; set; }

        public int Stock { get; set; }
    }
}
