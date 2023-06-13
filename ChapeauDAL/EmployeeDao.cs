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
        public List<Employee> GetAllEmployees()
        {
            string query = "SELECT EmployeeID, EmployeeNr, First_Name, Last_Name, Password, Role FROM Employee";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Employee> GetAllEmployeeIDs()
        {
            string query = "SELECT EmployeeID FROM Employee";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Employee> GetAllEmployeeNames()
        {
            int EmployeeID = GetAllEmployeeIDs();
            string query = "SELECT Last_Name FROM Employee WHERE EmployeeID=@EmployeeID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            sqlParameters.AddWithValue("@EmployeeID", EmployeeID);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Employee> ReadEmployeeName(DataTable dataTable)
        {
            List<Employee> employeeName = new List<Employee>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Employee employee = new Employee()
                {
                    LastName = dr["Last_Name"].ToString()
                };
                employeeName.Add(employee);
            }
            return employeeName;
        }

        private List<Employee> ReadTables(DataTable dataTable)
        {
            List<Employee> employees = new List<Employee>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Employee employee = new Employee()
                {
                    EmployeeID = (int)dr["EmployeeID"],
                    EmployeeNumber = (string)dr["EmployeeNr"],
                    FirstName = dr["First_Name"].ToString(),
                    LastName = dr["Last_Name"].ToString(),
                    Password = dr["Password"].ToString(),
                    Role = dr["Role"].ToString(),
                };
                employees.Add(employee);
            }
            return employees;
        }


    }
}
