using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace ChapeauDAL
{
    public class EmployeeDao : BaseDao
    {
        public Employee SearchById(int EmployeeID)
        {
            string query = "SELECT EmployeeID, First_Name, Last_Name,Password, Role, EmployeeNr FROM Employee WHERE EmployeeID=@ID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", EmployeeID);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private Employee ReadTables(DataTable dataTable)
        {
            Employee employee = null;
            foreach (DataRow dr in dataTable.Rows)
            {
                int id = (int)dr["EmployeeID"];
                string firstName = dr["First_Name"].ToString();
                string lastName = dr["Last_Name"].ToString();
                int Password = int.Parse(dr["Password"].ToString());
                string roleString = dr["Role"].ToString();
                Role role;
                if (Enum.TryParse(roleString, out role))
                {
                    int EmployeeNumber = int.Parse(dr["EmployeeNr"].ToString());
                    employee = new Employee(id, firstName, lastName, role, Password, EmployeeNumber);
                }
                
                ////  Employee employees = new Employee();
                //Employee employee = null;
                //foreach (DataRow dr in dataTable.Rows)
                //{
                //    //employee = new Employee();
                //    int id = (int)dr["EmployeeID"];
                //    string firstName = (string)(dr["First_Name"].ToString());
                //    string lastName = (string)(dr["Last_Name"].ToString());
                //    int Password = (int.Parse)(dr["Password"].ToString());
                //    Role role = (Role)dr["Role"];
                //    int EmployeeNumber = (int)dr["EmployeeNr"];

                //    //creating a employee with alll read values from table 
                //    employee = new Employee(id, firstName, lastName, role, Password, EmployeeNumber);
                //}
                //return employee;

            }
            return employee;
        }

        public Employee VerifyCredentials(string username, string password)
        {
            string query = "SELECT EmployeeID, First_Name, Last_Name, Password, Role, EmployeeNr FROM Employee " +
                "WHERE EmployeeNr=@Username AND Password=@Password";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Username", username);
            sqlParameters[1] = new SqlParameter("@Password", password);

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            if (dataTable.Rows.Count == 1)
            {
                DataRow dr = dataTable.Rows[0];

                int id = (int)dr["EmployeeID"];
                string firstName = dr["First_Name"].ToString();
                string lastName = dr["Last_Name"].ToString();
                int Password = int.Parse(dr["Password"].ToString());
                Role role = (Role)Enum.Parse(typeof(Role), dr["Role"].ToString());
                int EmployeeNumber = int.Parse(dr["EmployeeNr"].ToString());
                return new Employee(id, firstName, lastName, role, Password, EmployeeNumber);
            }

            return null; // Invalid credentials
        }


    }
}