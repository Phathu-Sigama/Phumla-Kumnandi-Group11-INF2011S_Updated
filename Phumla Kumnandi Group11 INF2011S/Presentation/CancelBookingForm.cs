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
    public partial class CancelBookingForm: Form
    {
        private string connectString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\PhumlaKamnandiHotels.mdf;Integrated Security=True";
        public CancelBookingForm()
        {
            InitializeComponent();
        }
        
        private void btnSearchBookingCancel_Click(object sender, EventArgs e)
        {
            // Validation for booking reference
            string bookingID = txtBookingIDCancel.Text;
            string pattern = @"^[A-Za-z]{3}\d{5}$";

            if (!string.IsNullOrEmpty(bookingID) && !Regex.IsMatch(bookingID, pattern))
            {
                MessageBox.Show("Booking ID must be 3 letters followed by 5 digits (e.g., ABC12345)",
                                "Invalid Booking ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            using (SqlConnection conn = new SqlConnection (connectString))
            {
                string query = @"SELECT b.bookingID AS [Booking Reference],g.firstName AS [Guest First Name], g.lastName AS [Guest Last Name], b.checkInDate AS [Check-In Date], b.checkOutDate AS [Check-Out Date], b.status AS [Booking Status]
                                FROM Booking b 
                                INNER JOIN Guest g ON b.guestID = g.guestID 
                                WHERE b.bookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvCancelBooking.DataSource = dt;
                        dgvCancelBooking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                          
                    }
                    else
                    {
                        dgvCancelBooking.DataSource = null;
                        MessageBox.Show("No booking found with that reference ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


            }


           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvCancelBooking.DataSource == null || dgvCancelBooking.Rows.Count == 0)
            {
                MessageBox.Show("Please search and select a booking to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string bookingID = txtBookingIDCancel.Text.Trim();

            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this booking?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string query = "UPDATE Booking SET Status = 'Cancelled' WHERE bookingID = @BookingID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", bookingID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking successfully cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBookingIDCancel.Clear();
                            dgvCancelBooking.DataSource = null;
                        }
                        else
                        {
                            MessageBox.Show("Cancellation failed. Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        
    }
}
