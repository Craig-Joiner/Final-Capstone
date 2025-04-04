namespace Craig_Joiner_Software_2
{
    partial class Main
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
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.Current_week = new System.Windows.Forms.RadioButton();
            this.Current_month = new System.Windows.Forms.RadioButton();
            this.All_appointments = new System.Windows.Forms.RadioButton();
            this.Appointments = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteA = new System.Windows.Forms.Button();
            this.AddA = new System.Windows.Forms.Button();
            this.UpdateA = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.AddC = new System.Windows.Forms.Button();
            this.UpdateC = new System.Windows.Forms.Button();
            this.DeleteC = new System.Windows.Forms.Button();
            this.ExitM = new System.Windows.Forms.Button();
            this.Reports = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SearchCustomerbyID = new System.Windows.Forms.Button();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(12, 88);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.RowTemplate.Height = 24;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(881, 188);
            this.dgvAppointments.TabIndex = 0;
            // 
            // Current_week
            // 
            this.Current_week.AutoSize = true;
            this.Current_week.Location = new System.Drawing.Point(508, 60);
            this.Current_week.Name = "Current_week";
            this.Current_week.Size = new System.Drawing.Size(109, 20);
            this.Current_week.TabIndex = 1;
            this.Current_week.TabStop = true;
            this.Current_week.Text = "Current Week";
            this.Current_week.UseVisualStyleBackColor = true;
            this.Current_week.CheckedChanged += new System.EventHandler(this.Current_week_CheckedChanged);
            // 
            // Current_month
            // 
            this.Current_month.AutoSize = true;
            this.Current_month.Location = new System.Drawing.Point(640, 60);
            this.Current_month.Name = "Current_month";
            this.Current_month.Size = new System.Drawing.Size(109, 20);
            this.Current_month.TabIndex = 2;
            this.Current_month.TabStop = true;
            this.Current_month.Text = "Current Month";
            this.Current_month.UseVisualStyleBackColor = true;
            this.Current_month.CheckedChanged += new System.EventHandler(this.Current_month_CheckedChanged);
            // 
            // All_appointments
            // 
            this.All_appointments.AutoSize = true;
            this.All_appointments.Location = new System.Drawing.Point(765, 60);
            this.All_appointments.Name = "All_appointments";
            this.All_appointments.Size = new System.Drawing.Size(128, 20);
            this.All_appointments.TabIndex = 3;
            this.All_appointments.TabStop = true;
            this.All_appointments.Text = "All Appointments";
            this.All_appointments.UseVisualStyleBackColor = true;
            this.All_appointments.CheckedChanged += new System.EventHandler(this.All_appointments_CheckedChanged);
            // 
            // Appointments
            // 
            this.Appointments.AutoSize = true;
            this.Appointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Appointments.Location = new System.Drawing.Point(21, 53);
            this.Appointments.Name = "Appointments";
            this.Appointments.Size = new System.Drawing.Size(160, 29);
            this.Appointments.TabIndex = 4;
            this.Appointments.Text = "Appointments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(21, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Customers";
            // 
            // DeleteA
            // 
            this.DeleteA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteA.Location = new System.Drawing.Point(220, 282);
            this.DeleteA.Name = "DeleteA";
            this.DeleteA.Size = new System.Drawing.Size(98, 33);
            this.DeleteA.TabIndex = 6;
            this.DeleteA.Text = "Delete";
            this.DeleteA.UseVisualStyleBackColor = true;
            this.DeleteA.Click += new System.EventHandler(this.DeleteA_Click);
            // 
            // AddA
            // 
            this.AddA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddA.Location = new System.Drawing.Point(12, 282);
            this.AddA.Name = "AddA";
            this.AddA.Size = new System.Drawing.Size(98, 33);
            this.AddA.TabIndex = 7;
            this.AddA.Text = "Add";
            this.AddA.UseVisualStyleBackColor = true;
            this.AddA.Click += new System.EventHandler(this.AddA_Click);
            // 
            // UpdateA
            // 
            this.UpdateA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateA.Location = new System.Drawing.Point(116, 282);
            this.UpdateA.Name = "UpdateA";
            this.UpdateA.Size = new System.Drawing.Size(98, 33);
            this.UpdateA.TabIndex = 8;
            this.UpdateA.Text = "Update";
            this.UpdateA.UseVisualStyleBackColor = true;
            this.UpdateA.Click += new System.EventHandler(this.UpdateA_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 368);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(764, 196);
            this.dgvCustomers.TabIndex = 9;
            // 
            // AddC
            // 
            this.AddC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddC.Location = new System.Drawing.Point(12, 570);
            this.AddC.Name = "AddC";
            this.AddC.Size = new System.Drawing.Size(98, 33);
            this.AddC.TabIndex = 10;
            this.AddC.Text = "Add";
            this.AddC.UseVisualStyleBackColor = true;
            this.AddC.Click += new System.EventHandler(this.AddC_Click);
            // 
            // UpdateC
            // 
            this.UpdateC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateC.Location = new System.Drawing.Point(116, 570);
            this.UpdateC.Name = "UpdateC";
            this.UpdateC.Size = new System.Drawing.Size(98, 33);
            this.UpdateC.TabIndex = 11;
            this.UpdateC.Text = "Update";
            this.UpdateC.UseVisualStyleBackColor = true;
            this.UpdateC.Click += new System.EventHandler(this.UpdateC_Click);
            // 
            // DeleteC
            // 
            this.DeleteC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteC.Location = new System.Drawing.Point(220, 570);
            this.DeleteC.Name = "DeleteC";
            this.DeleteC.Size = new System.Drawing.Size(98, 33);
            this.DeleteC.TabIndex = 12;
            this.DeleteC.Text = "Delete";
            this.DeleteC.UseVisualStyleBackColor = true;
            this.DeleteC.Click += new System.EventHandler(this.DeleteC_Click);
            // 
            // ExitM
            // 
            this.ExitM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ExitM.Location = new System.Drawing.Point(782, 454);
            this.ExitM.Name = "ExitM";
            this.ExitM.Size = new System.Drawing.Size(111, 44);
            this.ExitM.TabIndex = 13;
            this.ExitM.Text = "Exit";
            this.ExitM.UseVisualStyleBackColor = true;
            this.ExitM.Click += new System.EventHandler(this.ExitM_Click);
            // 
            // Reports
            // 
            this.Reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Reports.Location = new System.Drawing.Point(782, 395);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(111, 44);
            this.Reports.TabIndex = 14;
            this.Reports.Text = "Reports";
            this.Reports.UseVisualStyleBackColor = true;
            this.Reports.Click += new System.EventHandler(this.Reports_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(220, 60);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(267, 22);
            this.dateTimePicker1.TabIndex = 15;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // SearchCustomerbyID
            // 
            this.SearchCustomerbyID.Location = new System.Drawing.Point(508, 339);
            this.SearchCustomerbyID.Name = "SearchCustomerbyID";
            this.SearchCustomerbyID.Size = new System.Drawing.Size(75, 23);
            this.SearchCustomerbyID.TabIndex = 16;
            this.SearchCustomerbyID.Text = "Search";
            this.SearchCustomerbyID.UseVisualStyleBackColor = true;
            this.SearchCustomerbyID.Click += new System.EventHandler(this.SearchCustomerbyID_Click);
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Location = new System.Drawing.Point(589, 339);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(187, 22);
            this.textBoxCustomer.TabIndex = 17;
            this.textBoxCustomer.TextChanged += new System.EventHandler(this.textBoxCustomer_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 615);
            this.Controls.Add(this.textBoxCustomer);
            this.Controls.Add(this.SearchCustomerbyID);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Current_week);
            this.Controls.Add(this.Reports);
            this.Controls.Add(this.Current_month);
            this.Controls.Add(this.ExitM);
            this.Controls.Add(this.All_appointments);
            this.Controls.Add(this.DeleteC);
            this.Controls.Add(this.UpdateC);
            this.Controls.Add(this.AddC);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.UpdateA);
            this.Controls.Add(this.AddA);
            this.Controls.Add(this.DeleteA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Appointments);
            this.Controls.Add(this.dgvAppointments);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.RadioButton Current_week;
        private System.Windows.Forms.RadioButton Current_month;
        private System.Windows.Forms.RadioButton All_appointments;
        private System.Windows.Forms.Label Appointments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteA;
        private System.Windows.Forms.Button AddA;
        private System.Windows.Forms.Button UpdateA;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button AddC;
        private System.Windows.Forms.Button UpdateC;
        private System.Windows.Forms.Button DeleteC;
        private System.Windows.Forms.Button ExitM;
        private System.Windows.Forms.Button Reports;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button SearchCustomerbyID;
        private System.Windows.Forms.TextBox textBoxCustomer;
    }
}