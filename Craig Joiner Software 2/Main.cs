using Craig_Joiner_Software_2.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Management.Instrumentation;
using System.Windows.Forms;

namespace Craig_Joiner_Software_2
{
    public partial class Main : Form
    {
        //string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client_schedule";
        string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";

        public Main()
        {
            
            InitializeComponent();

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvAppointments.DataSource = GetAppointmentInfo();
            dgvCustomers.DataSource = GetCustomerData();
            CheckUpcomingAppointments(this, EventArgs.Empty);
            All_appointments.Checked = true;

        }
        private void CheckUpcomingAppointments(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now.ToUniversalTime();
            DateTime timeInFifteenMinutes = currentTime.AddMinutes(15);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnection))
                {
                    conn.Open();

                    string query = @"
                    SELECT appointmentId, title, start 
                    FROM appointment 
                    WHERE start BETWEEN @currentTime AND @timeInFifteenMinutes";

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@currentTime", currentTime);
                        command.Parameters.AddWithValue("@timeInFifteenMinutes", timeInFifteenMinutes);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string appointmentTitle = reader["title"].ToString();
                                DateTime appointmentStart = Convert.ToDateTime(reader["start"]).ToLocalTime();


                                DialogResult result = MessageBox.Show(
                                    $"You have an appointment '{appointmentTitle}' starting at {appointmentStart}.",
                                    "Upcoming Appointment",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for upcoming appointments: {ex.Message}");
            }
        }

        private DataTable GetAppointmentInfo()
        {
            DataTable dtAppointments = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM appointment", conn))
                    {
                        conn.Open();

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dtAppointments);
                        }

                        foreach (DataRow row in dtAppointments.Rows)
                        {
                            row["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)row["start"], TimeZoneInfo.Local);
                            row["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)row["end"], TimeZoneInfo.Local);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dtAppointments;
        }

        private DataTable GetCustomerData()
        {
            DataTable dtCustomers = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnection))
                {
                    conn.Open();

                    string customerData = @"SELECT DISTINCT customerId, customerName, address, address2, postalCode, phone, city, country 
                      FROM customer
                     INNER JOIN address ON customer.addressId = address.addressId
                     INNER JOIN city ON address.cityId = city.cityId
                     INNER JOIN country ON country.countryId = city.countryId";



                    using (MySqlCommand customerCommand = new MySqlCommand(customerData, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(customerCommand))
                        {
                            adapter.Fill(dtCustomers);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dtCustomers;
        }

        private void UpdateA_Click(object sender, EventArgs e)
        {
            int selectedAppointmentId = (int)dgvAppointments.CurrentRow.Cells["appointmentId"].Value;

            UpdateAppointments updateAppointments = new UpdateAppointments(selectedAppointmentId);
                this.Hide();
                updateAppointments.Show();
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            this.Hide();
            reports.Show();
        }

        private void ExitM_Click(object sender, EventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            this.Hide();
            loginScreen.Show();

        }

        private void AddA_Click(object sender, EventArgs e)
        {
            Add_Appointment addapointment = new Add_Appointment();
            this.Hide();
            addapointment.Show();
        }

        private void AddC_Click(object sender, EventArgs e)
        {
            Add_Customers add_Customers = new Add_Customers();
            this.Hide();
            add_Customers.Show();
        }

        private void UpdateC_Click(object sender, EventArgs e)
        {
            int selectedCustomerId = (int)dgvCustomers.CurrentRow.Cells["customerId"].Value;


            UpdateCustomerRecords updateCustomerForm = new UpdateCustomerRecords(selectedCustomerId);
            updateCustomerForm.Show();
            this.Hide();
        }

        private void All_appointments_CheckedChanged(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection(myConnection);
            conn.Open();

            string sqlAllAppsStatement = @"SELECT * FROM appointment";

            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sqlAllAppsStatement, conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["Start"] != DBNull.Value)
                    {

                        DateTime utcTime = (DateTime)row["Start"];
                        row["Start"] = utcTime.ToLocalTime();
                    }

                    if (row["End"] != DBNull.Value)
                    {

                        DateTime utcEndTime = (DateTime)row["End"];
                        row["End"] = utcEndTime.ToLocalTime();
                    }
                }


                dgvAppointments.DataSource = dataTable;
            }

            conn.Close();
        }

        private void Current_week_CheckedChanged(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open();

                    DateTime dtNow = DateTime.UtcNow;
                    DateTime dt7Days = dtNow.AddDays(7);

                    string sqlByWeekStatement = @"SELECT * FROM appointment WHERE start BETWEEN @dtNow AND @dt7Days";
                    using (MySqlCommand command = new MySqlCommand(sqlByWeekStatement, conn))
                    {
                        command.Parameters.AddWithValue("@dtNow", dtNow);
                        command.Parameters.AddWithValue("@dt7Days", dt7Days);

                        DataTable dataTable = new DataTable();

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }


                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["start"] != DBNull.Value)
                            {
                                DateTime utcStartTime = (DateTime)row["start"];
                                row["start"] = utcStartTime.ToLocalTime();
                            }

                            if (row["end"] != DBNull.Value)
                            {
                                DateTime utcEndTime = (DateTime)row["end"];
                                row["end"] = utcEndTime.ToLocalTime();
                            }
                        }

                        if (dataTable.Rows.Count > 0)
                        {
                            dgvAppointments.DataSource = dataTable;
                        }
                        else
                        {
                            dgvAppointments.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void Current_month_CheckedChanged(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open();

                    DateTime dtNow = DateTime.UtcNow;
                    DateTime dt30Days = dtNow.AddDays(30);

                    string sqlByMonthStatement = @"SELECT * FROM appointment WHERE start BETWEEN @dtNow AND @dt30Days";
                    using (MySqlCommand command = new MySqlCommand(sqlByMonthStatement, conn))
                    {
                        command.Parameters.AddWithValue("@dtNow", dtNow);
                        command.Parameters.AddWithValue("@dt30Days", dt30Days);

                        DataTable dataTable = new DataTable();

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }


                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["start"] != DBNull.Value)
                            {
                                DateTime utcStartTime = (DateTime)row["start"];
                                row["start"] = utcStartTime.ToLocalTime();
                            }

                            if (row["end"] != DBNull.Value)
                            {
                                DateTime utcEndTime = (DateTime)row["end"];
                                row["end"] = utcEndTime.ToLocalTime();
                            }
                        }

                        if (dataTable.Rows.Count > 0)
                        {
                            dgvAppointments.DataSource = dataTable;
                        }
                        else
                        {
                            dgvAppointments.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date; 

            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open();

                    string sqlByDateStatement = @"SELECT * FROM appointment 
                                          WHERE DATE(start) = @selectedDate";
                    using (MySqlCommand command = new MySqlCommand(sqlByDateStatement, conn))
                    {
                        command.Parameters.AddWithValue("@selectedDate", selectedDate);

                        DataTable dataTable = new DataTable();

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["start"] != DBNull.Value)
                            {
                                DateTime utcStartTime = (DateTime)row["start"];
                                row["start"] = utcStartTime.ToLocalTime();  
                            }

                            if (row["end"] != DBNull.Value)
                            {
                                DateTime utcEndTime = (DateTime)row["end"];
                                row["end"] = utcEndTime.ToLocalTime();
                            }
                        }

                        
                        dgvAppointments.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        // I need to work on this 
        private void SearchCustomerbyID_Click(object sender, EventArgs e)
        {
            int searchValue;
            if (!int.TryParse(textBoxCustomer.Text, out searchValue) || searchValue < 1)
            {
                return;
            }

            Customer match = Directory.LookupCustomer(searchValue);

            if (match == null)
            {
                MessageBox.Show("Customer not found.");
                return;  // No need to continue if no match was found
            }

            bool customerFound = false;
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                DataRowView rowView = (DataRowView)row.DataBoundItem;
                int customerID = (int)rowView["CustomerID"];
                row.Selected = (customerID == match.CustomerID);

                if (customerID == match.CustomerID)
                {
                    customerFound = true;
                    break;  // Exit the loop once the customer is found and selected
                }
            }

            // If no match was found, show the message after the loop
            if (!customerFound)
            {
                MessageBox.Show("Customer not found.");
            }
        }

        private void textBoxCustomer_TextChanged(object sender, EventArgs e)
        {
            SearchCustomerbyID.Enabled = !string.IsNullOrWhiteSpace(textBoxCustomer.Text);
        }

        private void DeleteA_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];
                int appointmentId = Convert.ToInt32(selectedRow.Cells["AppointmentID"].Value);

                
                DialogResult result = MessageBox.Show("Are you sure you would like to delete this appointment?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        
                        DeleteAppointment(appointmentId);
                        dgvAppointments.Rows.Remove(selectedRow);
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        
        private void DeleteAppointment(int appointmentId)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    string deleteQuery = "DELETE FROM appointment WHERE appointmentId = @appointmentId";
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, conn))
                    {
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("An error occurred while deleting the appointment.", ex);
                }
            }
        }

        
        private void DeleteC_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);

                
                DialogResult result = MessageBox.Show("Are you sure you would like to delete this customer?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        
                        DeleteCustomer(customerId);
                        dgvCustomers.Rows.Remove(selectedRow); 
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        
        private void DeleteCustomer(int customerId)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    string deleteQuery = "DELETE FROM customer WHERE customerId = @customerId";
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, conn))
                    {
                        command.Parameters.AddWithValue("@customerId", customerId);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("An error occurred while deleting the customer.", ex);
                }
            }
        }
    }
}
