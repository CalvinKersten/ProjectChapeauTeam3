using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class MenuItemDao : BaseDao
    {
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT Menu_ItemID, Item_Name, Item_Price, Item_Catagory, Stock FROM Menu_Item";
            SqlParameter[] sqlParameters = new SqlParameter[0]; 
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                MenuItem menuItem = new MenuItem()
                {
                    MenuItemID = (int)dr["Menu_ItemID"],
                    ItemName = dr["Item_Name"].ToString(),
                    ItemPrice = (float)dr["Item_Price"],
                    ItemCatagory = (string)dr["Item_Catagory"],
                    Stock = (int)dr["Stock"],
                };
                menuItems.Add(menuItem);
            }
            return menuItems;
        }
    }
}
