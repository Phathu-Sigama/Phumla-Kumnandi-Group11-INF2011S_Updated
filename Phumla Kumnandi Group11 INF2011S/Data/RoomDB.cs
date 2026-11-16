using Phumla_Kumnandi_Group11_INF2011S.Business;
using Phumla_Kumnandi_Group11_INF2011S.Data;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

public class RoomDB : DB
{
    #region Data Members
    private string table1 = "Room";
    private string sqlLocal1 = "SELECT * FROM Room";
    private Collection<Room> rooms;
    #endregion

    #region Property Method: Collection
    public Collection<Room> AllRooms
    {
        get
        {
            return rooms;
        }
    }
    #endregion

    #region Constructor
    public RoomDB() : base()
    {
        rooms = new Collection<Room>();
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
        Room aRoom;

        foreach (DataRow myRow_loopVariable in dsMain.Tables[table1].Rows)
        {
            myRow = myRow_loopVariable;
            if (!(myRow.RowState == DataRowState.Deleted))
            {
                aRoom = new Room();
                aRoom.HotelID = Convert.ToString(myRow["HotelID"]).TrimEnd();
                aRoom.RoomNumber = Convert.ToString(myRow["RoomNumber"]).TrimEnd();

                // Status stored as string in DB (e.g., "Available", "Occupied", "OutOfService")
                string statusString = Convert.ToString(myRow["Status"]);
                aRoom.Status = (Room.RoomStatus)Enum.Parse(typeof(Room.RoomStatus), statusString);

                rooms.Add(aRoom);
            }
        }
    }

    private void FillRow(DataRow aRow, Room aRoom)
    {
        aRow["HotelID"] = aRoom.HotelID;
        aRow["RoomNumber"] = aRoom.RoomNumber;
        // Store enum as string to match existing setup
        aRow["Status"] = aRoom.Status.ToString();
    }
    #endregion

    #region Database Operations CRUD
    public void DataSetChange(Room aRoom)
    {
        DataRow aRow = null;
        aRow = dsMain.Tables[table1].NewRow();
        FillRow(aRow, aRoom);
        dsMain.Tables[table1].Rows.Add(aRow);
    }
    #endregion

    #region Build Parameters, Create Commands & Update Database
    private void Build_INSERT_Parameters(Room aRoom)
    {
        SqlParameter param = default(SqlParameter);

        param = new SqlParameter("@HotelID", SqlDbType.NVarChar, 15, "HotelID");
        daMain.InsertCommand.Parameters.Add(param);

        param = new SqlParameter("@RoomNumber", SqlDbType.NVarChar, 15, "RoomNumber");
        daMain.InsertCommand.Parameters.Add(param);

        // Status saved as NVARCHAR in DB (matches Add2Collection parsing)
        param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "Status");
        daMain.InsertCommand.Parameters.Add(param);
    }

    private void Create_INSERT_Command(Room aRoom)
    {
        daMain.InsertCommand = new SqlCommand(
            "INSERT INTO Room (HotelID, RoomNumber, Status) VALUES (@HotelID, @RoomNumber, @Status)",
            cnMain);
        Build_INSERT_Parameters(aRoom);
    }

    public bool UpdateDataSource(Room aRoom)
    {
        bool success;
        Create_INSERT_Command(aRoom);
        success = UpdateDataSource(sqlLocal1, table1);
        return success;
    }
    #endregion
}