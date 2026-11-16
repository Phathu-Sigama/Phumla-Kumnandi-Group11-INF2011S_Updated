using Phumla_Kumnandi_Group11_INF2011S.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class RoomController
    {
        #region Data Members
        private RoomDB roomDB;
        private RoomAllocationDB allocationDB;
        private Collection<Room> rooms;
        private Collection<RoomAllocation> allocations;
        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get { return rooms; }
        }
        public Collection<RoomAllocation> AllAllocations
        {
            get { return allocations; }
        }
        #endregion

        #region Constructor
        public RoomController()
        {
            roomDB = new RoomDB();
            allocationDB = new RoomAllocationDB();
            rooms = roomDB.AllRooms;
            allocations = allocationDB.AllAllocations;
        }
        #endregion

        #region Database Communication
        // Adds or updates a room in the in-memory dataset
        public void DataMaintenance(Room room)
        {
            roomDB.DataSetChange(room);
            if (!rooms.Contains(room))
            {
                rooms.Add(room);
            }
        }

        // Saves any room changes to the database
        public bool FinalizeChanges(Room room)
        {
            return roomDB.UpdateDataSource(room);
        }
        #endregion

        #region Core Methods
        // Gets total number of rooms in the hotel
        public int GetTotalRooms()
        {
            if (rooms == null) return 0;
            return rooms.Count;
        }

        // Gets number of available rooms in a date range
        public int NumAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            Collection<Room> available = FindAvailability(checkIn, checkOut);
            return available.Count;
        }

        // Finds all rooms available for the date range
        public Collection<Room> FindAvailability(DateTime checkIn, DateTime checkOut)
        {
            Collection<Room> availableRooms = new Collection<Room>();
            if (rooms == null) return availableRooms;

            for (int i = 0; i < rooms.Count; i++)
            {
                Room r = rooms[i];
                bool occupied = false;

                // Check all allocations to see if this room is already booked
                for (int j = 0; j < allocations.Count; j++)
                {
                    RoomAllocation a = allocations[j];
                    if (a.RoomNumber == r.RoomNumber &&
                        a.Status == RoomAllocation.AllocationStatus.Allocated)
                    {
                        // Simple overlap rule: starts before end AND ends after start
                        if (a.StartDate < checkOut && a.EndDate > checkIn)
                        {
                            occupied = true;
                            break;
                        }
                    }
                }

                if (!occupied && r.Status == Room.RoomStatus.Available)
                {
                    availableRooms.Add(r);
                }
            }
            return availableRooms;
        }

        // Checks if the hotel is fully booked for a specific day
        public bool IsFullyBooked(DateTime date)
        {
            if (rooms == null || rooms.Count == 0) return false;

            int total = rooms.Count;
            int available = NumAvailableRooms(date, date.AddDays(1));
            return available == 0 && total > 0;
        }

        public bool IsFullyBookedRange(DateTime startDateInclusive, DateTime endDateExclusive)
        {
            // Checks each NIGHT in [startDateInclusive, endDateExclusive)
            DateTime d = startDateInclusive;
            while (d < endDateExclusive)
            {
                if (!IsFullyBooked(d))
                {
                    return false;
                }
                d = d.AddDays(1);
            }
            return true;
        }
        #endregion
    }

}
