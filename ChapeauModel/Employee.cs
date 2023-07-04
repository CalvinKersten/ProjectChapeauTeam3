using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }

        public int EmployeeNumber;
        public int Password { get; set; }

        public Employee(int id, string firstName, string lastName, Role role, int Password, int EmployeeNumber)
        {
            EmployeeID = id;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Password = Password;
            EmployeeNumber = EmployeeNumber;
        }
    }
}

