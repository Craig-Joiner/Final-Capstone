namespace Craig_Joiner_Software_2
{
    partial class LoginScreen
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
            this.Log_In = new System.Windows.Forms.Button();
            this.Welcome = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.Exit = new System.Windows.Forms.Button();
            this.Time_Zone = new System.Windows.Forms.Label();
            this.Time_zone1 = new System.Windows.Forms.Label();
            this.Time_Zone2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Log_In
            // 
            this.Log_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Log_In.Location = new System.Drawing.Point(258, 256);
            this.Log_In.Name = "Log_In";
            this.Log_In.Size = new System.Drawing.Size(111, 44);
            this.Log_In.TabIndex = 0;
            this.Log_In.Text = "Log In";
            this.Log_In.UseVisualStyleBackColor = true;
            this.Log_In.Click += new System.EventHandler(this.Log_In_Click);
            // 
            // Welcome
            // 
            this.Welcome.AutoSize = true;
            this.Welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Welcome.Location = new System.Drawing.Point(60, 44);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(115, 29);
            this.Welcome.TabIndex = 1;
            this.Welcome.Text = "Welcome";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Username.Location = new System.Drawing.Point(128, 149);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(124, 29);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Password.Location = new System.Drawing.Point(132, 202);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(120, 29);
            this.Password.TabIndex = 3;
            this.Password.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxUsername.Location = new System.Drawing.Point(258, 149);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(239, 34);
            this.textBoxUsername.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxPassword.Location = new System.Drawing.Point(258, 199);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(243, 34);
            this.textBoxPassword.TabIndex = 5;
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Exit.Location = new System.Drawing.Point(390, 256);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(111, 44);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Time_Zone
            // 
            this.Time_Zone.AutoSize = true;
            this.Time_Zone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Time_Zone.Location = new System.Drawing.Point(128, 332);
            this.Time_Zone.Name = "Time_Zone";
            this.Time_Zone.Size = new System.Drawing.Size(130, 29);
            this.Time_Zone.TabIndex = 7;
            this.Time_Zone.Text = "Time Zone";
            // 
            // Time_zone1
            // 
            this.Time_zone1.AutoSize = true;
            this.Time_zone1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Time_zone1.Location = new System.Drawing.Point(278, 332);
            this.Time_zone1.Name = "Time_zone1";
            this.Time_zone1.Size = new System.Drawing.Size(207, 29);
            this.Time_zone1.TabIndex = 8;
            this.Time_zone1.Text = "America/Nashville";
            // 
            // Time_Zone2
            // 
            this.Time_Zone2.AutoSize = true;
            this.Time_Zone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Time_Zone2.Location = new System.Drawing.Point(278, 332);
            this.Time_Zone2.Name = "Time_Zone2";
            this.Time_Zone2.Size = new System.Drawing.Size(296, 29);
            this.Time_Zone2.TabIndex = 9;
            this.Time_Zone2.Text = "Eastern European/Ukraine";
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Time_Zone2);
            this.Controls.Add(this.Time_zone1);
            this.Controls.Add(this.Time_Zone);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Welcome);
            this.Controls.Add(this.Log_In);
            this.Name = "LoginScreen";
            this.Text = "Login Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Log_In;
        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label Time_Zone;
        private System.Windows.Forms.Label Time_zone1;
        private System.Windows.Forms.Label Time_Zone2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}

