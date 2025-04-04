using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Craig_Joiner_Software_2
{
    public partial class LoginScreen : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnection;

        public LoginScreen()
        {
            InitializeComponent();
            check_location();
        }

        private void check_location()
        {
            RegionInfo region = RegionInfo.CurrentRegion;
            if (region.TwoLetterISORegionName == "RU")
            {
                Welcome.Text = "пожаловать";
                Username.Text = "имя пользователя";
                Password.Text = "пароль";
                Log_In.Text = " входить";
                Exit.Text = "выйти";
                Time_Zone.Text = "часовой пояс";
                Time_Zone.Visible = false;
                Time_Zone2.Visible = true;

            }

            else
            {
                Welcome.Text = "Welcome";
                Username.Text = "Username";
                Password.Text = "Password";
                Log_In.Text = "Log In";
                Exit.Text = "Exit";
                Time_Zone.Text = "Time Zone";
                Time_Zone.Visible = true;
                Time_Zone2.Visible = false;
            }
        }

        public void Log_In_Click(object sender, EventArgs e) 
        {

            var username = textBoxUsername.Text.Trim();
            var password = textBoxPassword.Text.Trim();
            DateTime createDate = DateTime.Today;
            var createdBy = username;
            var lastUpdate = DateTime.Today;
            var lastUpdatedBy = username;

            //myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client_schedule";
            myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnection;
                conn.Open();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            string checkDBLogin = "SELECT * FROM user WHERE username = @loginname AND password = @password";

            DataTable dataTable = new DataTable();

            MySqlCommand mySqlCommand = new MySqlCommand(checkDBLogin);
            mySqlCommand.Parameters.AddWithValue("@loginname", username);
            mySqlCommand.Parameters.AddWithValue("@password", password);

            mySqlCommand.Connection = conn;

            int adapter = new MySqlDataAdapter(mySqlCommand).Fill(dataTable);

            string folderPath = @"C:\UserLoginLog";
            string fileName = @"\Login_History.txt";
            fileName = folderPath + fileName;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (dataTable.Rows.Count <= 0)
            {
                MessageBox.Show("Invalid username or password. Please try again.");

                using (StreamWriter userLoginFile = File.AppendText(fileName))
                {
                    string loginResult = "Failed login for user: " + username + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");

                    userLoginFile.WriteLine(loginResult);
                    userLoginFile.Close();
                }
                return;
            }
            else
            {
                using (StreamWriter userLoginFile = File.AppendText(fileName))
                {

                    string loginResult = "User:" + username + "logged in at " + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");

                    userLoginFile.WriteLine(loginResult);
                    userLoginFile.Close();

                }
                Main main = new Main();
                this.Hide();
                main.Show();
            }

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
