using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{

    public class Employee : Person
    {
        #region Attributes
        private string employeeID;
        private string role;
        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        #endregion
        #region Constructors
        public Employee() { }

        public Employee(string employeeID, string firstName, string lastName,
                        string streetAddress, string postalCode,
                        string role)
        {
            this.EmployeeID = employeeID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StreetAddress = streetAddress;
            this.PostalCode = postalCode;
            this.role = role;
        }
        #endregion
    }
}
