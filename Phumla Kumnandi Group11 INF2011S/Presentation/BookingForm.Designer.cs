namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    partial class BookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbguestDetails = new System.Windows.Forms.GroupBox();
            this.cbLoyaltyMember = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnSearchGuest = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.gbReservationDetails = new System.Windows.Forms.GroupBox();
            this.dgvRoomAvailability = new System.Windows.Forms.DataGridView();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.txtGuestNumber = new System.Windows.Forms.TextBox();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblGuestNumber = new System.Windows.Forms.Label();
            this.txtRoomNumbers = new System.Windows.Forms.TextBox();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblRoomNumbers = new System.Windows.Forms.Label();
            this.gbguestDetails.SuspendLayout();
            this.gbReservationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomAvailability)).BeginInit();
            this.SuspendLayout();
            // 
            // gbguestDetails
            // 
            this.gbguestDetails.BackColor = System.Drawing.Color.Transparent;
            this.gbguestDetails.Controls.Add(this.cbLoyaltyMember);
            this.gbguestDetails.Controls.Add(this.btnSubmit);
            this.gbguestDetails.Controls.Add(this.txtCardNumber);
            this.gbguestDetails.Controls.Add(this.txtAddress);
            this.gbguestDetails.Controls.Add(this.lblCardNumber);
            this.gbguestDetails.Controls.Add(this.txtPostalCode);
            this.gbguestDetails.Controls.Add(this.txtPhoneNumber);
            this.gbguestDetails.Controls.Add(this.txtEmail);
            this.gbguestDetails.Controls.Add(this.lblPostalCode);
            this.gbguestDetails.Controls.Add(this.lblAddress);
            this.gbguestDetails.Controls.Add(this.lblPhoneNumber);
            this.gbguestDetails.Controls.Add(this.lblEmail);
            this.gbguestDetails.Controls.Add(this.btnSearchGuest);
            this.gbguestDetails.Controls.Add(this.txtLastName);
            this.gbguestDetails.Controls.Add(this.lblLastName);
            this.gbguestDetails.Controls.Add(this.txtFirstName);
            this.gbguestDetails.Controls.Add(this.lblFirstName);
            this.gbguestDetails.Location = new System.Drawing.Point(12, 385);
            this.gbguestDetails.Name = "gbguestDetails";
            this.gbguestDetails.Size = new System.Drawing.Size(805, 341);
            this.gbguestDetails.TabIndex = 11;
            this.gbguestDetails.TabStop = false;
            this.gbguestDetails.Text = "Guest Details";
            // 
            // cbLoyaltyMember
            // 
            this.cbLoyaltyMember.AutoSize = true;
            this.cbLoyaltyMember.Location = new System.Drawing.Point(472, 253);
            this.cbLoyaltyMember.Name = "cbLoyaltyMember";
            this.cbLoyaltyMember.Size = new System.Drawing.Size(125, 20);
            this.cbLoyaltyMember.TabIndex = 16;
            this.cbLoyaltyMember.Text = "Loyalty Member";
            this.cbLoyaltyMember.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(213, 303);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(182, 32);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(169, 254);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(184, 22);
            this.txtCardNumber.TabIndex = 13;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(564, 137);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(205, 22);
            this.txtAddress.TabIndex = 12;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(26, 254);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(90, 16);
            this.lblCardNumber.TabIndex = 0;
            this.lblCardNumber.Text = "Card Number:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(564, 200);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(100, 22);
            this.txtPostalCode.TabIndex = 11;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(169, 200);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(100, 22);
            this.txtPhoneNumber.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(169, 134);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(184, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Location = new System.Drawing.Point(469, 206);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(84, 16);
            this.lblPostalCode.TabIndex = 8;
            this.lblPostalCode.Text = "Postal Code:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(469, 137);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 16);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = " Address:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(26, 200);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(100, 16);
            this.lblPhoneNumber.TabIndex = 6;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(26, 143);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // btnSearchGuest
            // 
            this.btnSearchGuest.Location = new System.Drawing.Point(213, 75);
            this.btnSearchGuest.Name = "btnSearchGuest";
            this.btnSearchGuest.Size = new System.Drawing.Size(182, 29);
            this.btnSearchGuest.TabIndex = 4;
            this.btnSearchGuest.Text = "Search Guest";
            this.btnSearchGuest.UseVisualStyleBackColor = true;
            this.btnSearchGuest.Click += new System.EventHandler(this.btnSearchGuest_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(564, 30);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 22);
            this.txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(469, 36);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(75, 16);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(169, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 22);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(23, 36);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(75, 16);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // gbReservationDetails
            // 
            this.gbReservationDetails.BackColor = System.Drawing.Color.Transparent;
            this.gbReservationDetails.Controls.Add(this.dgvRoomAvailability);
            this.gbReservationDetails.Controls.Add(this.btnCheckAvailability);
            this.gbReservationDetails.Controls.Add(this.lblCheckIn);
            this.gbReservationDetails.Controls.Add(this.txtGuestNumber);
            this.gbReservationDetails.Controls.Add(this.dateTimePickerCheckIn);
            this.gbReservationDetails.Controls.Add(this.lblGuestNumber);
            this.gbReservationDetails.Controls.Add(this.txtRoomNumbers);
            this.gbReservationDetails.Controls.Add(this.lblCheckOut);
            this.gbReservationDetails.Controls.Add(this.dateTimePickerCheckOut);
            this.gbReservationDetails.Controls.Add(this.lblRoomNumbers);
            this.gbReservationDetails.Location = new System.Drawing.Point(12, 12);
            this.gbReservationDetails.Name = "gbReservationDetails";
            this.gbReservationDetails.Size = new System.Drawing.Size(805, 367);
            this.gbReservationDetails.TabIndex = 10;
            this.gbReservationDetails.TabStop = false;
            this.gbReservationDetails.Text = "ReservationDetails";
            // 
            // dgvRoomAvailability
            // 
            this.dgvRoomAvailability.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomAvailability.Location = new System.Drawing.Point(39, 206);
            this.dgvRoomAvailability.Name = "dgvRoomAvailability";
            this.dgvRoomAvailability.RowHeadersWidth = 51;
            this.dgvRoomAvailability.RowTemplate.Height = 24;
            this.dgvRoomAvailability.Size = new System.Drawing.Size(544, 150);
            this.dgvRoomAvailability.TabIndex = 13;
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.Location = new System.Drawing.Point(213, 167);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(182, 33);
            this.btnCheckAvailability.TabIndex = 8;
            this.btnCheckAvailability.Text = "Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = true;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(24, 38);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(91, 16);
            this.lblCheckIn.TabIndex = 2;
            this.lblCheckIn.Text = "Check-in Date";
            // 
            // txtGuestNumber
            // 
            this.txtGuestNumber.Location = new System.Drawing.Point(484, 114);
            this.txtGuestNumber.Name = "txtGuestNumber";
            this.txtGuestNumber.Size = new System.Drawing.Size(100, 22);
            this.txtGuestNumber.TabIndex = 7;
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(27, 72);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(243, 22);
            this.dateTimePickerCheckIn.TabIndex = 0;
            // 
            // lblGuestNumber
            // 
            this.lblGuestNumber.AutoSize = true;
            this.lblGuestNumber.Location = new System.Drawing.Point(315, 117);
            this.lblGuestNumber.Name = "lblGuestNumber";
            this.lblGuestNumber.Size = new System.Drawing.Size(117, 16);
            this.lblGuestNumber.TabIndex = 5;
            this.lblGuestNumber.Text = "Number of Guests:";
            // 
            // txtRoomNumbers
            // 
            this.txtRoomNumbers.Location = new System.Drawing.Point(170, 117);
            this.txtRoomNumbers.Name = "txtRoomNumbers";
            this.txtRoomNumbers.Size = new System.Drawing.Size(100, 22);
            this.txtRoomNumbers.TabIndex = 6;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(315, 38);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(101, 16);
            this.lblCheckOut.TabIndex = 3;
            this.lblCheckOut.Text = "Check-Out Date";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(317, 72);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(243, 22);
            this.dateTimePickerCheckOut.TabIndex = 1;
            // 
            // lblRoomNumbers
            // 
            this.lblRoomNumbers.AutoSize = true;
            this.lblRoomNumbers.Location = new System.Drawing.Point(24, 120);
            this.lblRoomNumbers.Name = "lblRoomNumbers";
            this.lblRoomNumbers.Size = new System.Drawing.Size(119, 16);
            this.lblRoomNumbers.TabIndex = 4;
            this.lblRoomNumbers.Text = "Number of Rooms:";
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.Formbackground__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1313, 766);
            this.Controls.Add(this.gbguestDetails);
            this.Controls.Add(this.gbReservationDetails);
            this.DoubleBuffered = true;
            this.Name = "BookingForm";
            this.Text = "BookingForm";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            this.gbguestDetails.ResumeLayout(false);
            this.gbguestDetails.PerformLayout();
            this.gbReservationDetails.ResumeLayout(false);
            this.gbReservationDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomAvailability)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbguestDetails;
        private System.Windows.Forms.GroupBox gbReservationDetails;
        private System.Windows.Forms.Button btnCheckAvailability;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.TextBox txtGuestNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.Label lblGuestNumber;
        private System.Windows.Forms.TextBox txtRoomNumbers;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.Label lblRoomNumbers;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnSearchGuest;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvRoomAvailability;
        private System.Windows.Forms.CheckBox cbLoyaltyMember;
    }
}