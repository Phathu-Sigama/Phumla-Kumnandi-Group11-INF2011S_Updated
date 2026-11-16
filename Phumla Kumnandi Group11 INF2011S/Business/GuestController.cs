using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class GuestController
    {
        #region Data Members
        private GuestDB guestDB;
        private Collection<Guest> guests;
        #endregion

        #region Properties
        public Collection<Guest> AllGuests
        {
            get { return guests; }
        }
        #endregion

        #region Constructor
        public GuestController()
        {
            guestDB = new GuestDB();
            guests = guestDB.AllGuests;
        }
        #endregion

        #region Database Communication
        // Adds a new guest record to the in-memory dataset
        public void AddGuest(Guest guest)
        {
            guestDB.DataSetChange(guest);
            if (!guests.Contains(guest))
            {
                guests.Add(guest);
            }
        }

        // Updates an existing guest’s details
        public void UpdateGuest(Guest guest)
        {
            guestDB.DataSetChange(guest);      // mark as modified
        }

        // Commits any pending changes in memory to the database
        public bool FinalizeChanges(Guest guest)
        {
            return guestDB.UpdateDataSource(guest);
        }
        #endregion

        #region Finders
        // Find a guest by first and last name
        public Guest FindGuest(string firstName, string lastName)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                if (guests[i].FirstName == firstName && guests[i].LastName == lastName)
                {
                    return guests[i];
                }
            }
            return null;
        }
        #endregion

        #region ID Generation
        private string GenerateGuestID()
        {
            return "GST" + DateTime.Now.Ticks.ToString();
        }
        #endregion
    }
}
