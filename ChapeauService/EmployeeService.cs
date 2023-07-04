using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class EmployeeService
    {
        private EmployeeDao employeedb;

        public EmployeeService()
        {
            employeedb = new EmployeeDao();
        }
        public Employee SearchByID(int EmployeeID)
        {
            return employeedb.SearchById(EmployeeID);
        }
        public Employee VerifyCredentials(string username, string password)
        {
            return employeedb.VerifyCredentials(username, password);
        }
    }
}
