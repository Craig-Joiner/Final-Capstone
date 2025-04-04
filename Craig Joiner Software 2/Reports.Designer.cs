namespace Craig_Joiner_Software_2
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
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.dgvAppointmentInfo = new System.Windows.Forms.DataGridView();
            this.dgvLocation = new System.Windows.Forms.DataGridView();
            this.Report = new System.Windows.Forms.Label();
            this.Select_Contact = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.CustomerContact = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 76);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(969, 222);
            this.dgvReport.TabIndex = 1;
            // 
            // dgvAppointmentInfo
            // 
            this.dgvAppointmentInfo.AllowUserToAddRows = false;
            this.dgvAppointmentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentInfo.Location = new System.Drawing.Point(12, 373);
            this.dgvAppointmentInfo.MultiSelect = false;
            this.dgvAppointmentInfo.Name = "dgvAppointmentInfo";
            this.dgvAppointmentInfo.ReadOnly = true;
            this.dgvAppointmentInfo.RowHeadersWidth = 51;
            this.dgvAppointmentInfo.RowTemplate.Height = 24;
            this.dgvAppointmentInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointmentInfo.Size = new System.Drawing.Size(468, 203);
            this.dgvAppointmentInfo.TabIndex = 2;
            // 
            // dgvLocation
            // 
            this.dgvLocation.AllowUserToAddRows = false;
            this.dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocation.Location = new System.Drawing.Point(513, 373);
            this.dgvLocation.MultiSelect = false;
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.ReadOnly = true;
            this.dgvLocation.RowHeadersWidth = 51;
            this.dgvLocation.RowTemplate.Height = 24;
            this.dgvLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocation.Size = new System.Drawing.Size(468, 203);
            this.dgvLocation.TabIndex = 3;
            // 
            // Report
            // 
            this.Report.AutoSize = true;
            this.Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Report.Location = new System.Drawing.Point(12, 29);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(98, 29);
            this.Report.TabIndex = 4;
            this.Report.Text = "Reports";
            // 
            // Select_Contact
            // 
            this.Select_Contact.AutoSize = true;
            this.Select_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_Contact.Location = new System.Drawing.Point(606, 32);
            this.Select_Contact.Name = "Select_Contact";
            this.Select_Contact.Size = new System.Drawing.Size(156, 25);
            this.Select_Contact.TabIndex = 5;
            this.Select_Contact.Text = "Select a Contact";
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.Location = new System.Drawing.Point(779, 597);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(98, 33);
            this.Back.TabIndex = 8;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(883, 597);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(98, 33);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // CustomerContact
            // 
            this.CustomerContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerContact.FormattingEnabled = true;
            this.CustomerContact.Location = new System.Drawing.Point(768, 25);
            this.CustomerContact.Name = "CustomerContact";
            this.CustomerContact.Size = new System.Drawing.Size(213, 33);
            this.CustomerContact.TabIndex = 31;
            this.CustomerContact.SelectedIndexChanged += new System.EventHandler(this.CustomerContact_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(579, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 29);
            this.label1.TabIndex = 32;
            this.label1.Text = "Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 29);
            this.label2.TabIndex = 33;
            this.label2.Text = "Appointment Type";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 642);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerContact);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Select_Contact);
            this.Controls.Add(this.Report);
            this.Controls.Add(this.dgvLocation);
            this.Controls.Add(this.dgvAppointmentInfo);
            this.Controls.Add(this.dgvReport);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DataGridView dgvAppointmentInfo;
        private System.Windows.Forms.DataGridView dgvLocation;
        private System.Windows.Forms.Label Report;
        private System.Windows.Forms.Label Select_Contact;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox CustomerContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}