using ChapeauModel;
using System;
//using ChapeauService;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;
using System.ComponentModel.Design;

namespace ChapeauDAL
{
    public class OrderDetailDao : BaseDao {
        private MenuItemDao menuItemDao;
        public OrderDetailDao()
        {
            menuItemDao = new MenuItemDao();
        }

        public List<Order> GetAllOrderForKitchenAndBar(Catagory itemCatagory, OrderStatus orderItemState)
        {
            string query = "SELECT od.Order_DetailID, o.TableID, m.Item_Name, od.Item_Quantity, od.Order_Status, od.Order_Time, od.Comment" +
                       "FROM [Order_Detail] AS od " +
                       "JOIN [Order] AS o ON o.Order_DetailID = od.Order_DetailID " +
                       "JOIN [Menu_Item] AS m ON m.Menu_ItemID = o.Menu_ItemID " +
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
                    order.OrderDetail.Comment = (string)dr["Comment"].ToString();
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
    }
}
