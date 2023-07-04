using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ChapeauDAL
{
    public class MenuItemDao : BaseDao
    {
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT Menu_ItemID, Item_Name, Item_Catagory, Stock FROM Menu_Item";
            SqlParameter[] sqlParameters = new SqlParameter[0]; 
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        //public List<MenuItem> GetKitchenOrders()
        //{
        //    string query = "SELECT o.Order_DetailID, o.Item_Quantity, o.Order_Status,  FROM [Order_Detail] AS o " +
        //        "JOIN dbo.Menu_Item m ON o.Menu_ItemID = m.Menu_ItemID";
        //    SqlParameter[] sqlParameters = new SqlParameter[0];
        //    return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        //}
        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem()
                {
                    ItemID = (int)dr["Menu_ItemID"],
                    ItemName = dr["Item_Name"].ToString(),
                   // ItemPrice = (float)dr["Item_Price"],
                    ItemCatagory = (Catagory)dr["Item_Catagory"],
                    Stock = (int)dr["Stock"],
                };
                menuItems.Add(menuItem);
            }
            return menuItems;
        }
        public MenuItem GetMenuItemByID(int id)
        {
            string query = "SELECT Menu_ItemID, Item_Name, Item_Catagory, Stock FROM Menu_Item WHERE Menu_ItemID= @Menu_ItemID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Menu_ItemID", id);
            return ReadMenuTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private MenuItem ReadMenuTable(DataTable dataTable)
        {
            MenuItem menuItem=null;

            foreach (DataRow dr in dataTable.Rows)
            {
                 menuItem = new MenuItem()
                {
                    ItemID = (int)dr["Menu_ItemID"],
                    ItemName = dr["Item_Name"].ToString(),
                    // ItemPrice = (float)dr["Item_Price"],
                  //  Item_Catagory = (string)dr["Item_Catagory"],
                    Stock = (int)dr["Stock"],
                };
                
            }
            return menuItem;
        }
    }
}
