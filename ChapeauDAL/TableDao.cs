using System;
using ChapeauModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class TableDao : BaseDao
    {
        public List<Table> GetAllTables()
        {
            string query = "SELECT TableID, Table_Num, Capacity FROM [Table]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Table> GetAllTableNumbers()
        {
            string query = "SELECT Table_Num FROM [Table]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableNumber(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Table> ReadTableNumber(DataTable dataTable)
        {
            List<Table> tableNumber = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table()
                {
                    Table_Num = (int)dr["Table_Num"]
                };
                tableNumber.Add(table);
            }
            return tableNumber;
        }
        private List<Table> ReadTables(DataTable dataTable)
        {
            List<Table> tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table()
                {
                    TableID = (int)dr["TableID"],
                    Table_Num = (int)dr["Table_Num"],
                    Capacity = (int)dr["Capacity"],
                };
                tables.Add(table);
            }
            return tables;
        }
    }
}
