using System.Windows.Forms;

namespace Craig_Joiner_Software_2
{
    partial class UpdateCustomerRecords
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
            this.UpdateC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Name2 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.Phone_Number = new System.Windows.Forms.Label();
            this.Country = new System.Windows.Forms.Label();
            this.State_Province = new System.Windows.Forms.Label();
            this.Zip_Code = new System.Windows.Forms.Label();
            this.textBoxCustomerID = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxZipCode = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // UpdateC
            // 
            this.UpdateC.AutoSize = true;
            this.UpdateC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateC.Location = new System.Drawing.Point(12, 43);
            this.UpdateC.Name = "UpdateC";
            this.UpdateC.Size = new System.Drawing.Size(165, 25);
            this.UpdateC.TabIndex = 3;
            this.UpdateC.Text = "Update Customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // Name2
            // 
            this.Name2.AutoSize = true;
            this.Name2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name2.Location = new System.Drawing.Point(63, 157);
            this.Name2.Name = "Name2";
            this.Name2.Size = new System.Drawing.Size(53, 20);
            this.Name2.TabIndex = 5;
            this.Name2.Text = "Name";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.Location = new System.Drawing.Point(63, 199);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(71, 20);
            this.Address.TabIndex = 6;
            this.Address.Text = "Address";
            // 
            // Phone_Number
            // 
            this.Phone_Number.AutoSize = true;
            this.Phone_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phone_Number.Location = new System.Drawing.Point(63, 239);
            this.Phone_Number.Name = "Phone_Number";
            this.Phone_Number.Size = new System.Drawing.Size(120, 20);
            this.Phone_Number.TabIndex = 7;
            this.Phone_Number.Text = "Phone Number";
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Country.Location = new System.Drawing.Point(63, 276);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(67, 20);
            this.Country.TabIndex = 8;
            this.Country.Text = "Country";
            // 
            // State_Province
            // 
            this.State_Province.AutoSize = true;
            this.State_Province.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.State_Province.Location = new System.Drawing.Point(63, 318);
            this.State_Province.Name = "State_Province";
            this.State_Province.Size = new System.Drawing.Size(38, 20);
            this.State_Province.TabIndex = 9;
            this.State_Province.Text = "City";
            // 
            // Zip_Code
            // 
            this.Zip_Code.AutoSize = true;
            this.Zip_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zip_Code.Location = new System.Drawing.Point(63, 363);
            this.Zip_Code.Name = "Zip_Code";
            this.Zip_Code.Size = new System.Drawing.Size(75, 20);
            this.Zip_Code.TabIndex = 10;
            this.Zip_Code.Text = "Zip Code";
            // 
            // textBoxCustomerID
            // 
            this.textBoxCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomerID.Location = new System.Drawing.Point(218, 105);
            this.textBoxCustomerID.Name = "textBoxCustomerID";
            this.textBoxCustomerID.ReadOnly = true;
            this.textBoxCustomerID.Size = new System.Drawing.Size(230, 30);
            this.textBoxCustomerID.TabIndex = 16;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(218, 150);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(230, 30);
            this.textBoxName.TabIndex = 17;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(218, 192);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(230, 30);
            this.textBoxAddress.TabIndex = 18;
            // 
            // textBoxZipCode
            // 
            this.textBoxZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZipCode.Location = new System.Drawing.Point(218, 363);
            this.textBoxZipCode.Name = "textBoxZipCode";
            this.textBoxZipCode.Size = new System.Drawing.Size(230, 30);
            this.textBoxZipCode.TabIndex = 20;
            // 
            // Update
            // 
            this.Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update.Location = new System.Drawing.Point(218, 415);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(98, 33);
            this.Update.TabIndex = 33;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.Location = new System.Drawing.Point(322, 415);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(98, 33);
            this.Cancel.TabIndex = 34;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCountry.Location = new System.Drawing.Point(218, 276);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(230, 30);
            this.textBoxCountry.TabIndex = 35;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCity.Location = new System.Drawing.Point(218, 318);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(230, 30);
            this.textBoxCity.TabIndex = 36;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(218, 232);
            this.textBoxPhoneNumber.Mask = "000-0000";
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(228, 30);
            this.textBoxPhoneNumber.TabIndex = 37;
            // 
            // UpdateCustomerRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 469);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.textBoxZipCode);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxCustomerID);
            this.Controls.Add(this.Zip_Code);
            this.Controls.Add(this.State_Province);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.Phone_Number);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.Name2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpdateC);
            this.Name = "UpdateCustomerRecords";
            this.Text = "Update Customer Records";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UpdateC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Name2;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label Phone_Number;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.Label State_Province;
        private System.Windows.Forms.Label Zip_Code;
        private System.Windows.Forms.TextBox textBoxCustomerID;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxZipCode;
        private System.Windows.Forms.Button Update;
        private Button Cancel;
        private TextBox textBoxCountry;
        private TextBox textBoxCity;
        private MaskedTextBox textBoxPhoneNumber;
    }
}