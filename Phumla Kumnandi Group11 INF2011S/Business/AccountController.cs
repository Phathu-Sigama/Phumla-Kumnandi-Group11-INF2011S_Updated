using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class AccountController
    {
        #region Data Members
        private AccountDB accountDB;
        private Collection<Account> accounts;
        #endregion

        #region Properties
        public Collection<Account> AllAccounts
        {
            get { return accounts; }
        }
        #endregion

        #region Constructor
        public AccountController()
        {
            accountDB = new AccountDB();
            accounts = accountDB.AllAccounts;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Account account)
        {
            accountDB.DataSetChange(account);
            if (!accounts.Contains(account))
            {
                accounts.Add(account);
            }
        }

        public bool FinalizeChanges(Account account)
        {
            return accountDB.UpdateDataSource(account);
        }
        #endregion

        #region Finders
        public Account Find(string accountID)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountID == accountID)
                {
                    return accounts[i];
                }
            }
            return null;
        }
        #endregion

        #region Business Logic
        public Account CreateAccount(string bookingID, string guestID)
        {
            string id = GenerateAccountID();
            Account acc = new Account(id, guestID, bookingID, 0m, Account.AccountStatus.Active);
            DataMaintenance(acc);
            return acc;
        }

        public void ProcessPayment(Account acc, decimal amount)
        {
            if (acc == null) return;
            acc.ProcessPayment(amount);
            DataMaintenance(acc);
        }

        public decimal GetBalance(Account acc)
        {
            if (acc == null) return 0m;
            return acc.GetBalance();
        }

        private string GenerateAccountID()
        {
            return "ACC" + System.DateTime.Now.Ticks.ToString();
        }
        #endregion
    }
}
