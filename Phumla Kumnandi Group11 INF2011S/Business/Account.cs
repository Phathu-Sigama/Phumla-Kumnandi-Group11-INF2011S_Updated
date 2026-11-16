using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class Account
    {
        public enum AccountStatus { Active, Closed }

        #region Attributes
        private string accountID;
        private string guestID;
        private string bookingID;
        private decimal balance;
        private decimal originalAmount;
        private AccountStatus status;

        public string AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        public string GuestID
        {
            get { return guestID; }
            set { guestID = value; }
        }

        public string BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public decimal OriginalAmount
        {
            get { return originalAmount; }
            set { originalAmount = value; }
        }

        public AccountStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region Constructors
        public Account()
        { }

        public Account(string accountID, string guestID, string bookingID,
                       decimal balance, AccountStatus status)
        {
            this.AccountID = accountID;
            this.GuestID = guestID;
            this.BookingID = bookingID;
            this.Balance = balance;
            this.OriginalAmount = balance;
            this.Status = status;
        }
        #endregion

        #region Methods
        public void ProcessPayment(decimal amount)
        {
            if (amount > 0)
            {
                balance -= amount;
            }
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void AddCharge(decimal amount, string description)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }

        public decimal CalculateOutstandingBalance()
        {
            return balance > 0 ? balance : 0;
        }

        public decimal ApplyLoyaltyDiscount(decimal discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 1)
            {
                return balance;
            }

            decimal discountAmount = balance * discountPercent;
            balance -= discountAmount;
            return discountAmount;
        }

        public void CloseAccount()
        {
            status = AccountStatus.Closed;
        }


        #endregion
    }
}