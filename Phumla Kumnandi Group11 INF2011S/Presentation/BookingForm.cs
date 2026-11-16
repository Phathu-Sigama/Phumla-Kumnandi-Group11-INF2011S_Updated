using Phumla_Kumnandi_Group11_INF2011S.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    public partial class BookingForm : Form
    {
        private RoomController roomController = new RoomController();

        public BookingForm()
        {
            InitializeComponent();
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            DateTime checkIn = dateTimePickerCheckIn.Value;
            DateTime checkOut = dateTimePickerCheckOut.Value;

            if (checkOut <= checkIn)// validate checkin and checkout dates
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate Room Numbers
            if (string.IsNullOrWhiteSpace(txtRoomNumbers.Text) || !IsValidRoomNumber(txtRoomNumbers.Text))
            {
                MessageBox.Show("Please enter a number between 1 and 5", "Invalid Room Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomNumbers.Focus();
                return;
            }

            // Validate Guest Number
            if (string.IsNullOrWhiteSpace(txtGuestNumber.Text) || !IsValidGuestNumber(txtGuestNumber.Text))
            {
                MessageBox.Show("Please enter a valid number of guests (up to 4 guests)", "Invalid Guest Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestNumber.Focus();
                return;
            }
            Collection<Room> availableRooms = roomController.FindAvailability(checkIn, checkOut);

            dgvRoomAvailability.DataSource = availableRooms;
            dgvRoomAvailability.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomAvailability.ReadOnly = true;


        }

        private string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\PhumlaKamnandiHotels.mdf;Integrated Security=True";
        private void btnSearchGuest_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            // Validate First Name
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First name should contain only letters", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(txtLastName.Text) || !Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last name should contain only letters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Guest WHERE firstName = @FirstName AND lastName = @LastName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string guestID = reader["guestID"].ToString();
                        //populate fields if an existing guest
                        txtEmail.Text = reader["email"].ToString();
                        txtPhoneNumber.Text = reader["phone"].ToString();
                        txtAddress.Text = reader["address"].ToString();
                        txtPostalCode.Text = reader["postalCode"].ToString();

                        txtEmail.ReadOnly = true;
                        txtPhoneNumber.ReadOnly = true;
                        txtAddress.ReadOnly = true;
                        txtPostalCode.ReadOnly = true;

                        reader.Close();


                        string bookingQuery = @"SELECT TOP 1 cardNumber 
                                    FROM Booking 
                                    WHERE guestID = @GuestID"; 
                                   
                        using (SqlCommand bookingCmd = new SqlCommand(bookingQuery, conn))
                        {
                            bookingCmd.Parameters.AddWithValue("@GuestID",guestID);

                            object cardNumberObj = bookingCmd.ExecuteScalar();
                            if (cardNumberObj != null)
                            {
                                txtCardNumber.Text = cardNumberObj.ToString();
                                txtCardNumber.ReadOnly = true;
                            }
                            else
                            {
                                txtCardNumber.Text = "";
                                txtCardNumber.ReadOnly = false;
                            }
                        }

                        MessageBox.Show("Existing Guest Found!", "", MessageBoxButtons.OK);

                    }
                    else
                    {
                        //manually input information if new guest
                        txtEmail.Text = "";
                        txtPhoneNumber.Text = "";
                        txtAddress.Text = "";
                        txtPostalCode.Text = "";

                        txtEmail.ReadOnly = false;
                        txtPhoneNumber.ReadOnly = false;
                        txtAddress.ReadOnly = false;
                        txtPostalCode.ReadOnly = false;

                        MessageBox.Show("New guest. Please fill in the details.", "", MessageBoxButtons.OK);

                    }
                }





            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            // Validate Phone Number
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || !IsValidPhoneNumber(txtPhoneNumber.Text))
            {
                MessageBox.Show("Please enter a valid phone number of 10 digits (e.g., 0215551234)", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }

            // Validate Postal Code
            if (string.IsNullOrWhiteSpace(txtPostalCode.Text) || !IsValidPostalCode(txtPostalCode.Text))
            {
                MessageBox.Show("Please enter a valid 4 digit postal code", "Invalid Postal Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPostalCode.Focus();
                return;
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validate Address
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter an address", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string address = txtAddress.Text.Trim();
            string postalCode = txtPostalCode.Text.Trim();
            string cardNumber = txtCardNumber.Text.Trim();
            DateTime checkIn = dateTimePickerCheckIn.Value;
            DateTime checkOut = dateTimePickerCheckOut.Value;
            int guestCount = int.Parse(txtGuestNumber.Text);
            int roomCount = int.Parse(txtRoomNumbers.Text);

            string guestID = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                
                string findGuestQuery = "SELECT guestID FROM Guest WHERE firstName = @FirstName AND lastName = @LastName";
                using (SqlCommand findGuestCmd = new SqlCommand(findGuestQuery, conn))
                {
                    findGuestCmd.Parameters.AddWithValue("@FirstName", firstName);
                    findGuestCmd.Parameters.AddWithValue("@LastName", lastName);

                    object result = findGuestCmd.ExecuteScalar();
                    if (result != null)
                    {
                        guestID = result.ToString(); // Existing guest
                    }
                    else
                    {
                        
                        string getMaxGuestIDQuery = "SELECT MAX(guestID) FROM Guest";
                        using (SqlCommand maxGuestCmd = new SqlCommand(getMaxGuestIDQuery, conn))
                        {
                            object maxGuestIDObj = maxGuestCmd.ExecuteScalar();
                            if (maxGuestIDObj != DBNull.Value && maxGuestIDObj != null)
                            {
                                string lastGuestID = maxGuestIDObj.ToString();
                                int lastNum = int.Parse(lastGuestID.Substring(3)); 
                                guestID = "GST" + (lastNum + 1).ToString("D5"); 
                            }
                            else
                            {
                                guestID = "GST00001"; 
                            }
                        }

                        
                        string insertGuestQuery = @"INSERT INTO Guest (guestID, firstName, lastName, email, phone, address, postalCode)
                                            VALUES (@GuestID, @FirstName, @LastName, @Email, @Phone, @Address, @PostalCode)";
                        using (SqlCommand insertGuestCmd = new SqlCommand(insertGuestQuery, conn))
                        {
                            insertGuestCmd.Parameters.AddWithValue("@GuestID", guestID);
                            insertGuestCmd.Parameters.AddWithValue("@FirstName", firstName);
                            insertGuestCmd.Parameters.AddWithValue("@LastName", lastName);
                            insertGuestCmd.Parameters.AddWithValue("@Email", email);
                            insertGuestCmd.Parameters.AddWithValue("@Phone", phone);
                            insertGuestCmd.Parameters.AddWithValue("@Address", address);
                            insertGuestCmd.Parameters.AddWithValue("@PostalCode", postalCode);
                            insertGuestCmd.ExecuteNonQuery();
                        }
                    }
                }

               
                string bookingID;
                string getMaxBookingIDQuery = "SELECT MAX(bookingID) FROM Booking";
                using (SqlCommand maxBookingCmd = new SqlCommand(getMaxBookingIDQuery, conn))
                {
                    object maxBookingIDObj = maxBookingCmd.ExecuteScalar();
                    if (maxBookingIDObj != DBNull.Value && maxBookingIDObj != null)
                    {
                        string lastBookingID = maxBookingIDObj.ToString(); 
                        int lastNum = int.Parse(lastBookingID.Substring(3));
                        bookingID = "REF" + (lastNum + 1).ToString("D5");
                    }
                    else
                    {
                        bookingID = "REF00001";
                    }
                }

                
                string insertBookingQuery = @"INSERT INTO Booking 
                                      (bookingID, guestID, checkInDate, checkOutDate, numRooms, numGuests, cardNumber)
                                      VALUES 
                                      (@BookingID, @GuestID, @CheckIn, @CheckOut, @numRooms, @numGuests, @CardNumber)";
                using (SqlCommand insertBookingCmd = new SqlCommand(insertBookingQuery, conn))
                {
                    insertBookingCmd.Parameters.AddWithValue("@BookingID", bookingID);
                    insertBookingCmd.Parameters.AddWithValue("@GuestID", guestID);
                    insertBookingCmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    insertBookingCmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    insertBookingCmd.Parameters.AddWithValue("@numRooms", roomCount);
                    insertBookingCmd.Parameters.AddWithValue("@numGuests", guestCount);
                    insertBookingCmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                    insertBookingCmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Booking created successfully!\n\nBooking Reference: {bookingID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        
        

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Email regex pattern
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);

        }

        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Remove all non-digit characters
            string digitsOnly = Regex.Replace(phone, @"\D", "");

            // Check if exactly 10 digits remain
            return digitsOnly.Length == 10;
        }

        private bool IsValidPostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
                return false;

            // 4 digit postal code
            return Regex.IsMatch(postalCode, @"^\d{4}$");


        }

        private bool IsValidCardNumber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            // Remove spaces and dashes
            string cleanCard = cardNumber.Replace("-", "").Replace(" ", "");

            if (cleanCard.Length != 16)
                return false;

            // Check if all digits
            return Regex.IsMatch(cleanCard, @"^\d{16}$");
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

        private void BookingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
