
namespace SchedulingApp
{
    partial class Reports
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
            this.reportsTextBox = new System.Windows.Forms.TextBox();
            this.typesButton = new System.Windows.Forms.Button();
            this.consultantScheduleButton = new System.Windows.Forms.Button();
            this.clientLocationsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportsTextBox
            // 
            this.reportsTextBox.Location = new System.Drawing.Point(38, 125);
            this.reportsTextBox.Multiline = true;
            this.reportsTextBox.Name = "reportsTextBox";
            this.reportsTextBox.ReadOnly = true;
            this.reportsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportsTextBox.Size = new System.Drawing.Size(749, 318);
            this.reportsTextBox.TabIndex = 0;
            // 
            // typesButton
            // 
            this.typesButton.Location = new System.Drawing.Point(71, 65);
            this.typesButton.Name = "typesButton";
            this.typesButton.Size = new System.Drawing.Size(138, 37);
            this.typesButton.TabIndex = 1;
            this.typesButton.Text = "Appointment Types";
            this.typesButton.UseVisualStyleBackColor = true;
            this.typesButton.Click += new System.EventHandler(this.typesButton_Click);
            // 
            // consultantScheduleButton
            // 
            this.consultantScheduleButton.Location = new System.Drawing.Point(327, 65);
            this.consultantScheduleButton.Name = "consultantScheduleButton";
            this.consultantScheduleButton.Size = new System.Drawing.Size(138, 37);
            this.consultantScheduleButton.TabIndex = 2;
            this.consultantScheduleButton.Text = "Consultant Schedules";
            this.consultantScheduleButton.UseVisualStyleBackColor = true;
            this.consultantScheduleButton.Click += new System.EventHandler(this.consultantScheduleButton_Click);
            // 
            // clientLocationsButton
            // 
            this.clientLocationsButton.Location = new System.Drawing.Point(565, 65);
            this.clientLocationsButton.Name = "clientLocationsButton";
            this.clientLocationsButton.Size = new System.Drawing.Size(138, 37);
            this.clientLocationsButton.TabIndex = 3;
            this.clientLocationsButton.Text = "Client Locations";
            this.clientLocationsButton.UseVisualStyleBackColor = true;
            this.clientLocationsButton.Click += new System.EventHandler(this.clientLocationsButton_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 472);
            this.Controls.Add(this.clientLocationsButton);
            this.Controls.Add(this.consultantScheduleButton);
            this.Controls.Add(this.typesButton);
            this.Controls.Add(this.reportsTextBox);
            this.Name = "Reports";
            this.Text = "Reports";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reports_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reportsTextBox;
        private System.Windows.Forms.Button typesButton;
        private System.Windows.Forms.Button consultantScheduleButton;
        private System.Windows.Forms.Button clientLocationsButton;
    }
}