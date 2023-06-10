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
            string query = "SELECT Order_DetailID, Item_Quantity, Order_Status, Comment FROM dbo.Order_Detail";
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
                    Order_Status = dr["Order_Status"].ToString(),
                    Comment = dr["Comment"].ToString(),
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
    }
}
