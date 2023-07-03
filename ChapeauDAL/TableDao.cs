using System;
using ChapeauModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class TableDao : BaseDao
    { 
        public int GetTableNumber(int tableID)
        {
            string query = "SELECT Table_Num FROM [Table] WHERE TableID =@TableID";
            string connectionString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2";
            SqlConnection con = new SqlConnection(connectionString);
            int tableNumber = 0; // Default value

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@TableID", tableID);
                try
                {
                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tableNumber = reader.GetInt32(0);
                        }
                    }
                }
                catch
                {
                    //error message
                }
            }
            return tableNumber;
        }
        
        

        
    }
}
