namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    partial class BookingEnquiryForm
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
            this.btnSearchBookingEnquiry = new System.Windows.Forms.Button();
            this.txtBookingIDEnquiry = new System.Windows.Forms.TextBox();
            this.lblBookingIDEnquiry = new System.Windows.Forms.Label();
            this.dataGridViewBookingEnquiry = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookingEnquiry)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchBookingEnquiry
            // 
            this.btnSearchBookingEnquiry.Location = new System.Drawing.Point(603, 28);
            this.btnSearchBookingEnquiry.Name = "btnSearchBookingEnquiry";
            this.btnSearchBookingEnquiry.Size = new System.Drawing.Size(146, 31);
            this.btnSearchBookingEnquiry.TabIndex = 9;
            this.btnSearchBookingEnquiry.Text = "Search";
            this.btnSearchBookingEnquiry.UseVisualStyleBackColor = true;
            this.btnSearchBookingEnquiry.Click += new System.EventHandler(this.btnSearchBookingEnquiry_Click);
            // 
            // txtBookingIDEnquiry
            // 
            this.txtBookingIDEnquiry.Location = new System.Drawing.Point(339, 32);
            this.txtBookingIDEnquiry.Name = "txtBookingIDEnquiry";
            this.txtBookingIDEnquiry.Size = new System.Drawing.Size(100, 22);
            this.txtBookingIDEnquiry.TabIndex = 8;
            // 
            // lblBookingIDEnquiry
            // 
            this.lblBookingIDEnquiry.AutoSize = true;
            this.lblBookingIDEnquiry.Location = new System.Drawing.Point(50, 35);
            this.lblBookingIDEnquiry.Name = "lblBookingIDEnquiry";
            this.lblBookingIDEnquiry.Size = new System.Drawing.Size(76, 16);
            this.lblBookingIDEnquiry.TabIndex = 7;
            this.lblBookingIDEnquiry.Text = "Booking ID:";
            // 
            // dataGridViewBookingEnquiry
            // 
            this.dataGridViewBookingEnquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBookingEnquiry.Location = new System.Drawing.Point(31, 110);
            this.dataGridViewBookingEnquiry.Name = "dataGridViewBookingEnquiry";
            this.dataGridViewBookingEnquiry.RowHeadersWidth = 51;
            this.dataGridViewBookingEnquiry.RowTemplate.Height = 24;
            this.dataGridViewBookingEnquiry.Size = new System.Drawing.Size(718, 287);
            this.dataGridViewBookingEnquiry.TabIndex = 10;
            // 
            // BookingEnquiryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.Formbackground__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewBookingEnquiry);
            this.Controls.Add(this.btnSearchBookingEnquiry);
            this.Controls.Add(this.txtBookingIDEnquiry);
            this.Controls.Add(this.lblBookingIDEnquiry);
            this.DoubleBuffered = true;
            this.Name = "BookingEnquiryForm";
            this.Text = "BookingEnquiryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookingEnquiry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchBookingEnquiry;
        private System.Windows.Forms.TextBox txtBookingIDEnquiry;
        private System.Windows.Forms.Label lblBookingIDEnquiry;
        private System.Windows.Forms.DataGridView dataGridViewBookingEnquiry;
    }
}