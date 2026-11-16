using Phumla_Kumnandi_Group11_INF2011S.Business;
using Phumla_Kumnandi_Group11_INF2011S.Data;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

public class AccountDB : DB
{
    #region Data Members
    private string table1 = "Account";
    private string sqlLocal1 = "SELECT * FROM Account";
    private Collection<Account> accounts;
    #endregion

    #region Property Method: Collection
    public Collection<Account> AllAccounts
    {
        get
        {
            return accounts;
        }
    }
    #endregion

    #region Constructor
    public AccountDB() : base()
    {
        accounts = new Collection<Account>();
        FillDataSet(sqlLocal1, table1);
        Add2Collection();
    }
    #endregion

    #region Utility Methods
    public DataSet GetDataSet()
    {
        return dsMain;
    }

    private void Add2Collection()
    {
        DataRow myRow = null;
        Account anAcc;

        foreach (DataRow myRow_loopVariable in dsMain.Tables[table1].Rows)
        {
            myRow = myRow_loopVariable;
            if (!(myRow.RowState == DataRowState.Deleted))
            {
                anAcc = new Account();
                anAcc.AccountID = Convert.ToString(myRow["AccountID"]).TrimEnd();
                anAcc.GuestID = Convert.ToString(myRow["GuestID"]).TrimEnd();
                anAcc.BookingID = Convert.ToString(myRow["BookingID"]).TrimEnd();
                anAcc.Balance = Convert.ToDecimal(myRow["Balance"]);
                anAcc.Status = (Account.AccountStatus)Convert.ToByte(myRow["Status"]);

                accounts.Add(anAcc);
            }
        }
    }

    private void FillRow(DataRow aRow, Account anAcc)
    {
        aRow["AccountID"] = anAcc.AccountID;
        aRow["GuestID"] = anAcc.GuestID;
        aRow["BookingID"] = anAcc.BookingID;
        aRow["Balance"] = anAcc.Balance;
        aRow["Status"] = (byte)anAcc.Status;
    }
    #endregion

    #region Database Operations CRUD
    public void DataSetChange(Account anAcc)
    {
        DataRow aRow = null;
        aRow = dsMain.Tables[table1].NewRow();
        FillRow(aRow, anAcc);
        dsMain.Tables[table1].Rows.Add(aRow);
    }
    #endregion

    #region Build Parameters, Create Commands & Update Database
    private void Build_INSERT_Parameters(Account anAcc)
    {
        SqlParameter param = default(SqlParameter);

        param = new SqlParameter("@AccountID", SqlDbType.NVarChar, 15, "AccountID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@GuestID", SqlDbType.NVarChar, 15, "GuestID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@BookingID", SqlDbType.NVarChar, 15, "BookingID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@Balance", SqlDbType.Money, 8, "Balance");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@Status", SqlDbType.TinyInt, 1, "Status");
        daMain.InsertCommand.Parameters.Add(param);
    }

    private void Create_INSERT_Command(Account anAcc)
    {
        daMain.InsertCommand = new SqlCommand(
            "INSERT INTO Account (AccountID, GuestID, BookingID, Balance, Status) VALUES (@AccountID, @GuestID, @BookingID, @Balance, @Status)",
            cnMain);
        Build_INSERT_Parameters(anAcc);
    }

    public bool UpdateDataSource(Account anAcc)
    {
        bool success;
        Create_INSERT_Command(anAcc);
        success = UpdateDataSource(sqlLocal1, table1);
        return success;
    }
    #endregion
}