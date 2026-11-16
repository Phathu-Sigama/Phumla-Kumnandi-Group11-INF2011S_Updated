using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class ReportController
    {
        #region Methods
        // Build occupancy report from raw controller collections
        public OccupancyReport GenerateOccupancyReport(Collection<Room> rooms,
                                                       Collection<RoomAllocation> allocations,
                                                       DateTime start,
                                                       DateTime end)
        {
            OccupancyReport rep = new OccupancyReport();
            rep.ReportID = "OR" + DateTime.Now.Ticks.ToString();
            rep.GeneratedDate = DateTime.Now;
            rep.StartDate = start.Date;
            rep.EndDate = end.Date;

            rep.GenerateReportData(rooms, allocations);
            return rep;
        }

        // Build revenue report from raw bookings collection
        public RevenueReport GenerateRevenueReport(Collection<Booking> bookings,
                                                   DateTime start,
                                                   DateTime end)
        {
            RevenueReport rep = new RevenueReport();
            rep.ReportID = "RR" + DateTime.Now.Ticks.ToString();
            rep.GeneratedDate = DateTime.Now;
            rep.StartDate = start.Date;
            rep.EndDate = end.Date;

            rep.GenerateReportData(bookings);
            return rep;
        }
        #endregion
    }
}
