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
                    ItemPrice = (decimal)dr["Item_Price"],
                    ItemCatagory = (Catagory)dr["Item_Catagory"],
                    Stock = (int)dr["Stock"],
                };
                menuItems.Add(menuItem);
            }
            return menuItems;
        }
        public decimal GetItemPrice(int menuItemID)
        {
            string query = "SELECT Item_Price FROM Menu_Item WHERE Menu_ItemID =@MenuItemID";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2";
            SqlConnection con = new SqlConnection(connectionString);
            decimal itemPrice = 0.0m; // Default value

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
                            itemPrice = reader.GetDecimal(0);
                        }
                    }
                }
                catch
                {
                    //error message
                }
            }
            return itemPrice;
        } // Gets the MenuItem price from the database using the menuItemID
        public string GetItemName(int menuItemID)
        {
            string query = "SELECT Item_Name FROM Menu_Item WHERE Menu_ItemID =@MenuItemID";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2";
            SqlConnection con = new SqlConnection(connectionString);
            string itemName = ""; // Default value

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
                            itemName = reader.GetString(0);
                        }
                    }
                }
                catch
                {
                    //error message
                }
            }
            return itemName;
        } // Gets the MenuItem price from the database using the menuItemID
        public int GetItemCatagory(int menuItemID)
        {
            string query = "SELECT Item_Catagory FROM Menu_Item WHERE Menu_ItemID =@MenuItemID";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2";
            SqlConnection con = new SqlConnection(connectionString);
            int itemAmount = 0; // Default value

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
            return itemAmount;
        }
        public MenuItem GetMenuItemByID(int menuItemID)
        {
            string query = "SELECT Menu_ItemID, Item_Name, Item_Catagory, Stock FROM Menu_Item WHERE Menu_ItemID= @Menu_ItemID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Menu_ItemID", menuItemID);
            return ReadMenuTable(ExecuteSelectQuery(query, sqlParameters));
        }
        private MenuItem ReadMenuTable(DataTable dataTable)
        {
            MenuItem menuItem = null;

            foreach (DataRow dr in dataTable.Rows)
            {
                menuItem = new MenuItem()
                {
                    MenuItemID = (int)dr["Menu_ItemID"],
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
