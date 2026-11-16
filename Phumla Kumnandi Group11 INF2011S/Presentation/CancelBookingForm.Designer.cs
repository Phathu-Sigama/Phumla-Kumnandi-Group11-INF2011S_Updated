namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    partial class CancelBookingForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearchBookingCancel = new System.Windows.Forms.Button();
            this.txtBookingIDCancel = new System.Windows.Forms.TextBox();
            this.lblBookingIDCancel = new System.Windows.Forms.Label();
            this.dgvCancelBooking = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(242, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearchBookingCancel
            // 
            this.btnSearchBookingCancel.Location = new System.Drawing.Point(456, 25);
            this.btnSearchBookingCancel.Name = "btnSearchBookingCancel";
            this.btnSearchBookingCancel.Size = new System.Drawing.Size(146, 31);
            this.btnSearchBookingCancel.TabIndex = 6;
            this.btnSearchBookingCancel.Text = "Search";
            this.btnSearchBookingCancel.UseVisualStyleBackColor = true;
            this.btnSearchBookingCancel.Click += new System.EventHandler(this.btnSearchBookingCancel_Click);
            // 
            // txtBookingIDCancel
            // 
            this.txtBookingIDCancel.Location = new System.Drawing.Point(261, 26);
            this.txtBookingIDCancel.Name = "txtBookingIDCancel";
            this.txtBookingIDCancel.Size = new System.Drawing.Size(100, 22);
            this.txtBookingIDCancel.TabIndex = 5;
            // 
            // lblBookingIDCancel
            // 
            this.lblBookingIDCancel.AutoSize = true;
            this.lblBookingIDCancel.Location = new System.Drawing.Point(43, 32);
            this.lblBookingIDCancel.Name = "lblBookingIDCancel";
            this.lblBookingIDCancel.Size = new System.Drawing.Size(76, 16);
            this.lblBookingIDCancel.TabIndex = 4;
            this.lblBookingIDCancel.Text = "Booking ID:";
            // 
            // dgvCancelBooking
            // 
            this.dgvCancelBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCancelBooking.Location = new System.Drawing.Point(46, 79);
            this.dgvCancelBooking.Name = "dgvCancelBooking";
            this.dgvCancelBooking.RowHeadersWidth = 51;
            this.dgvCancelBooking.RowTemplate.Height = 24;
            this.dgvCancelBooking.Size = new System.Drawing.Size(572, 292);
            this.dgvCancelBooking.TabIndex = 8;
            // 
            // CancelBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.Formbackground__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCancelBooking);
            this.Controls.Add(this.btnSearchBookingCancel);
            this.Controls.Add(this.txtBookingIDCancel);
            this.Controls.Add(this.lblBookingIDCancel);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.Name = "CancelBookingForm";
            this.Text = "CancelBookingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCancelBooking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearchBookingCancel;
        private System.Windows.Forms.TextBox txtBookingIDCancel;
        private System.Windows.Forms.Label lblBookingIDCancel;
        private System.Windows.Forms.DataGridView dgvCancelBooking;
    }
}