using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class TableService
    {
        private TableDao tabledb;

        public TableService()
        {
            tabledb = new TableDao();
        }

        public int GetTableNumber(int tableID)
        {
            int tableNumber = tabledb.GetTableNumber(tableID);
            return tableNumber;
        }
    }
}
