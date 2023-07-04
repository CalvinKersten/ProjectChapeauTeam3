using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ChapeauModel;


namespace ChapeauDAL
{
    public class OrderDao : BaseDao
    { // more specific instead of retreiving all orders
        public List<Order> GetOrderForTable(int tableID)
        {
            string query = "SELECT OrderID, TableID, Total_Price, EmployeeID, InvoiceID, Order_DetailID, Menu_ItemID FROM [Order] WHERE TableID = @TableID";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2;User=SomerenTeam2;Password=ProjectT3Team2";
            List<Order> orders = new List<Order>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@TableID", tableID);

                    try
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            // Create Order object and populate its properties from the reader
                            Order order = new Order
                            {
                                OrderID = reader.GetInt32(0),
                                TableID = reader.GetInt32(1),
                                TotalPrice = reader.GetDecimal(2),
                                EmployeeID = reader.GetInt32(3),
                                InvoiceID = reader.GetInt32(4),
                                OrderDetailID = reader.GetInt32(5),
                                MenuItemID = reader.GetInt32(6)
                            };

                            orders.Add(order);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }

            return orders;
        }
        public int GetTableID(int orderID)
        {
            string query = "SELECT TableID FROM [Order] WHERE OrderID =@OrderID";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2";
            SqlConnection con = new SqlConnection(connectionString);
            int tableID = 0;

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@OrderID", orderID);
                try
                {
                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tableID = reader.GetInt32(0);
                        }
                    }
                }
                catch
                {
                    //error message
                }
            }
            return tableID;
        }
        public List<Order> GetAllOrders()
        {
            string query = "SELECT OrderID FROM Order";
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
                    OrderID = (int)dr["Order ID"],
                    //TableID = (int)dr["Table Number"],
                    //(Table)TotalPrice = (Table)dr["Total_Price"],
                };
                orders.Add(order);
            }
            return orders;
        }
        public void AddOrder(Order order)
        {
            string query = "INSERT INTO [Order] (TableID, Total_Price, EmployeeID, InvoiceID, Order_DetailID, Menu_ItemID) " +
                  "VALUES (@TableID, @TotalPrice, @EmployeeID, @InvoiceID, @OrderDetailID, @MenuItemID)";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2;User=SomerenTeam2;Password=ProjectT3Team2";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@TableID", order.TableID);
                    command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    command.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                    command.Parameters.AddWithValue("@InvoiceID", order.InvoiceID);
                    command.Parameters.AddWithValue("@OrderDetailID", order.OrderDetailID);
                    command.Parameters.AddWithValue("@MenuItemID", order.MenuItemID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }
    }
}

