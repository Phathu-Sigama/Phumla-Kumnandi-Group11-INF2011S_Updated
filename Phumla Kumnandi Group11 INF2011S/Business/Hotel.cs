using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{

    public class Hotel
    {
        #region Attributes


        private string hotelID;
        private string hotelName;
        private string address;
        private List<Room> rooms;
        private List<Booking> bookings;
        private List<RoomAllocation> allocations;
        private List<SeasonalRate> seasonalRates;


        public string HotelID
        {
            get { return hotelID; }
            set { hotelID = value; }
        }
        public string HotelName
        {
            get { return hotelName; }
            set { hotelName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public List<Room> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }
        public List<Booking> Bookings
        {
            get { return bookings; }
            set { bookings = value; }
        }
        public List<RoomAllocation> Allocations
        {
            get { return allocations; }
            set { allocations = value; }
        }
        public List<SeasonalRate> SeasonalRates
        {
            get { return seasonalRates; }
            set { seasonalRates = value; }
        }
        #endregion

        #region Constructors
        public Hotel()
        {
            this.Rooms = new List<Room>();
            this.Bookings = new List<Booking>();
            this.Allocations = new List<RoomAllocation>();
            this.SeasonalRates = new List<SeasonalRate>();
        }

        public Hotel(string hotelID, string hotelName, string address)
        {
            this.HotelID = hotelID;
            this.HotelName = hotelName;
            this.Address = address;
            this.Rooms = new List<Room>();
            this.Bookings = new List<Booking>();
            this.Allocations = new List<RoomAllocation>();
            this.SeasonalRates = new List<SeasonalRate>();
        }
        #endregion

        #region Methods

        public decimal GetTotalRevenue()
        {
            // Sum of TotalAmount from all confirmed bookings
            decimal total = 0m;

            if (bookings == null) return 0m;

            for (int i = 0; i < bookings.Count; i++)
            {
                Booking b = bookings[i];
                if (b.Status == Booking.BookingStatus.Confirmed)
                {
                    total += b.TotalAmount;
                }
            }

            return total;
        }

        public double GetOccupancyRate(DateTime startDate, DateTime endDate)
        {
            // Calculates average occupancy % across the given date range
            if (rooms == null || rooms.Count == 0) return 0.0;
            if (allocations == null || allocations.Count == 0) return 0.0;

            int totalRooms = rooms.Count;
            int totalDays = (endDate.Date - startDate.Date).Days;
            if (totalDays <= 0) return 0.0;

            double totalOccupiedRoomNights = 0.0;

            for (int i = 0; i < allocations.Count; i++)
            {
                RoomAllocation a = allocations[i];
                if (a.Status == RoomAllocation.AllocationStatus.Allocated)
                {
                    // count how many of its nights fall within [startDate, endDate)
                    DateTime allocStart = a.StartDate.Date;
                    DateTime allocEnd = a.EndDate.Date;

                    for (DateTime d = allocStart; d < allocEnd; d = d.AddDays(1))
                    {
                        if (d >= startDate.Date && d < endDate.Date)
                        {
                            totalOccupiedRoomNights++;
                        }
                    }
                }
            }

            double possibleRoomNights = totalRooms * totalDays;
            double occupancyRate = (totalOccupiedRoomNights / possibleRoomNights) * 100.0;

            return Math.Round(occupancyRate, 2);
        }
        #endregion

    }
}
