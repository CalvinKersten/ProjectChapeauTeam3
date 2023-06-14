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
using System.ComponentModel.Design;

namespace ChapeauDAL
{
    public class OrderDetailDao : BaseDao
    {
        public List<OrderDetail> GetAllOrderDetails()
        {
            string query = "SELECT Order_DetailID, Item_Quantity, Comment FROM dbo.Order_Detail";
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
                  //  Order_Time = (TimeOnly)dr["Order_Time"],
                   // Order_Status = dr["Order_Status"].ToString(),
                    Comment = dr["Comment"].ToString(),
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        private int RunningOrder(DataTable dataTable)
        {
            if (dataTable != null)
            {
                if (dataTable.Rows.Count > 0)
                {
                    return int.Parse(dataTable.Rows[0]["OrderID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("Error in this process.");
            }
        }

        private void AddExistingOrder(List<OrderDetail> orderDetails, int orderDetailId)
        {
            foreach (OrderDetail orderDetail in orderDetails)
            {
                string query = "If EXISTS (Select * From Order_Detail WHERE Order_DetailID = @Order_DetailID AND MenuItemID = @MenuItemID AND OrderStatus=1" +
                    "Update Order_Detail SET Item_Quantity = Item_Quantity + Item_Quantity WHERE Order_DetailID = @Order_DetailID AND MenuItemID @MenuItemID ";
                SqlParameter[] sqlParameters = {
                    new SqlParameter("@Order_DetailID", orderDetailId),
                //    new SqlParameter("MenuItemId", orderDetail.OrderDetail.ItemId),
                    new SqlParameter("@Item_Quantity", orderDetail.Item_Quantity),
                   // new SqlParameter("@datetime", DateTime.Now),
                  //  new SqlParameter("@feedback", orderDetail.Comment)
                };
                ExecuteEditQuery(query, sqlParameters);
            }
        }


    }
}
