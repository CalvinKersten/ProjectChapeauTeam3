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
        private MenuItemDao menuItemDao;
        public OrderDetailDao()
        {
            menuItemDao = new MenuItemDao();
        }
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
                    OrderStatus = (OrderStatus)dr["Order_Status"],
                    Comment = dr["Comment"].ToString(),
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
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
        public List<Order> GetAllOrderForKitchenAndBar(Catagory itemCatagory, OrderStatus orderItemState)
        {
            string query = "SELECT od.Order_DetailID, o.TableID, m.Item_Name, od.Item_Quantity, od.Order_Status, od.Order_Time, od.Comment" +
                       "FROM Order_Detail AS od " +
                       "JOIN [Order] AS o ON o.Order_DetailID = od.Order_DetailID " +
                       "JOIN Menu_Item AS m ON m.Menu_ItemID = o.Menu_ItemID " +
                       "WHERE m.Item_Catagory = @itemCatagory AND od.Order_Status = @orderItemState";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@itemCatagory", (int)itemCatagory);
            sqlParameters[1] = new SqlParameter("@orderItemState", (int)orderItemState);
            return ReadOrdersForKitchenBar(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Order> ReadOrdersForKitchenBar(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();
            if (dataTable != null)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    Order order = new Order();

                    order.OrderDetail.OrderDetailID = (int)dr["Order_DetailID"];
                    order.Table.TableNumber = (int)dr["TableID"];
                    order.OrderDetail.MenuItem.ItemName = dr["Item_Name"].ToString();
                    order.OrderDetail.ItemQuantity = (int)dr["Item_Quantity"];
                    order.OrderDetail.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), dr["Order_Status"].ToString());
                    // order.OrderDetail.OrderStatus = (OrderStatus)dr["Order_Status"];
                    order.OrderDetail.OrderTime = (DateTime)dr["Order_Time"];
                    order.OrderDetail.Comment = dr["Comment"].ToString();
                    orders.Add(order);
                }
            }
            return orders;
        }
        public void ChangeOrderStatus(OrderDetail order, OrderStatus OrderStatus)
        {
            string query = "UPDATE [Order_Detail] SET Order_Status =@Order_Status WHERE Order_DetailID=@id";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@id", order.OrderDetailID);
            sqlParameters[1] = new SqlParameter("@Order_Status", (int)OrderStatus);
            ExecuteEditQuery(query, sqlParameters);
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            string query = "INSERT INTO Order_Detail (Item_Quantity, Order_Time, Order_Status, Comment) VALUES (@ItemQuantity, @OrderTime, @OrderStatus, @Comment)";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2;User=SomerenTeam2;Password=ProjectT3Team2";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@ItemQuantity", orderDetail.ItemQuantity);
                    command.Parameters.AddWithValue("@OrderTime", orderDetail.OrderTime);
                    command.Parameters.AddWithValue("@OrderStatus", orderDetail.OrderStatus);
                    command.Parameters.AddWithValue("@Comment", orderDetail.Comment);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception or log the error message
                    }
                }
            }
        }
    }
}
