using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class RoomService
    {
        public string ServiceID { get; set; }
        public string RoomNumber { get; set; }
        public ServiceType Type { get; set; }
        public double Cost { get; set; }

        public enum ServiceType
        {
            Room,
            Food,
            Beverage,
            Laundry,
            Cleaning,
            Maintenance,
            Other
        }

        public RoomService(string serviceID, string roomNumber, ServiceType type, double cost)
        {
            ServiceID = serviceID;
            RoomNumber = roomNumber;
            Type = type;
            Cost = cost;
        }

        public double GetCost()
        {
            return Cost;
        }
    }
}
