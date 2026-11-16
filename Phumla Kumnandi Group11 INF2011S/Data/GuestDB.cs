using Phumla_Kumnandi_Group11_INF2011S;
using Phumla_Kumnandi_Group11_INF2011S.Business;
using Phumla_Kumnandi_Group11_INF2011S.Data;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

public class GuestDB : DB
{
    #region Data Members
    private string table1 = "Guest";
    private string sqlLocal1 = "SELECT * FROM Guest";
    private Collection<Guest> guests;
    #endregion

    #region Property Method: Collection
    public Collection<Guest> AllGuests
    {
        get
        {
            return guests;
        }
    }
    #endregion

    #region Constructor
    public GuestDB() : base()
    {
        guests = new Collection<Guest>();
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
        Guest aGuest;

        foreach (DataRow myRow_loopVariable in dsMain.Tables[table1].Rows)
        {
            myRow = myRow_loopVariable;
            if (!(myRow.RowState == DataRowState.Deleted))
            {
                aGuest = new Guest();
                aGuest.GuestID = Convert.ToString(myRow["guestID"]).TrimEnd();
                aGuest.FirstName = Convert.ToString(myRow["firstName"]).TrimEnd();
                aGuest.LastName = Convert.ToString(myRow["lastName"]).TrimEnd();
                aGuest.Email = Convert.ToString(myRow["email"]).TrimEnd();
                aGuest.Phone = Convert.ToString(myRow["phone"]).TrimEnd();
                aGuest.StreetAddress = Convert.ToString(myRow["address"]).TrimEnd();
                aGuest.PostalCode = Convert.ToString(myRow["postalCode"]).TrimEnd();
                aGuest.HasActiveBooking = Convert.ToBoolean(myRow["hasActiveBooking"]);

                guests.Add(aGuest);
            }
        }
    }

    private void FillRow(DataRow aRow, Guest aGuest)
    {
        aRow["guestID"] = aGuest.GuestID;
        aRow["firstName"] = aGuest.FirstName;
        aRow["lastName"] = aGuest.LastName;
        aRow["email"] = ((Person)aGuest).Email;
        aRow["phone"] = ((Person)aGuest).Phone;
        aRow["address"] = ((Person)aGuest).Address;
        aRow["postalCode"] = aGuest.PostalCode;
        aRow["hasActiveBooking"] = aGuest.HasActiveBooking;
    }
    #endregion

    #region Database Operations CRUD
    public void DataSetChange(Guest aGuest)
    {
        DataRow aRow = null;
        aRow = dsMain.Tables[table1].NewRow();
        FillRow(aRow, aGuest);
        dsMain.Tables[table1].Rows.Add(aRow);
    }
    #endregion

    #region Build Parameters, Create Commands & Update Database
    private void Build_INSERT_Parameters(Guest aGuest)
    {
        SqlParameter param = default(SqlParameter);

        param = new SqlParameter("@guestID", SqlDbType.NVarChar, 8, "guestID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@firstName", SqlDbType.NVarChar, 50, "firstName");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@lastName", SqlDbType.NVarChar, 50, "lastName");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@email", SqlDbType.NVarChar, 100, "email");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@phone", SqlDbType.NVarChar, 10, "phone");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@address", SqlDbType.NVarChar, 200, "address");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@postalCode", SqlDbType.NVarChar, 4, "postalCode");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@hasActiveBooking", SqlDbType.Bit, 1, "hasActiveBooking");
        daMain.InsertCommand.Parameters.Add(param);
    }

    private void Create_INSERT_Command(Guest aGuest)
    {
        daMain.InsertCommand = new SqlCommand(
            "INSERT INTO Guest (guestID, firstName, lastName, email, phone, address, postalCode, hasActiveBooking) " +
            "VALUES (@guestID, @firstName, @lastName, @email, @phone, @address, @postalCode, @hasActiveBooking)",
            cnMain);
        Build_INSERT_Parameters(aGuest);
    }

    public bool UpdateDataSource(Guest aGuest)
    {
        bool success;
        Create_INSERT_Command(aGuest);
        success = UpdateDataSource(sqlLocal1, table1);
        return success;
    }
    #endregion
}