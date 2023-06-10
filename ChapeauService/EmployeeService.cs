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

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = employeedb.GetAllEmployees();
            return employees;
        }
    }
}
