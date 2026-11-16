using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class OccupancyReport : Report
    {
        #region Attributes
        private DateTime startDate;              // inclusive
        private DateTime endDate;                // exclusive
        private int totalRooms;
        private decimal averageOccupancyRate;    // %
        #endregion

        #region Properties
        public DateTime StartDate { get { return startDate; } set { startDate = value.Date; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value.Date; } }
        public int TotalRooms { get { return totalRooms; } set { totalRooms = value; } }
        public decimal AverageOccupancyRate { get { return averageOccupancyRate; } set { averageOccupancyRate = value; } }
        #endregion

        #region Methods
        // Build summary using raw collections (from controllers)
        public void GenerateReportData(Collection<Room> rooms,
                                       Collection<RoomAllocation> allocations)
        {
            // handle nulls & bad ranges
            if (rooms == null) { totalRooms = 0; averageOccupancyRate = 0m; return; }

            totalRooms = rooms.Count;

            int days = (endDate - startDate).Days;
            if (days <= 0 || totalRooms <= 0)
            {
                averageOccupancyRate = 0m;
                return;
            }

            // count total booked room-nights across the period
            int totalBookedRoomNights = 0;

            DateTime d = startDate;
            while (d < endDate)
            {
                int bookedToday = 0;

                // for each room, see if it is booked on day 'd'
                for (int i = 0; i < rooms.Count; i++)
                {
                    string roomId = rooms[i].RoomNumber;
                    bool isBooked = false;

                    if (allocations != null)
                    {
                        for (int j = 0; j < allocations.Count; j++)
                        {
                            RoomAllocation a = allocations[j];

                            // only consider active allocations for this room
                            if (a.RoomNumber == roomId &&
                                a.Status == RoomAllocation.AllocationStatus.Allocated)
                            {
                                // "covers day" rule: d ∈ [StartDate, EndDate)
                                if (d >= a.StartDate.Date && d < a.EndDate.Date)
                                {
                                    isBooked = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (isBooked) { bookedToday++; }
                }

                totalBookedRoomNights += bookedToday;
                d = d.AddDays(1);
            }

            int possibleRoomNights = totalRooms * days;
            if (possibleRoomNights > 0)
            {
                averageOccupancyRate =
                    Math.Round(((decimal)totalBookedRoomNights / (decimal)possibleRoomNights) * 100m, 2,
                               MidpointRounding.AwayFromZero);
            }
            else
            {
                averageOccupancyRate = 0m;
            }
        }

        public string DisplayReport()
        {
            string s = "OCCUPANCY REPORT\n";
            s += "Report ID: " + ReportID + "\n";
            s += "Generated: " + GeneratedDate.ToString("yyyy-MM-dd HH:mm") + "\n";
            s += "Period: " + StartDate.ToString("yyyy-MM-dd") + " to " + EndDate.AddDays(-1).ToString("yyyy-MM-dd") + "\n";
            s += "Total Rooms: " + TotalRooms + "\n";
            s += "Average Occupancy: " + AverageOccupancyRate.ToString("0.00") + "%\n";
            return s;
        }
        #endregion
    }
}
