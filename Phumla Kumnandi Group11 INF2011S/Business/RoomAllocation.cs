using System;
using System.Collections.Generic;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class RoomAllocation
    {
        public enum AllocationStatus { Allocated, Released, Cancelled }

        #region Attributes
        private string allocationID;
        private string roomNumber;
        private string bookingID;
        private DateTime startDate;
        private DateTime endDate;
        private AllocationStatus status;
        private List<RoomService> services;
        private Account account;
        private int hotelID;

        public int HotelID
        {
            get { return hotelID; }
            set { hotelID = value; }
        }

        public string AllocationID
        {
            get { return allocationID; }
            set { allocationID = value; }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public string BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public AllocationStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public List<RoomService> Services
        {
            get { return services; }
            set { services = value; }
        }

        public Account Account
        {
            get { return account; }
        }
        #endregion

        #region Constructors
        public RoomAllocation()
        {
            services = new List<RoomService>();
        }

        public RoomAllocation(string allocationId, string roomNumber, string bookingId,
                              DateTime start, DateTime end, AllocationStatus allocationStatus,
                              Account account)
        {
            this.allocationID = allocationId;
            this.roomNumber = roomNumber;
            this.bookingID = bookingId;
            this.startDate = start.Date;
            this.endDate = end.Date;
            this.status = allocationStatus;
            this.services = new List<RoomService>();
            this.account = account ?? throw new ArgumentNullException(nameof(account));
        }
        #endregion

        #region Methods
        public bool ConflictsWithPeriod(DateTime periodStart, DateTime periodEnd)
        {
            return (startDate < periodEnd && endDate > periodStart);
        }

        public bool IncludesDates(DateTime date)
        {
            return (date >= startDate && date < endDate);
        }

        public void AddService(string serviceType)
        {
            double cost = GetDefaultCost(serviceType);

            RoomService service = new RoomService(
                "SVC" + new Random().Next(1000, 9999),
                this.roomNumber,
                (RoomService.ServiceType)Enum.Parse(typeof(RoomService.ServiceType), serviceType),
                cost
            );

            services.Add(service);

            if (cost > 0)
            {
                account.AddCharge((decimal)cost, $"{serviceType} Service");
            }
        }

        private double GetDefaultCost(string serviceType)
        {
            var costMapping = new Dictionary<string, double>
            {
                { "Room", 0.0 },
                { "Food", 25.0 },
                { "Beverage", 15.0 },
                { "Laundry", 20.0 },
                { "Cleaning", 0.0 },
                { "Maintenance", 0.0 },
                { "Other", 10.0 }
            };

            return costMapping.ContainsKey(serviceType) ? costMapping[serviceType] : 10.0;
        }
        #endregion
    }
}