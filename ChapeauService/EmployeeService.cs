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

        public List<Employee> GetEmployees(int EmployeeID)
        {
            List<Employee> employees = employeedb.SearchById(EmployeeID);
            return employees;
        }
    }
}
