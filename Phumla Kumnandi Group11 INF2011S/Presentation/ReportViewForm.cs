using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    public partial class ReportViewForm: Form
    {
        private string connectString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\PhumlaKamnandiHotels.mdf;Integrated Security=True";
        public ReportViewForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripExitReport_ButtonClick(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm(); // Return to StartForm
            startForm.Show();
            this.Hide();
        }

        private void toolStripButtonExitReportView_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm(); // Return to StartForm
            startForm.Show();
            this.Hide();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString();
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Please select a report type.", "Missing Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be after end date.", "Invalid Dates",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (reportType == "Occupancy Report")
            {
                LoadOccupancyReport(startDate, endDate);
            }
            else if (reportType == "Revenue Report")
            {
                LoadRevenueReport(startDate, endDate);
            }
        }

        private void LoadOccupancyReport(DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string query = @"SELECT occupancyReportID, reportID, startDate, endDate, totalRooms, averageOccupancyRate
                         FROM OccupancyReport
                         WHERE startDate >= @StartDate AND endDate <= @EndDate";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvReport.DataSource = dt;
                }
            }
                

        }

        private void LoadRevenueReport(DateTime startDate, DateTime endDate)
        {

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string query = @"SELECT revenueReportID, reportID,startDate, endDate, totalRevenue, averageDailyRevenue, totalBookings
                         FROM RevenueReport
                         WHERE startDate >= @StartDate AND endDate <= @EndDate";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvReport.DataSource = dt;
                }
            }
               
        }
    }
}
