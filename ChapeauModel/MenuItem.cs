using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int Menu_ItemID { get; set; }

        public string Item_Name { get; set; }

        public float Item_Price { get; set; }

        public string Item_Catagory { get; set; }

        public int Stock { get; set; }
    }
}
