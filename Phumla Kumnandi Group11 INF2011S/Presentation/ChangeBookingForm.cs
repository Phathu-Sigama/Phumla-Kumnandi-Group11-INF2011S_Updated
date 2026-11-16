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
    public partial class ChangeBookingForm: Form
    {
        private string connectString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\PhumlaKamnandiHotels.mdf;Integrated Security=True";
        public ChangeBookingForm()
        {
            InitializeComponent();
        }

        private void btnSearchBooking_Click(object sender, EventArgs e)
        {
            string bookingid = txtBookingID.Text;

            if (string.IsNullOrWhiteSpace(bookingid))
            {
                MessageBox.Show("Please enter a booking reference ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            using (SqlConnection conn  = new SqlConnection(connectString))
            {
                string query = @"SELECT b.bookingID ,g.firstName, g.lastName, b.checkInDate, b.checkOutDate, b.NumRooms, b.NumGuests
                                FROM Booking b 
                                INNER JOIN Guest g ON b.guestID = g.guestID 
                                WHERE b.bookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingid);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstNameChange.Text = reader["firstName"].ToString();
                        txtLastNameChange.Text = reader["lastName"].ToString();
                        dateTimePickerCheckInChange.Value = Convert.ToDateTime(reader["checkInDate"]);
                        dateTimePickerCheckOutChange.Value = Convert.ToDateTime(reader["checkOutDate"]);
                        txtRoomNumbersChange.Text = reader["numRooms"].ToString();
                        txtGuestNumberChange.Text = reader["numGuests"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Booking not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearFields();
                        
                    }
                    conn.Close();


                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validation for booking reference
            string bookingid = txtBookingID.Text;
            string pattern = @"^[A-Za-z]{3}\d{5}$";

            if (!string.IsNullOrEmpty(bookingid) && !Regex.IsMatch(bookingid, pattern))
            {
                MessageBox.Show("Booking ID must be 3 letters followed by 5 digits (e.g., ABC12345)",
                                "Invalid Booking ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            // Validate First Name
            if (string.IsNullOrWhiteSpace(txtFirstNameChange.Text) || !Regex.IsMatch(txtFirstNameChange.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First name should contain only letters", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstNameChange.Focus();
                return;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txtLastNameChange.Text) || !Regex.IsMatch(txtLastNameChange.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last name should contain only letters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastNameChange.Focus();
                return;
            }

            // Validate Room Numbers
            if (string.IsNullOrWhiteSpace(txtRoomNumbersChange.Text) || !IsValidRoomNumber(txtRoomNumbersChange.Text))
            {
                MessageBox.Show("Please enter a number between 1 and 5", "Invalid Room Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomNumbersChange.Focus();
                return;
            }

            // Validate Guest Number
            if (string.IsNullOrWhiteSpace(txtGuestNumberChange.Text) || !IsValidGuestNumber(txtGuestNumberChange.Text))
            {
                MessageBox.Show("Please enter a valid number of guests (up to 4 guests)", "Invalid Guest Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestNumberChange.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string updateQuery = @"UPDATE Booking SET checkInDate = @CheckIn, checkOutDate = @CheckOut, numRooms = @NumRooms, numGuests = @NumGuests WHERE bookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingid);
                    cmd.Parameters.AddWithValue("@CheckIn", dateTimePickerCheckInChange.Value);
                    cmd.Parameters.AddWithValue("@CheckOut", dateTimePickerCheckOutChange.Value);
                    cmd.Parameters.AddWithValue("@NumRooms", txtRoomNumbersChange.Text);
                    cmd.Parameters.AddWithValue("@NumGuests", txtGuestNumberChange.Text);


                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Booking successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }



            }
        }

        private void ClearFields()
        {
            txtFirstNameChange.Clear();
            txtLastNameChange.Clear();
            txtRoomNumbersChange.Clear();
            txtGuestNumberChange.Clear();
            dateTimePickerCheckInChange.Value = DateTime.Today;
            dateTimePickerCheckOutChange.Value = DateTime.Today;
        }

        private bool IsValidRoomNumber(string roomNumber)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
                return false;

            // Try to parse as integer
            if (int.TryParse(roomNumber, out int rooms))
            {
                // Must be between 1 and 5
                return rooms >= 1 && rooms <= 5;
            }

            return false;
        }

        private bool IsValidGuestNumber(string guestNumber)
        {
            if (string.IsNullOrWhiteSpace(guestNumber)) return false;

            // Try to parse as integer
            if (int.TryParse(guestNumber, out int guests))
            {
                // Must be atleast 4
                return guests <= 4;
            }

            return false;
        }


    }
}
