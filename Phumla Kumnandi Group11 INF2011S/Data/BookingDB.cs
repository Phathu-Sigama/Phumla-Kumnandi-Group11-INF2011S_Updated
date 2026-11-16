using Phumla_Kumnandi_Group11_INF2011S.Business;
using Phumla_Kumnandi_Group11_INF2011S.Data;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

public class BookingDB : DB
{
    #region Data Members
    private string table1 = "Booking";
    private string sqlLocal1 = "SELECT * FROM Booking";
    private Collection<Booking> bookings;
    #endregion

    #region Property Method: Collection
    public Collection<Booking> AllBookings
    {
        get
        {
            return bookings;
        }
    }
    #endregion

    #region Constructor
    public BookingDB() : base()
    {
        bookings = new Collection<Booking>();
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
        Booking aBooking;

        foreach (DataRow myRow_loopVariable in dsMain.Tables[table1].Rows)
        {
            myRow = myRow_loopVariable;
            if (!(myRow.RowState == DataRowState.Deleted))
            {
                aBooking = new Booking();
                aBooking.BookingID = Convert.ToString(myRow["BookingID"]).TrimEnd();
                aBooking.GuestID = Convert.ToString(myRow["GuestID"]).TrimEnd();
                aBooking.RoomID = Convert.ToString(myRow["RoomID"]).TrimEnd();
                aBooking.NumGuests = Convert.ToInt32(myRow["NumGuests"]);
                aBooking.NumRooms = Convert.ToInt32(myRow["NumRooms"]);
                aBooking.CheckInDate = Convert.ToDateTime(myRow["CheckInDate"]);
                aBooking.CheckOutDate = Convert.ToDateTime(myRow["CheckOutDate"]);
                aBooking.Status = (Booking.BookingStatus)Convert.ToByte(myRow["Status"]);
                aBooking.TotalAmount = Convert.ToDecimal(myRow["TotalAmount"]);
                aBooking.DepositAmount = Convert.ToDecimal(myRow["DepositAmount"]);
                aBooking.CardNumber = Convert.ToString(myRow["CardNumber"]).TrimEnd();

                bookings.Add(aBooking);
            }
        }
    }

    private void FillRow(DataRow aRow, Booking aBooking)
    {
        aRow["BookingID"] = aBooking.BookingID;
        aRow["GuestID"] = aBooking.GuestID;
        aRow["RoomID"] = aBooking.RoomID;
        aRow["NumGuests"] = aBooking.NumGuests;
        aRow["NumRooms"] = aBooking.NumRooms;
        aRow["CheckInDate"] = aBooking.CheckInDate;
        aRow["CheckOutDate"] = aBooking.CheckOutDate;
        aRow["Status"] = (byte)aBooking.Status;     // store enum as tinyint
        aRow["TotalAmount"] = aBooking.TotalAmount;
        aRow["DepositAmount"] = aBooking.DepositAmount;
        aRow["CardNumber"] = aBooking.CardNumber;
    }
    #endregion

    #region Database Operations CRUD
    public void DataSetChange(Booking aBooking)
    {
        DataRow aRow = null;
        aRow = dsMain.Tables[table1].NewRow();
        FillRow(aRow, aBooking);
        dsMain.Tables[table1].Rows.Add(aRow);
    }
    #endregion

    #region Build Parameters, Create Commands & Update Database
    private void Build_INSERT_Parameters(Booking aBooking)
    {
        SqlParameter param = default(SqlParameter);

        param = new SqlParameter("@BookingID", SqlDbType.NVarChar, 30, "BookingID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@GuestID", SqlDbType.NVarChar, 30, "GuestID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@RoomID", SqlDbType.NVarChar, 30, "RoomID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@NumGuests", SqlDbType.Int, 4, "NumGuests");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@NumRooms", SqlDbType.Int, 4, "NumRooms");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 8, "CheckInDate");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 8, "CheckOutDate");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@Status", SqlDbType.TinyInt, 1, "Status");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@TotalAmount", SqlDbType.Money, 8, "TotalAmount");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@DepositAmount", SqlDbType.Money, 8, "DepositAmount");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@CardNumber", SqlDbType.NVarChar, 30, "CardNumber");
        daMain.InsertCommand.Parameters.Add(param);
    }

    private void Create_INSERT_Command(Booking aBooking)
    {
        daMain.InsertCommand = new SqlCommand(
            "INSERT INTO Booking (BookingID, GuestID, RoomID, NumGuests, NumRooms, CheckInDate, CheckOutDate, Status, TotalAmount, DepositAmount, CardNumber) " +
            "VALUES (@BookingID, @GuestID, @RoomID, @NumGuests, @NumRooms, @CheckInDate, @CheckOutDate, @Status, @TotalAmount, @DepositAmount, @CardNumber)",
            cnMain);
        Build_INSERT_Parameters(aBooking);
    }

    public bool UpdateDataSource(Booking aBooking)
    {
        bool success;
        Create_INSERT_Command(aBooking);
        success = UpdateDataSource(sqlLocal1, table1);
        return success;
    }
    #endregion
}