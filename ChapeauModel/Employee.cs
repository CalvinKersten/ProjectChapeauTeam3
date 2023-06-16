using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int EmployeeNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //public Employee(int employeeid, string firstName, string lastName, string function)
        //{
        //    this.EmployeeID = employeeid;
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //   this.Function = function;
        //}
    }
   
    public enum Role
    { 
        Chef=1, Waiter, Barman, Manager
    }

}

