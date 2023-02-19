
namespace SchedulingApp
{
    partial class CalendarSchedule
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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.appointmentsLabel = new System.Windows.Forms.Label();
            this.dailyRadioButton = new System.Windows.Forms.RadioButton();
            this.weeklyRadioButton = new System.Windows.Forms.RadioButton();
            this.viewCustomersButton = new System.Windows.Forms.Button();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.editAppointmentButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.viewReportsButton = new System.Windows.Forms.Button();
            this.monthlyRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.monthCalendar.Location = new System.Drawing.Point(34, 18);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Location = new System.Drawing.Point(298, 39);
            this.appointmentDataGridView.MultiSelect = false;
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.ReadOnly = true;
            this.appointmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGridView.Size = new System.Drawing.Size(490, 325);
            this.appointmentDataGridView.TabIndex = 1;
            this.appointmentDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.appointmentDataGridView_CellClick);
            // 
            // appointmentsLabel
            // 
            this.appointmentsLabel.AutoSize = true;
            this.appointmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsLabel.Location = new System.Drawing.Point(311, 9);
            this.appointmentsLabel.Name = "appointmentsLabel";
            this.appointmentsLabel.Size = new System.Drawing.Size(120, 20);
            this.appointmentsLabel.TabIndex = 2;
            this.appointmentsLabel.Text = "Appointments";
            // 
            // dailyRadioButton
            // 
            this.dailyRadioButton.AutoSize = true;
            this.dailyRadioButton.Location = new System.Drawing.Point(34, 192);
            this.dailyRadioButton.Name = "dailyRadioButton";
            this.dailyRadioButton.Size = new System.Drawing.Size(48, 17);
            this.dailyRadioButton.TabIndex = 3;
            this.dailyRadioButton.Text = "Daily";
            this.dailyRadioButton.UseVisualStyleBackColor = true;
            this.dailyRadioButton.Click += new System.EventHandler(this.dailyRadioButton_Click);
            // 
            // weeklyRadioButton
            // 
            this.weeklyRadioButton.AutoSize = true;
            this.weeklyRadioButton.Location = new System.Drawing.Point(113, 192);
            this.weeklyRadioButton.Name = "weeklyRadioButton";
            this.weeklyRadioButton.Size = new System.Drawing.Size(61, 17);
            this.weeklyRadioButton.TabIndex = 4;
            this.weeklyRadioButton.Text = "Weekly";
            this.weeklyRadioButton.UseVisualStyleBackColor = true;
            this.weeklyRadioButton.Click += new System.EventHandler(this.weeklyRadioButton_Click);
            // 
            // viewCustomersButton
            // 
            this.viewCustomersButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.viewCustomersButton.Location = new System.Drawing.Point(339, 394);
            this.viewCustomersButton.Name = "viewCustomersButton";
            this.viewCustomersButton.Size = new System.Drawing.Size(174, 32);
            this.viewCustomersButton.TabIndex = 6;
            this.viewCustomersButton.Text = "View Customers";
            this.viewCustomersButton.UseVisualStyleBackColor = false;
            this.viewCustomersButton.Click += new System.EventHandler(this.viewCustomersButton_Click);
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Location = new System.Drawing.Point(57, 234);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(174, 32);
            this.addAppointmentButton.TabIndex = 7;
            this.addAppointmentButton.Text = "Add Appointment";
            this.addAppointmentButton.UseVisualStyleBackColor = true;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // editAppointmentButton
            // 
            this.editAppointmentButton.Location = new System.Drawing.Point(57, 283);
            this.editAppointmentButton.Name = "editAppointmentButton";
            this.editAppointmentButton.Size = new System.Drawing.Size(174, 32);
            this.editAppointmentButton.TabIndex = 8;
            this.editAppointmentButton.Text = "Edit Appointment";
            this.editAppointmentButton.UseVisualStyleBackColor = true;
            this.editAppointmentButton.Click += new System.EventHandler(this.editAppointmentButton_Click);
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.deleteAppointmentButton.Location = new System.Drawing.Point(57, 332);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(174, 32);
            this.deleteAppointmentButton.TabIndex = 9;
            this.deleteAppointmentButton.Text = "Delete Appointment";
            this.deleteAppointmentButton.UseVisualStyleBackColor = false;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // viewReportsButton
            // 
            this.viewReportsButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.viewReportsButton.Location = new System.Drawing.Point(556, 394);
            this.viewReportsButton.Name = "viewReportsButton";
            this.viewReportsButton.Size = new System.Drawing.Size(174, 32);
            this.viewReportsButton.TabIndex = 10;
            this.viewReportsButton.Text = "View Reports";
            this.viewReportsButton.UseVisualStyleBackColor = false;
            this.viewReportsButton.Click += new System.EventHandler(this.viewReportsButton_Click);
            // 
            // monthlyRadioButton
            // 
            this.monthlyRadioButton.AutoSize = true;
            this.monthlyRadioButton.Location = new System.Drawing.Point(200, 192);
            this.monthlyRadioButton.Name = "monthlyRadioButton";
            this.monthlyRadioButton.Size = new System.Drawing.Size(62, 17);
            this.monthlyRadioButton.TabIndex = 11;
            this.monthlyRadioButton.Text = "Monthly";
            this.monthlyRadioButton.UseVisualStyleBackColor = true;
            this.monthlyRadioButton.Click += new System.EventHandler(this.monthlyRadioButton_Click);
            // 
            // CalendarSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monthlyRadioButton);
            this.Controls.Add(this.viewReportsButton);
            this.Controls.Add(this.deleteAppointmentButton);
            this.Controls.Add(this.editAppointmentButton);
            this.Controls.Add(this.addAppointmentButton);
            this.Controls.Add(this.viewCustomersButton);
            this.Controls.Add(this.weeklyRadioButton);
            this.Controls.Add(this.dailyRadioButton);
            this.Controls.Add(this.appointmentsLabel);
            this.Controls.Add(this.appointmentDataGridView);
            this.Controls.Add(this.monthCalendar);
            this.Name = "CalendarSchedule";
            this.Text = "CalendarSchedule";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalendarSchedule_FormClosed);
            this.Load += new System.EventHandler(this.CalendarSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.Label appointmentsLabel;
        private System.Windows.Forms.RadioButton dailyRadioButton;
        private System.Windows.Forms.RadioButton weeklyRadioButton;
        private System.Windows.Forms.Button viewCustomersButton;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.Button editAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button viewReportsButton;
        private System.Windows.Forms.RadioButton monthlyRadioButton;
    }
}