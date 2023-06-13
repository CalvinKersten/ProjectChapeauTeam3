using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ChapeauModel;


namespace ChapeauDAL
{
    public class OrderDao : BaseDao
    {
        public List<Order> GetAllOrders()
        {
            string query = "SELECT OrderID, TableID, Total_Price, EmployeeID, InvoiceID, Order_DetailID, Menu_ItemID FROM [Order]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    OrderID = (int)dr["OrderID"],
                    TableID = (int)dr["TableID"],
                    TotalPrice = (decimal)dr["Total_Price"],
                    EmployeeID = (int)dr["EmployeeID"],
                    InvoiceID = (int)dr["InvoiceID"],
                    OrderDetailID = (int)dr["Order_DetailID"],
                    MenuItemID = (int)dr["Menu_ItemID"],
                };
                orders.Add(order);
            }
            return orders;
        }



    }
}

