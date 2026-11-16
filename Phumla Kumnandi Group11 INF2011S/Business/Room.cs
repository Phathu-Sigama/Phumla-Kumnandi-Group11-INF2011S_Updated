using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class Room
    {
        public enum RoomStatus { Available, Occupied, OutOfService }

        #region Attributes
        private string hotelID;
        private string roomNumber;
        private RoomStatus status;
        public string HotelID
        {
            get { return hotelID; }
            set { hotelID = value; }
        }
        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }
        public RoomStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion
        #region Constructors
        public Room() { }

        public Room(string hotelID, string roomNumber, RoomStatus status)
        {
            this.HotelID = hotelID;
            this.RoomNumber = roomNumber;
            this.Status = status;
        }
        #endregion
        #region Methods
        public bool IsAvailable()
        {
            return status == RoomStatus.Available;
        }
        public void MarkAsOccupied()
        {
            status = RoomStatus.Occupied;
        }
        public void MarkAsAvailable()
        {
            status = RoomStatus.Available;
        }
        public void MarkAsServicing()
        {
            Status = RoomStatus.OutOfService;
        }


        public string GetStatus()
        {
            return status.ToString();
        }
        #endregion
    }
}
