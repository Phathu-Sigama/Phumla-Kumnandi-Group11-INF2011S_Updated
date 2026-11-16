using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumla_Kumnandi_Group11_INF2011S.Business
{
    public class Report
    {
        #region Attributes
        private string reportID;
        private DateTime generatedDate;

        public string ReportID { get { return reportID; } set { reportID = value; } }
        public DateTime GeneratedDate { get { return generatedDate; } set { generatedDate = value; } }
        #endregion
    }
}
