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

        public List<OrderDetail> GetKitchenOrder()
        {
            // string query = "SELECT Order_DetailID, Item_Quantity, Comment, Order_Status FROM [Order_Detail] ";
            string query = "SELECT o.Order_DetailID, o.Item_Quantity, o.Order_Status,  FROM [Order_Detail] AS o " +
                 "JOIN dbo.Menu_Item m ON o.Menu_ItemID = m.Menu_ItemID" +
                 "WHERE m.Item_Category = '1' OR m.Item_Category='2'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderDetail> GetAllOrderDetails()
        {
            string query = "SELECT Order_DetailID, Item_Quantity, Comment,Menu_ItemID FROM Order_Detail";
               
                
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
                    Order_DetailID = (int)dr["Order_DetailID"],
                    Item_Quantity = (int)dr["Item_Quantity"],
                    MenuItem = menuItemDao.GetMenuItemByID((int)dr["Menu_ItemID"]),
                  //  Order_Time = (TimeOnly)dr["Order_Time"],
                   // Order_Status = dr["Order_Status"].ToString(),
                    Comment = dr["Comment"].ToString(),
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        
        public List<OrderDetail> GetRunningOrders()
        {
            string query = "SELECT Order_DetailID, Item_Quantity, Comment, Order_Status,Menu_ItemID FROM [Order_Detail] WHERE [Order_Detail].Order_Status LIKE '%Running%'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<OrderDetail> GetCompletedOrders()
        {
            string query = "SELECT Order_DetailID, Item_Quantity, Comment, Order_Status, Menu_ItemID FROM [Order_Detail] WHERE [Order_Detail].Order_Status  LIKE '%Completed%'";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        
        public void ChangeOrderStatus(OrderStatus status, List<OrderDetail> orderDetails)
        {
            string query = "INSERT INTO Order_Detail (Order_Time, Order_Status, Comment) VALUES (@Order_Time, @Order_Status, @Comment)";
           
            DateTime time = new DateTime();
            SqlParameter[] sqlParameters = new SqlParameter[0];
            ExecuteSelectQuery(query, sqlParameters);
            string OrderStatus = "";
            string Comment = "";
            string OrderTime = time.ToString("hh/mm/ss");
            //int ItemQuantity = 0;

            foreach (OrderDetail orderDetail in orderDetails)
            {
                OrderStatus = "Completed";
                Comment = "";
              //  ItemQuantity = int.Parse(orderDetail.SubItems[0].Text);
            }
        }
        //private void AddExistingOrder(List<OrderDetail> orderDetails, int orderDetailId)
        //{
        //    foreach (OrderDetail orderDetail in orderDetails)
        //    {
        //        string query = "If EXISTS (Select * From Order_Detail WHERE Order_DetailID = @Order_DetailID AND MenuItemID = @MenuItemID AND OrderStatus=1" +
        //            "Update Order_Detail SET Item_Quantity = Item_Quantity + Item_Quantity WHERE Order_DetailID = @Order_DetailID AND MenuItemID @MenuItemID ";
        //        SqlParameter[] sqlParameters = {
        //            new SqlParameter("@Order_DetailID", orderDetailId),
        //        //    new SqlParameter("MenuItemId", orderDetail.OrderDetail.ItemId),
        //            new SqlParameter("@Item_Quantity", orderDetail.Item_Quantity),
        //           // new SqlParameter("@datetime", DateTime.Now),
        //          //  new SqlParameter("@feedback", orderDetail.Comment)
        //        };
        //        ExecuteEditQuery(query, sqlParameters);
        //    }
        //}


    }
}
