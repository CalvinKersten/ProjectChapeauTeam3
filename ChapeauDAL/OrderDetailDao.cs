using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;

namespace ChapeauDAL
{
    public class OrderDetailDao : BaseDao
    {
        public List<OrderDetail> GetAllOrderDetails()
        {
            string query = "SELECT Order_DetailID, Item_Quantity, Order_Time, Order_Status, Comment FROM Order_Detail";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        
        private List<OrderDetail> ReadTables(DataTable dataTable)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderDetailID = (int)dr["Order_DetailID"],
                    ItemQuantity = (int)dr["Item_Quantity"],
                    OrderTime = (DateTime)dr["Order_Time"],
                    OrderStatus = dr["Order_Status"].ToString(),
                    Comment = dr["Comment"].ToString(),
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        /*private void SetOrderStatus()
        {
            //Use this to change the status of the order
        }*/
        private void AddComment(int orderDetailID)
        {
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2";
           
            string updateQuery = "UPDATE Order_Detail SET Comment =@comment WHERE Order_DetailID = @OrderDetailID";
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, con))
                {
                    try
                    {
                        con.Open();

                        command.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    catch
                    {
                        //error message
                    }
                }
            }
        } //Used to add added comments to the database

        public int GetItemAmount(int menuItemID)
        {
            string query = "SELECT Item_Quantity FROM Order_Detail WHERE Menu_ItemID =@MenuItemID";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2";
            int itemAmount = 0; // Default value

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@MenuItemID", menuItemID);
                    try
                    {
                        con.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                itemAmount = reader.GetInt32(0);
                            }
                        }
                    }
                    catch
                    {
                        //error message
                    }
                }
            }
            return itemAmount;
        }
    }
}
