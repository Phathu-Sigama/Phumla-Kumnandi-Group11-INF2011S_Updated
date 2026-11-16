using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    public partial class HomeForm: Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void toolStripBtnExit_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm(); // Return to StartForm
            startForm.Show();
            this.Hide();
        }

        private void makeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingForm bookingForm = new BookingForm(); // Open BookingForm
            bookingForm.ShowDialog();
        }

        private void changeBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBookingForm changeBookingForm = new ChangeBookingForm(); // Open ChangeBookingForm
            changeBookingForm.ShowDialog();
        }

        private void enquireBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingEnquiryForm bookingEnquiryForm = new BookingEnquiryForm(); // Open BookingEnquiryForm
            bookingEnquiryForm.ShowDialog();
        }

        private void cancelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelBookingForm cancelBookingForm = new CancelBookingForm(); // Open CancelBookingForm
            cancelBookingForm.ShowDialog();
        }

        private void bookingConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookingConfirmationForm bookingConfirmationForm = new BookingConfirmationForm(); // Open BookingConfirmationForm
            bookingConfirmationForm.ShowDialog();
        }
    }
}
