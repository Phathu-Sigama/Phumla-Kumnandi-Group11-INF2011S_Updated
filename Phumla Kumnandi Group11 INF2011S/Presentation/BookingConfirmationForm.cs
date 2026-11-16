using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    public partial class BookingConfirmationForm: Form
    {
        private string connectString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\PhumlaKamnandiHotels.mdf;Integrated Security=True"; 
        public BookingConfirmationForm()
        {
            InitializeComponent();
        }

        private void btnSearchBookingConfirmation_Click(object sender, EventArgs e)
        {
            string bookingID = txtBookingConfirmation.Text.Trim();

            if (string.IsNullOrWhiteSpace(bookingID))
            {
                MessageBox.Show("Please enter a booking reference ID.", "Missing Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
            }

            DisplayConfirmation(bookingID);
        }

        private void DisplayConfirmation(string bookingID)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                string query = @"SELECT 
                                    b.bookingID,
                                    g.firstName,
                                    g.lastName,
                                    b.checkInDate,
                                    b.checkOutDate,
                                    b.numRooms,
                                    b.numGuests,
                                    b.depositAmount,
                                    b.isDepositPaid,
                                    b.depositPaidDate,
                                    b.status
                                 FROM Booking b
                                 INNER JOIN Guest g ON b.guestID = g.guestID
                                 WHERE b.bookingID = @BookingID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isDepositPaid = Convert.ToBoolean(reader["isDepositPaid"]);

                        if (isDepositPaid)
                        {
                            StringBuilder letter = new StringBuilder();
                            letter.AppendLine("==============================================");
                            letter.AppendLine("          Phumla Kamnandi Hotel");
                            letter.AppendLine("           BOOKING CONFIRMATION");
                            letter.AppendLine("==============================================\n");
                            letter.AppendLine($"Booking Reference: {reader["bookingID"]}");
                            letter.AppendLine($"Guest Name: {reader["firstName"]} {reader["lastName"]}");
                            letter.AppendLine($"Check-In Date: {Convert.ToDateTime(reader["checkInDate"]).ToShortDateString()}");
                            letter.AppendLine($"Check-Out Date: {Convert.ToDateTime(reader["checkOutDate"]).ToShortDateString()}");
                            letter.AppendLine($"Rooms Booked: {reader["numRooms"]}");
                            letter.AppendLine($"Guests: {reader["numGuests"]}");
                            letter.AppendLine($"Deposit Amount: R{reader["depositAmount"]}");
                            letter.AppendLine($"Deposit Paid On: {Convert.ToDateTime(reader["depositPaidDate"]).ToShortDateString()}");
                            letter.AppendLine($"\nBooking Status: CONFIRMED ");
                            letter.AppendLine("\nThank you for choosing Phumla Kamnandi. We look forward to hosting you!");
                            letter.AppendLine("\n==============================================");

                            rtbConfirmation.Text = letter.ToString();
                        }
                        else
                        {
                            rtbConfirmation.Text =
                                "==============================================\n" +
                                "          Phumla Kamnandi Hotel\n" +
                                "           BOOKING PENDING\n" +
                                "==============================================\n\n" +
                                $"Booking Reference: {reader["bookingID"]}\n" +
                                $"Guest: {reader["firstName"]} {reader["lastName"]}\n\n" +
                                "This booking is not yet confirmed.\nDeposit payment is still pending.\n\n" +
                                "==============================================";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No booking found with that reference ID.", "Not Found",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rtbConfirmation.Clear();
                    }

                    conn.Close();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookingConfirmation.Clear();
            rtbConfirmation.Clear();
        }
    }
        
           
}
