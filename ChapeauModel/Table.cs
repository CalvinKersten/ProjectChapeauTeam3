using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Table
    {
        public event EventHandler Event;

        public int TableID { get; set; }

        public int Table_Number { get; set; }

        public int Capacity { get; set;}

        public int EmployeeID { get; set; }
    }
}
