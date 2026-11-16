using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class SeasonalRate
    {
        public enum SeasonType { Low, Mid, High }

        #region Attributes
        private string rateID;
        private SeasonType season;
        private DateTime startDate;
        private DateTime endDate;
        private decimal ratePerNight;

        public string RateID
        {
            get { return rateID; }
            set { rateID = value; }
        }
        public SeasonType Season
        {
            get { return season; }
            set { season = value; }
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
        public decimal RatePerNight
        {
            get { return ratePerNight; }
            set { ratePerNight = value; }
        }
        #endregion
        #region Constructors
        public SeasonalRate() { }

        public SeasonalRate(string rateID, SeasonType season, DateTime startDate, DateTime endDate, decimal ratePerNight)
        {
            this.RateID = rateID;
            this.Season = season;
            this.StartDate = startDate.Date;
            this.EndDate = endDate.Date;
            this.RatePerNight = ratePerNight;
        }
        #endregion
        #region Methods
        public bool IncludesDate(DateTime date)
        {
            DateTime d = date.Date;
            return d >= startDate.Date && d <= endDate.Date;
        }
        #endregion

    }
}
