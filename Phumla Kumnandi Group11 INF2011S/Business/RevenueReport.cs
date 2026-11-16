using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class RevenueReport : Report
    {
        #region Attributes
        private DateTime startDate;           // inclusive
        private DateTime endDate;             // exclusive
        private decimal totalRevenue;
        private decimal averageDailyRevenue;
        private int totalBookings;
        #endregion

        #region Properties
        public DateTime StartDate { get { return startDate; } set { startDate = value.Date; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value.Date; } }
        public decimal TotalRevenue { get { return totalRevenue; } set { totalRevenue = value; } }
        public decimal AverageDailyRevenue { get { return averageDailyRevenue; } set { averageDailyRevenue = value; } }
        public int TotalBookings { get { return totalBookings; } set { totalBookings = value; } }
        #endregion

        #region Methods
        // Sum revenue from confirmed bookings overlapping the range
        public void GenerateReportData(Collection<Booking> bookings)
        {
            totalRevenue = 0m;
            totalBookings = 0;

            if (bookings != null)
            {
                for (int i = 0; i < bookings.Count; i++)
                {
                    Booking b = bookings[i];

                    if (b.Status == Booking.BookingStatus.Confirmed)
                    {
                        DateTime aStart = b.CheckInDate.Date;
                        DateTime aEnd = b.CheckOutDate.Date;

                        // SIMPLE overlap: starts before end AND ends after start
                        if (aStart < endDate && aEnd > startDate)
                        {
                            totalRevenue += b.TotalAmount;
                            totalBookings += 1;
                        }
                    }
                }
            }

            int days = (endDate - startDate).Days;
            if (days > 0)
            {
                averageDailyRevenue =
                    Math.Round(totalRevenue / (decimal)days, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                averageDailyRevenue = 0m;
            }
        }

        public string DisplayReport()
        {
            string s = "REVENUE REPORT\n";
            s += "Report ID: " + ReportID + "\n";
            s += "Generated: " + GeneratedDate.ToString("yyyy-MM-dd HH:mm") + "\n";
            s += "Period: " + StartDate.ToString("yyyy-MM-dd") + " to " + EndDate.AddDays(-1).ToString("yyyy-MM-dd") + "\n";
            s += "Total Revenue: R" + TotalRevenue.ToString("N2") + "\n";
            s += "Average Daily Revenue: R" + AverageDailyRevenue.ToString("N2") + "\n";
            s += "Total Bookings: " + TotalBookings + "\n";
            return s;
        }
        #endregion
    }
}
