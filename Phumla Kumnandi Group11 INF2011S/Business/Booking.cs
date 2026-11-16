using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class Booking
    {
        public enum BookingStatus { Unconfirmed, Confirmed, Cancelled }

        #region Attributes
        private string bookingID;
        private string guestID;
        private string roomID;
        private int numGuests;
        private int numRooms;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private BookingStatus status;
        private decimal totalAmount;
        private decimal depositAmount;
        private string cardNumber;

        public string BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }
        public string GuestID
        {
            get { return guestID; }
            set { guestID = value; }
        }
        public string RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        public int NumGuests
        {
            get { return numGuests; }
            set { numGuests = value; }
        }
        public int NumRooms
        {
            get { return numRooms; }
            set { numRooms = value; }
        }
        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value.Date; }
        }
        public DateTime CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value.Date; }
        }
        public BookingStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public decimal DepositAmount
        {
            get { return depositAmount; }
            set { depositAmount = value; }
        }
        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }
        #endregion

        #region Constructors
        public Booking() { }

        public Booking(string bookingID, string guestID, string roomID,
                    DateTime checkIn, DateTime checkOut, BookingStatus status,
                    int numGuests, int numRooms, string cardNumber)
        {
            this.BookingID = bookingID;
            this.GuestID = guestID;
            this.RoomID = roomID;
            this.CheckInDate = checkIn.Date;
            this.CheckOutDate = checkOut.Date;
            this.Status = status;
            this.NumGuests = numGuests;
            this.NumRooms = numRooms;
            this.CardNumber = cardNumber;
        }
        #endregion
        #region Methods
        public int GetNumberOfNights()
        {
            return (checkOutDate.Date - checkInDate.Date).Days;
        }

        // Checks if two date ranges overlap
        public bool ConflictsWithPeriod(DateTime periodStart, DateTime periodEnd)
        {
            // If this booking starts before the other one ends,
            // and ends after the other one starts, they overlap.
            if (checkInDate < periodEnd && checkOutDate > periodStart)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Checks if the booking includes this specific date
        public bool IncludeDates(DateTime date)
        {
            // A night is covered if the date is between CheckIn and CheckOut
            if (date >= checkInDate && date < checkOutDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // --- Total calculation (flat nightly rate) ---
        public void CalculateTotal(decimal nightlyRate)
        {
            int nights = GetNumberOfNights();
            totalAmount = nightlyRate * nights * numRooms;
        }

        // Helper: return the correct rate for a single date from the provided seasons
        private decimal GetRateForDate(DateTime day, List<SeasonalRate> rates)
        {
            for (int i = 0; i < rates.Count; i++)
            {
                SeasonalRate sr = rates[i];
                if (day >= sr.StartDate.Date && day <= sr.EndDate.Date)
                {
                    return sr.RatePerNight;
                }
            }
            // No matching season — return 0 (safe default; adjust if you prefer)
            return 0m;
        }

        // --- Total calculation (seasonal rates) ---
        public void CalculateTotal(List<SeasonalRate> rates)
        {
            decimal total = 0m;
            int nights = GetNumberOfNights();

            for (int i = 0; i < nights; i++)
            {
                DateTime day = checkInDate.AddDays(i);
                decimal dayRate = GetRateForDate(day, rates);
                total = total + dayRate;
            }

            totalAmount = total * numRooms;
        }

        // 10% by default; rounds to 2 decimals
        public void CalculateDeposit(decimal percent = 0.10m)
        {
            totalAmount = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero);
            depositAmount = Math.Round(totalAmount * percent, 2, MidpointRounding.AwayFromZero);
        }

        // Deposit is due when today is on/after 14 days before arrival
        public bool IsDepositDue(DateTime today)
        {
            DateTime dueDate = checkInDate.AddDays(-14);
            return today.Date >= dueDate;
        }

        public void Confirm()
        {
            status = BookingStatus.Confirmed;
        }

        public void Cancel()
        {
            status = BookingStatus.Cancelled;
        }

        public string GenerateBookingRef()
        {
            string prefix = "REF";
            int sequenceNumber = new Random().Next(1, 100000);
            return $"{prefix}{sequenceNumber:D5}";
        }
        public string GenerateGuestID()
        {
            string prefix = "GST";
            int sequenceNumber = new Random().Next(1, 100000);
            return $"{prefix}{sequenceNumber:D5}";
        }
        #endregion

    }

}
