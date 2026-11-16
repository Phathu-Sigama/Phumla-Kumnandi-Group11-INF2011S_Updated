using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class BookingController
    {
        #region Data Members
        private BookingDB bookingDB;
        private Collection<Booking> bookings;
        #endregion

        #region Properties
        public Collection<Booking> AllBookings
        {
            get { return bookings; }
        }
        #endregion

        #region Constructor
        public BookingController()
        {
            bookingDB = new BookingDB();
            bookings = bookingDB.AllBookings;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Booking booking)
        {
            bookingDB.DataSetChange(booking);
            if (!bookings.Contains(booking))
            {
                bookings.Add(booking);
            }
        }

        public bool FinalizeChanges(Booking booking)
        {
            return bookingDB.UpdateDataSource(booking);
        }
        #endregion

        #region Finders
        public Booking FindBooking(string bookingID)
        {
            foreach (Booking b in bookings)
            {
                if (b.BookingID == bookingID)
                {
                    return b;
                }
            }
            return null;
        }
        #endregion

        #region Business Logic

        // Reserve a new booking
        public Booking ReserveBooking(string guestID, DateTime checkIn, DateTime checkOut,
                                     int numGuests, int numRooms, string cardNumber)
        {
            string bookingRef = GenerateBookingRef();

            Booking newBooking = new Booking(bookingRef, guestID, "",
                                    checkIn, checkOut,
                                    Booking.BookingStatus.Unconfirmed,
                                    numGuests, numRooms, cardNumber);

            DataMaintenance(newBooking);
            FinalizeChanges(newBooking);
            return newBooking;
        }

        // Check room availability
        public List<Room> CheckRoomAvailability(DateTime checkIn, DateTime checkOut, int numRooms)
        {
            RoomController roomController = new RoomController();
            Collection<Room> availableRooms = roomController.FindAvailability(checkIn, checkOut);

            if (availableRooms.Count >= numRooms)
            {
                return availableRooms.Take(numRooms).ToList();
            }
            else
            {
                return new List<Room>(); // not enough available rooms
            }
        }

        // Update an existing booking
        public void UpdateBooking(string bookingID)
        {
            Booking existingBooking = FindBooking(bookingID);
            if (existingBooking != null)
            {
                DataMaintenance(existingBooking);
                FinalizeChanges(existingBooking);
            }
        }

        // Cancel a booking
        public void Cancel(string bookingID)
        {
            Booking bookingToCancel = FindBooking(bookingID);
            if (bookingToCancel != null)
            {
                bookingToCancel.Status = Booking.BookingStatus.Cancelled;
                DataMaintenance(bookingToCancel);
                FinalizeChanges(bookingToCancel);
            }
        }

        // Generate a new unique guest ID
        public string GenerateGuestID()
        {
            return "GUEST" + DateTime.Now.Ticks.ToString();
        }

        // Generate a new unique booking reference
        public string GenerateBookingRef()
        {
            return "REF" + DateTime.Now.Ticks.ToString();
        }

        #endregion
    }
}