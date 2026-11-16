using Phumla_Kumnandi_Group11_INF2011S.Business;
using Phumla_Kumnandi_Group11_INF2011S.Data;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

public class RoomAllocationDB : DB
{
    #region Data Members
    private string table1 = "RoomAllocation";
    private string sqlLocal1 = "SELECT * FROM RoomAllocation";
    private Collection<RoomAllocation> allocations;
    #endregion

    #region Property Method: Collection
    public Collection<RoomAllocation> AllAllocations
    {
        get { return allocations; }
    }
    #endregion

    #region Constructor
    public RoomAllocationDB() : base()
    {
        allocations = new Collection<RoomAllocation>();
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
        foreach (DataRow myRow in dsMain.Tables[table1].Rows)
        {
            if (myRow.RowState != DataRowState.Deleted)
            {
                RoomAllocation anAlloc = new RoomAllocation();
                // Changed to lowercase column names to match database
                anAlloc.AllocationID = Convert.ToString(myRow["allocationID"]).TrimEnd();
                anAlloc.RoomNumber = Convert.ToString(myRow["roomNumber"]).TrimEnd();
                anAlloc.BookingID = Convert.ToString(myRow["bookingID"]).TrimEnd();
                anAlloc.StartDate = Convert.ToDateTime(myRow["startDate"]);
                anAlloc.EndDate = Convert.ToDateTime(myRow["endDate"]);

                string statusString = Convert.ToString(myRow["status"]);
                anAlloc.Status = (RoomAllocation.AllocationStatus)
                    Enum.Parse(typeof(RoomAllocation.AllocationStatus), statusString);

                allocations.Add(anAlloc);
            }
        }
    }

    private void FillRow(DataRow aRow, RoomAllocation anAlloc)
    {
        // Changed to lowercase column names to match database
        aRow["allocationID"] = anAlloc.AllocationID;
        aRow["roomNumber"] = anAlloc.RoomNumber;
        aRow["bookingID"] = anAlloc.BookingID;
        aRow["startDate"] = anAlloc.StartDate;
        aRow["endDate"] = anAlloc.EndDate;
        aRow["status"] = anAlloc.Status.ToString();
    }
    #endregion

    #region Database Operations CRUD
    public void DataSetChange(RoomAllocation anAlloc)
    {
        DataRow aRow = dsMain.Tables[table1].NewRow();
        FillRow(aRow, anAlloc);
        dsMain.Tables[table1].Rows.Add(aRow);
    }
    #endregion

    #region Build Parameters, Create Commands & Update Database
    private void Build_INSERT_Parameters(RoomAllocation anAlloc)
    {
        SqlParameter param;

        // Changed parameter names to lowercase to match database
        param = new SqlParameter("@allocationID", SqlDbType.Int, 4, "allocationID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@roomNumber", SqlDbType.VarChar, 4, "roomNumber");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@bookingID", SqlDbType.VarChar, 8, "bookingID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@startDate", SqlDbType.DateTime, 8, "startDate");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@endDate", SqlDbType.DateTime, 8, "endDate");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@status", SqlDbType.VarChar, 20, "status");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@hotelID", SqlDbType.Int, 4, "hotelID");
        daMain.InsertCommand.Parameters.Add(param);
    }

    private void Create_INSERT_Command(RoomAllocation anAlloc)
    {
        daMain.InsertCommand = new SqlCommand(
            "INSERT INTO RoomAllocation (bookingID, roomNumber, hotelID, startDate, endDate, status) " +
            "VALUES (@bookingID, @roomNumber, @hotelID, @startDate, @endDate, @status)", cnMain);
        Build_INSERT_Parameters(anAlloc);
    }

    public bool UpdateDataSource(RoomAllocation anAlloc)
    {
        Create_INSERT_Command(anAlloc);
        return UpdateDataSource(sqlLocal1, table1);
    }
    #endregion
}