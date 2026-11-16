namespace Phumla_Kumnandi_Group11_INF2011S
{
    partial class StartForm
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
            this.btnReceptionist = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReceptionist
            // 
            this.btnReceptionist.Image = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.recepicon;
            this.btnReceptionist.Location = new System.Drawing.Point(293, 84);
            this.btnReceptionist.Name = "btnReceptionist";
            this.btnReceptionist.Size = new System.Drawing.Size(190, 122);
            this.btnReceptionist.TabIndex = 0;
            this.btnReceptionist.Text = "Receptionist";
            this.btnReceptionist.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReceptionist.UseVisualStyleBackColor = true;
            this.btnReceptionist.Click += new System.EventHandler(this.btnReceptionist_Click);
            // 
            // btnManager
            // 
            this.btnManager.Image = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.Screenshot_2025_10_04_221144;
            this.btnManager.Location = new System.Drawing.Point(293, 236);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(190, 126);
            this.btnManager.TabIndex = 1;
            this.btnManager.Text = "Manager";
            this.btnManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Phumla_Kumnandi_Group11_INF2011S.Properties.Resources.Formbackground__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnReceptionist);
            this.DoubleBuffered = true;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReceptionist;
        private System.Windows.Forms.Button btnManager;
    }
}

