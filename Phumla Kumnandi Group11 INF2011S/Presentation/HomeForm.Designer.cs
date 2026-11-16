namespace Phumla_Kumnandi_Group11_INF2011S.Presentation
{
    partial class HomeForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnBooking = new System.Windows.Forms.ToolStripSplitButton();
            this.makeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enquireBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBtnExit = new System.Windows.Forms.ToolStripButton();
            this.bookingConfirmationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnBooking,
            this.toolStripBtnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnBooking
            // 
            this.toolStripBtnBooking.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnBooking.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeToolStripMenuItem,
            this.changeBookingToolStripMenuItem,
            this.enquireBookingToolStripMenuItem,
            this.cancelBookingToolStripMenuItem,
            this.bookingConfirmationToolStripMenuItem});
            this.toolStripBtnBooking.Image = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.reporticon;
            this.toolStripBtnBooking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBooking.Name = "toolStripBtnBooking";
            this.toolStripBtnBooking.Size = new System.Drawing.Size(39, 24);
            this.toolStripBtnBooking.Text = "toolStripBtnBooking";
            this.toolStripBtnBooking.ToolTipText = "toolStripBtnBooking";
            // 
            // makeToolStripMenuItem
            // 
            this.makeToolStripMenuItem.Name = "makeToolStripMenuItem";
            this.makeToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.makeToolStripMenuItem.Text = "Make Booking";
            this.makeToolStripMenuItem.Click += new System.EventHandler(this.makeToolStripMenuItem_Click);
            // 
            // changeBookingToolStripMenuItem
            // 
            this.changeBookingToolStripMenuItem.Name = "changeBookingToolStripMenuItem";
            this.changeBookingToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.changeBookingToolStripMenuItem.Text = "Change Booking";
            this.changeBookingToolStripMenuItem.Click += new System.EventHandler(this.changeBookingToolStripMenuItem_Click);
            // 
            // enquireBookingToolStripMenuItem
            // 
            this.enquireBookingToolStripMenuItem.Name = "enquireBookingToolStripMenuItem";
            this.enquireBookingToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.enquireBookingToolStripMenuItem.Text = "Enquire Booking";
            this.enquireBookingToolStripMenuItem.Click += new System.EventHandler(this.enquireBookingToolStripMenuItem_Click);
            // 
            // cancelBookingToolStripMenuItem
            // 
            this.cancelBookingToolStripMenuItem.Name = "cancelBookingToolStripMenuItem";
            this.cancelBookingToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.cancelBookingToolStripMenuItem.Text = "Cancel Booking";
            this.cancelBookingToolStripMenuItem.Click += new System.EventHandler(this.cancelBookingToolStripMenuItem_Click);
            // 
            // toolStripBtnExit
            // 
            this.toolStripBtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnExit.Image = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.cancelicon;
            this.toolStripBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnExit.Name = "toolStripBtnExit";
            this.toolStripBtnExit.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnExit.Text = "toolStripBtnExit";
            this.toolStripBtnExit.Click += new System.EventHandler(this.toolStripBtnExit_Click);
            // 
            // bookingConfirmationToolStripMenuItem
            // 
            this.bookingConfirmationToolStripMenuItem.Name = "bookingConfirmationToolStripMenuItem";
            this.bookingConfirmationToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.bookingConfirmationToolStripMenuItem.Text = "Booking Confirmation";
            this.bookingConfirmationToolStripMenuItem.Click += new System.EventHandler(this.bookingConfirmationToolStripMenuItem_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.Phumla_Kamandi__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripBtnBooking;
        private System.Windows.Forms.ToolStripButton toolStripBtnExit;
        private System.Windows.Forms.ToolStripMenuItem makeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enquireBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingConfirmationToolStripMenuItem;
    }
}