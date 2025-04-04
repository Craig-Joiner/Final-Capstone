using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Craig_Joiner_Software_2
{
    public partial class Reports : Form
    {
        //string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client_schedule";
        string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";
        public Reports()
        {
            InitializeComponent();
            PopulateCustomerContact();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            
            dgvAppointmentInfo.DataSource = LoadAppointmentInfo();
            dgvLocation.DataSource = LoadLocationInfo();
            
        }
        private void PopulateCustomerContact()
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                string selectQuery = "SELECT customerName FROM customer";

                MySqlCommand command = new MySqlCommand(selectQuery, conn);

                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            CustomerContact.Items.Add(reader["customerName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void CustomerContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedCustomer = CustomerContact.SelectedItem.ToString();

            
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                string query = @"
            SELECT 
                a.appointmentId AS 'ID', 
                a.title AS 'Title', 
                a.type AS 'Type', 
                a.description AS 'Description', 
                a.location AS 'Location', 
                a.start AS 'Start Date/Time', 
                a.end AS 'End Date/Time', 
                a.customerId AS 'Customer ID'
            FROM 
                appointment a
            JOIN 
                customer c ON a.customerId = c.customerId
            WHERE 
                c.customerName = @customerName";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@customerName", selectedCustomer);

                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable reportTable = new DataTable();
                    adapter.Fill(reportTable);

                    
                    dgvReport.DataSource = reportTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private DataTable LoadAppointmentInfo()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                string selectQuery = @"SELECT type, 
                                      MONTH(start) AS Month, 
                                      COUNT(*) AS TotalAppointments 
                               FROM appointment 
                               GROUP BY type, Month";

                MySqlCommand command = new MySqlCommand(selectQuery, conn);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    
                    dataTable.Load(reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return dataTable; 
        }

        private DataTable LoadLocationInfo()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                string selectQuery = @"SELECT city.city AS City, 
                                      country.country AS Country
                               FROM city
                               INNER JOIN country ON city.countryId = country.countryId";


                MySqlCommand command = new MySqlCommand(selectQuery, conn);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    
                    dataTable.Load(reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return dataTable; 
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            this.Hide();
            loginScreen.Show();
        }

       
    }
}
