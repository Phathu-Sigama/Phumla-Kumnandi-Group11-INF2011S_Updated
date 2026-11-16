using Phumla_Kumnandi_Group11_INF2011S.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    public partial class BookingEnquiryForm: Form
    {
        private string connectString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\PhumlaKamnandiHotels.mdf;Integrated Security=True";
        public BookingEnquiryForm()
        {
            InitializeComponent();
        }

        private void btnSearchBookingEnquiry_Click(object sender, EventArgs e)
        {
            // Validation for booking reference
            string bookingid = txtBookingIDEnquiry.Text;
            string pattern = @"^[A-Za-z]{3}\d{5}$";

            if (!string.IsNullOrEmpty(bookingid) && !Regex.IsMatch(bookingid, pattern))
            {
                MessageBox.Show("Booking ID must be 3 letters followed by 5 digits (e.g., ABC12345)",
                                "Invalid Booking ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string query = @"SELECT bookingID AS [Booking Reference],guestID AS [Guest ID], checkInDate AS [Check-In Date], checkOutDate AS [Check-Out Date], numGuests AS [Guests], numRooms AS [Rooms], depositAmount AS [Deposit Amount], isDepositPaid AS [Deposit Paid], status AS [Booking Status], depositPaidDate AS [Deposit Paid Date], depositDueDate AS [Deposit Due Date]
                                FROM Booking                                
                                WHERE bookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    

                    if (dt.Rows.Count > 0)
                    {

                        dataGridViewBookingEnquiry.DataSource = dt;

                        dataGridViewBookingEnquiry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                       

                        bool isDepositPaid = Convert.ToBoolean(dt.Rows[0]["Deposit Paid"]);

                        string statusText = isDepositPaid ? "Confirmed (Deposit Paid)" : "Unconfirmed (Deposit Pending)";

                        MessageBox.Show($"Booking Status: {statusText}", "Booking Enquiry", MessageBoxButtons.OK,

                            isDepositPaid ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    }
                    else
                    {

                        dataGridViewBookingEnquiry.DataSource = null;

                        MessageBox.Show("No booking found with that reference ID.", "Not Found",

                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }



                }
            }

        }
    }
}
