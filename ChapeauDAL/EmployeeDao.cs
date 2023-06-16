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
        public List<Employee> SearchById(int EmployeeID)
        {
            string query = "SELECT EmployeeID, First_Name, Last_Name,FROM Employee WHERE EmployeeID=@ID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Employee> ReadTables(DataTable dataTable)
        {
            List<Employee> employees = new List<Employee>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Employee employee = new Employee()
                {
                    EmployeeID = (int)dr["EmployeeID"],
                    //EmployeeNum = (int)dr["EmployeeNr"],
                    FirstName = dr["First_Name"].ToString(),
                    LastName = dr["Last_Name"].ToString(),
                   // Password = dr["Password"].ToString(),
                    Role = dr["Role"].ToString(),
                };
                employees.Add(employee);
            }
            return employees;
        }

        //public Employee VerifyPassword(string employeeId, string Password)
        //{
        //    // first getting the stored salt from the database to compare with it 
        //    String query = "SELECT Salt FROM Employee WHERE UserName=@ID";
        //    SqlParameter[] sqlParameters = new SqlParameter[1];
        //    // preventing from sql injections
        //    sqlParameters[0] = new SqlParameter("@ID", employeeId);
           // string storedSalt = ReadEmployeeSalt(ExecuteSelectQuery(query, sqlParameters));
            //if (storedSalt == null)
            //{
            //    throw new Exception("No employee found with this employee Name");
            //}
            //// converting entered password by adding a stored salt from database 
            //string hashedPassword = HashingEnteredPassword(enteredPassword, storedSalt);

            ////now verifying the hashedpassword with salt to the user database
          //  Employee loggedEmployee = ComparingEnteredPassword(employeeId, enteredPassword);
            //if (loggedEmployee == null)
            //{
            //    throw new Exception("Something is  wrong with your password");
            //}
            //return loggedEmployee;
        
        //private List<Employee> ComparingEnteredPassword(string employeeId, string enteredPassword)
        //{
        //    string query = "SELECT EmployeeID, First_Name, Last_Name, Role, Password FROM Employee WHERE UserName=@EmployeeID AND [Password]=@password";
        //    SqlParameter[] sqlParameters = new SqlParameter[2];
           
        //    sqlParameters[0] = new SqlParameter("@EmployeeID", employeeId);
        //    sqlParameters[1] = new SqlParameter("@password", enteredPassword);
        //    return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        //}
    }
}
