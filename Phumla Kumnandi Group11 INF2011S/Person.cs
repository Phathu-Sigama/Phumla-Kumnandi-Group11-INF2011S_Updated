using System;

namespace Phumla_Kumnandi_Group11_INF2011S
{
    public class Person
    {
        #region Attributes
        private string personID;
        private string firstName;
        private string lastName;
        private string streetAddress;
        private string area;
        private string postalCode;
        private string email;
        private string phone;
        #endregion

        #region Properties
        public string PersonID { get { return personID; } set { personID = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string StreetAddress { get { return streetAddress; } set { streetAddress = value; } }
        public string Area { get { return area; } set { area = value; } }
        public string PostalCode { get { return postalCode; } set { postalCode = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Address => $"{streetAddress}, {area}";
        #endregion

        #region Constructors
        public Person() { }

        public Person(string personID, string firstName, string lastName,
                      string streetAddress, string area, string postalCode,
                      string email, string phone)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StreetAddress = streetAddress;
            this.Area = area;
            this.PostalCode = postalCode;
            this.Email = email;
            this.Phone = phone;
        }
        #endregion

        #region Methods
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public string GetStreetAddress()
        {
            return StreetAddress;
        }

        public string GetPostalCode()
        {
            return PostalCode;
        }
        #endregion
    }
}
