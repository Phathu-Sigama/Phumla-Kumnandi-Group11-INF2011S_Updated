using Phumla_Kumnandi_Group11_INF2011S.Business;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Phumla_Kumnandi_Group11_INF2011S.Data
{
    internal class RoomServiceDB : DB
    {
        private const string table = "RoomService";
        private string sqlLocal = "SELECT * FROM RoomService";
        private Collection<RoomService> services = new Collection<RoomService>();

        public Collection<RoomService> AllServices => services;

        public RoomServiceDB()
        {
            FillDataSet(sqlLocal, table);
            Add2Collection(table);
        }

        private void Add2Collection(string tableName)
        {
            DataRowCollection rows = dsMain.Tables[tableName].Rows;
            services.Clear();

            foreach (DataRow row in rows)
            {
                var service = new RoomService(
                    row["ServiceID"].ToString(),
                    row["RoomNumber"].ToString(),
                    (RoomService.ServiceType)Enum.Parse(typeof(RoomService.ServiceType), row["ServiceType"].ToString()),
                    Convert.ToDouble(row["Cost"])
                );

                services.Add(service);
            }
        }

        public void DataSetChange(RoomService service, DBOperation operation)
        {
            DataRow row = null;

            switch (operation)
            {
                case DBOperation.Add:
                    row = dsMain.Tables[table].NewRow();
                    row["ServiceID"] = service.ServiceID;
                    row["RoomNumber"] = service.RoomNumber;
                    row["ServiceType"] = service.Type.ToString();
                    row["Cost"] = service.Cost;
                    dsMain.Tables[table].Rows.Add(row);
                    break;

                case DBOperation.Update:
                    row = dsMain.Tables[table].Rows
                        .Cast<DataRow>()
                        .First(r => r["ServiceID"].ToString() == service.ServiceID);
                    row["ServiceType"] = service.Type.ToString();
                    row["Cost"] = service.Cost;
                    break;

                case DBOperation.Delete:
                    row = dsMain.Tables[table].Rows
                        .Cast<DataRow>()
                        .First(r => r["ServiceID"].ToString() == service.ServiceID);
                    dsMain.Tables[table].Rows.Remove(row);
                    break;
            }
        }

        public bool UpdateDataSource()
        {
            return base.UpdateDataSource(sqlLocal, table);
        }
    }

    // Enumeration for database operations
    internal enum DBOperation
    {
        Add,
        Update,
        Delete
    }
}
