using System;
using System.Collections.ObjectModel;
using Phumla_Kumnandi_Group11_INF2011S.Business;
using Phumla_Kumnandi_Group11_INF2011S.Data;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class Receptionist : Employee
    {
        #region Constructors
        public Receptionist() { }

        public Receptionist(string employeeID, string firstName, string lastName,
                           string streetAddress, string postalCode, string role)
            : base(employeeID, firstName, lastName, streetAddress, postalCode, role)
        {
        }
        #endregion

        #region Methods

        // Allows receptionist to select a date range for occupancy report generation
        public string ChooseDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                return "Error: Start date cannot be after end date.";

            if (startDate == endDate)
                return $"Occupancy report for {startDate:yyyy-MM-dd}";

            TimeSpan duration = endDate - startDate;
            return $"Occupancy report from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd} ({duration.Days + 1} days)";
        }


        // Allows receptionist to create a new booking for a guest
        public string ReserveBooking(string guestID, DateTime checkIn, DateTime checkOut,
                                     int numGuests, int numRooms, string cardNumber)
        {
            BookingController bookingCtrl = new BookingController();
            Booking newBooking = bookingCtrl.ReserveBooking(guestID, checkIn, checkOut, numGuests, numRooms, cardNumber);

            bool success = bookingCtrl.FinalizeChanges(newBooking);
            return success
                ? $"Booking created successfully. Reference: {newBooking.BookingID}"
                : "Error: Booking could not be created.";
        }

        // Allows receptionist to cancel an existing booking
        public string CancelBooking(string bookingID)
        {
            BookingController bookingCtrl = new BookingController();
            Booking existingBooking = bookingCtrl.FindBooking(bookingID);

            if (existingBooking == null)
                return "No booking found with the specified reference.";

            existingBooking.Status = Booking.BookingStatus.Cancelled;
            bookingCtrl.DataMaintenance(existingBooking);
            bool success = bookingCtrl.FinalizeChanges(existingBooking);

            return success
                ? $"Booking {bookingID} successfully cancelled."
                : $"Error: Could not cancel booking {bookingID}.";
        }

        // Allows receptionist to enquire about an existing booking
        public string EnquireBooking(string bookingID)
        {
            BookingController bookingCtrl = new BookingController();
            Booking foundBooking = bookingCtrl.FindBooking(bookingID);

            if (foundBooking == null)
                return "No booking found for the given reference.";

            return $"Booking found: GuestID {foundBooking.GuestID}, " +
                   $"Check-in {foundBooking.CheckInDate:yyyy-MM-dd}, " +
                   $"Check-out {foundBooking.CheckOutDate:yyyy-MM-dd}, " +
                   $"Rooms {foundBooking.NumRooms}, Status {foundBooking.Status}";
        }

        #endregion
    }
}
