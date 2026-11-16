namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    partial class BookingConfirmationForm
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
            this.btnSearchBookingConfirmation = new System.Windows.Forms.Button();
            this.txtBookingConfirmation = new System.Windows.Forms.TextBox();
            this.lblBookingConfirmation = new System.Windows.Forms.Label();
            this.rtbConfirmation = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearchBookingConfirmation
            // 
            this.btnSearchBookingConfirmation.Location = new System.Drawing.Point(593, 21);
            this.btnSearchBookingConfirmation.Name = "btnSearchBookingConfirmation";
            this.btnSearchBookingConfirmation.Size = new System.Drawing.Size(146, 31);
            this.btnSearchBookingConfirmation.TabIndex = 20;
            this.btnSearchBookingConfirmation.Text = "Search";
            this.btnSearchBookingConfirmation.UseVisualStyleBackColor = true;
            this.btnSearchBookingConfirmation.Click += new System.EventHandler(this.btnSearchBookingConfirmation_Click);
            // 
            // txtBookingConfirmation
            // 
            this.txtBookingConfirmation.Location = new System.Drawing.Point(300, 25);
            this.txtBookingConfirmation.Name = "txtBookingConfirmation";
            this.txtBookingConfirmation.Size = new System.Drawing.Size(100, 22);
            this.txtBookingConfirmation.TabIndex = 19;
            // 
            // lblBookingConfirmation
            // 
            this.lblBookingConfirmation.AutoSize = true;
            this.lblBookingConfirmation.Location = new System.Drawing.Point(29, 28);
            this.lblBookingConfirmation.Name = "lblBookingConfirmation";
            this.lblBookingConfirmation.Size = new System.Drawing.Size(76, 16);
            this.lblBookingConfirmation.TabIndex = 18;
            this.lblBookingConfirmation.Text = "Booking ID:";
            // 
            // rtbConfirmation
            // 
            this.rtbConfirmation.Location = new System.Drawing.Point(32, 77);
            this.rtbConfirmation.Name = "rtbConfirmation";
            this.rtbConfirmation.Size = new System.Drawing.Size(707, 319);
            this.rtbConfirmation.TabIndex = 21;
            this.rtbConfirmation.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(300, 402);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 36);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BookingConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.Formbackground__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtbConfirmation);
            this.Controls.Add(this.btnSearchBookingConfirmation);
            this.Controls.Add(this.txtBookingConfirmation);
            this.Controls.Add(this.lblBookingConfirmation);
            this.DoubleBuffered = true;
            this.Name = "BookingConfirmationForm";
            this.Text = "BookingConfirmationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchBookingConfirmation;
        private System.Windows.Forms.TextBox txtBookingConfirmation;
        private System.Windows.Forms.Label lblBookingConfirmation;
        private System.Windows.Forms.RichTextBox rtbConfirmation;
        private System.Windows.Forms.Button btnClear;
    }
}