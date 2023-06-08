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
    public class EmployeeDao : BaseDao
    {
        public List<Employee> GetAllEmployees()
        {
            string query = "SELECT EmployeeID, EmployeeNr, First_Name, Last_Name, Password, [Function] FROM Employee";
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
                    EmployeeNum = (string)dr["EmployeeNr"],
                    FirstName = dr["First_Name"].ToString(),
                    LastName = dr["Last_Name"].ToString(),
                    Password = dr["Password"].ToString(),
                    Function = dr["[Function]"].ToString(),
                };
                employees.Add(employee);
            }
            return employees;
        }


    }
}


