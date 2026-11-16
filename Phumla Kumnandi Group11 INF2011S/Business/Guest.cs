using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class Guest : Person
    {
        #region Attributes
        private string guestID;
        private string memberID;
        private bool hasActiveBooking;

        public string GuestID
        {
            get { return guestID; }
            set { guestID = value; }
        }

        public string MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public bool HasActiveBooking
        {
            get { return hasActiveBooking; }
            set { hasActiveBooking = value; }
        }
        #endregion

        #region Constructors
        public Guest() { }

        public Guest(string guestID, string firstName, string lastName,
                     string streetAddress, string area, string postalCode)
        {
            this.GuestID = guestID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StreetAddress = streetAddress;
            this.PostalCode = postalCode;
            this.MemberID = null;
            this.hasActiveBooking = false;
        }
        #endregion

        #region Methods
        public bool IsLoyaltyMember()
        {
            return !string.IsNullOrEmpty(memberID);
        }

        public void JoinLoyaltyProgram(LoyaltyMember loyaltyMember)
        {
            if (loyaltyMember != null)
            {
                this.memberID = loyaltyMember.MemberID;
            }
        }

        public void LeaveLoyaltyProgram()
        {
            this.memberID = null;
        }
        #endregion
    }
}