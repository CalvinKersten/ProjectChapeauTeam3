﻿using ChapeauModel;
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
                    OrderDetailID = (int)dr["Order_DetailID"],
                    ItemQuantity = (int)dr["Item_Quantity"],
                    OrderTime = (TimeOnly)dr["Order_Time"],
                    OrderStatus = dr["Order_Status"].ToString(),
                    Comment = dr["Comment"].ToString(),
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
    }
}
