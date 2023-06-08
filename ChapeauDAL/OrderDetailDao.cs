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
            string query = "SELECT Order_DetailID, Item_Quantity, Order_Time, Order_Status, Comment FROM Table";
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
                    OrderId = (int)dr["OrderId"],
                    ItemQuantity = (int)dr["Count"],
                   OrderTime = (TimeOnly)dr["Order_Time"],
                    OrderStatus = dr["Order_Status"].ToString(),
                    Comment = dr["Description"].ToString(),
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        public List<OrderDetail> GetOrder()
        {
            string query = @"SELECT , OrderDetail_ID , Item_Quantity, Comment 
                     FROM dbo.Order_Details o";
                     
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private void SetOrderStatus()
        {
            //Use this to change the status of the order
        }
        private void AddComment()
        {
            //Used to add added comments to the database
        }
        private void SetOrderTime()
        {
            //Used to determine the time of which an order was CONFIRMED
        }
    }
}
