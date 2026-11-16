using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class LoyaltyMember
    {
        public enum Tier { None, Bronze, Silver, Gold }

        #region Attributes
        private string memberID;
        private string guestID;
        private int points;
        private Tier currentTier;
        private decimal discountPercent;

        public string MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public string GuestID
        {
            get { return guestID; }
            set { guestID = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Tier CurrentTier
        {
            get { return currentTier; }
            set { currentTier = value; }
        }

        public decimal DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }
        #endregion

        #region Constructors
        public LoyaltyMember() { }

        public LoyaltyMember(string memberID, string guestID, int points,
                             Tier currentTier, decimal discountPercent)
        {
            this.MemberID = memberID;
            this.GuestID = guestID;
            this.Points = points;
            this.CurrentTier = currentTier;
            this.DiscountPercent = discountPercent;
        }
        #endregion

        #region Methods
        public void AddPoints(int value)
        {
            points += value;
            currentTier = GetTierFor(points);
            discountPercent = GetDiscountFor(currentTier);
        }

        public void ResetPoints()
        {
            points = 0;
            currentTier = Tier.None;
            discountPercent = 0m;
        }

        public decimal GetDiscount()
        {
            return discountPercent;
        }

        public Tier GetTierFor(int p)
        {
            if (p >= 20)
            {
                return Tier.Gold;
            }
            else if (p >= 10)
            {
                return Tier.Silver;
            }
            else if (p >= 5)
            {
                return Tier.Bronze;
            }
            return Tier.None;
        }

        public decimal GetDiscountFor(Tier tier)
        {
            if (tier == Tier.Bronze)
            {
                return 0.03m;
            }
            if (tier == Tier.Silver)
            {
                return 0.05m;
            }
            if (tier == Tier.Gold)
            {
                return 0.08m;
            }
            return 0.00m;
        }
        #endregion
    }
}