using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Craig_Joiner_Software_2
{
    public partial class UpdateAppointments: Form
    {

        //string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client_schedule";
        string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";
        private int appointmentId;
        public UpdateAppointments(int passedappointmentId)  
        {
            InitializeComponent();
            appointmentId = passedappointmentId;
            PopulateAppointmentFields();

        }
        private void PopulateAppointmentFields()
        {
            AppIDtext.Text = appointmentId.ToString();

            string query = @"
            SELECT appointmentId, title, description, location, start, end, contact, type, customerId, userId
            FROM appointment
            WHERE appointmentId = @appointmentId";

            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@appointmentId", GetSelectedAppointmentId());

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                AppIDtext.Text = reader["appointmentId"].ToString().Trim();
                                Titletext.Text = reader["title"].ToString().Trim();
                                Descriptiontext.Text = reader["description"].ToString().Trim();
                                Locationtext.Text = reader["location"].ToString().Trim();

                                
                                DateTime utcStart = Convert.ToDateTime(reader["start"]);
                                DateTime utcEnd = Convert.ToDateTime(reader["end"]);
                                TimeZoneInfo localZone = TimeZoneInfo.Local;

                                DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, localZone);
                                DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, localZone);

                                
                                StartDate1.Value = localStart.Date;
                                EndDate1.Value = localEnd.Date;

                                
                                StartTime1.Text = localStart.ToString("hh:mm tt");
                                EndTime1.Text = localEnd.ToString("hh:mm tt");

                                Contacttext.Text = reader["contact"].ToString().Trim();
                                Typetext.Text = reader["type"].ToString().Trim();
                                CustomerIDtext.Text = reader["customerId"].ToString().Trim();
                                UserIdtext.Text = reader["userId"].ToString().Trim();
                            }
                            else
                            {
                                MessageBox.Show("Appointment not found.");
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error loading appointment data: " + ex.Message);
                }
            }
        }

        public bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(Titletext.Text.Trim()))
            {
                MessageBox.Show("Appointment title is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Descriptiontext.Text.Trim()))
            {
                MessageBox.Show("Appointment description is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Locationtext.Text.Trim()))
            {
                MessageBox.Show("Appointment location is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Typetext.Text.Trim()))
            {
                MessageBox.Show("Appointment type is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Contacttext.Text.Trim()))
            {
                MessageBox.Show("Appointment contact is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CustomerIDtext.Text.Trim()))
            {
                MessageBox.Show("Appointment customer is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserIdtext.Text.Trim()))
            {
                MessageBox.Show("Appointment user is missing.");
                return false;
            }

            if (StartDate1.Value == null)
            {
                MessageBox.Show("Appointment start date is missing.");
                return false;
            }
            else if (StartDate1.Value > EndDate1.Value)
            {
                MessageBox.Show("Appointment start date cannot be after the appointment end time.");
                return false;
            }
            else if (IsOutsideBusinessHours())
            {
                return false;
            }

            if (EndDate1.Value == null)
            {
                MessageBox.Show("Appointment end date is missing.");
                return false;
            }
            else if (EndDate1.Value < StartDate1.Value)
            {
                MessageBox.Show("Appointment end date cannot be before the appointment start time.");
                return false;
            }
            else if (IsOutsideBusinessHours() || IsOutsideOfWeekday(StartDate1.Value))
            {
                return false;
            }
            if (IsOverlapAppointment())
            {
                return false;
            }

            return true;
        }
        public void UpdateAppointmentInDb(int appointmentId)
        {

            if (!IsFormValid())
            {
                return; 
            }

            if (IsOutsideBusinessHours())
            {
                return; 
            }

            var currentUser = Environment.UserName;

            
            string appointmentTitle = Titletext.Text.Trim();
            string appointmentDescription = Descriptiontext.Text.Trim();
            string appointmentContact = Contacttext.Text.Trim();
            string appointmentType = Typetext.Text.Trim();
            string appointmentLocation = Locationtext.Text.Trim();
            string customerID = CustomerIDtext.Text.Trim();
            string userID = UserIdtext.Text.Trim();
            
             

            DateTime appointmentStart = StartDate1.Value.Date.Add(DateTime.ParseExact(StartTime1.SelectedItem.ToString(), "hh:mm tt", null).TimeOfDay).ToUniversalTime();
            DateTime appointmentEnd = EndDate1.Value.Date.Add(DateTime.ParseExact(EndTime1.SelectedItem.ToString(), "hh:mm tt", null).TimeOfDay).ToUniversalTime();
            DateTime appointmentLastUpdate = DateTime.Now;

            try
            {
                string updateAppointmentDB = @"
                UPDATE appointment
                SET customerId = @customerId, 
                userId = @userId, 
                title = @title, 
                description = @description, 
                location = @location, 
                contact = @contact, 
                type = @type, 
                url = @url, 
                start = @start, 
                end = @end, 
                lastUpdate = @lastUpdate, 
                lastUpdateBy = @lastUpdateBy
                WHERE appointmentId = @appointmentId";

                using (MySqlConnection conn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand updateCommand = new MySqlCommand(updateAppointmentDB, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@customerId", customerID);
                        updateCommand.Parameters.AddWithValue("@userId", userID);
                        updateCommand.Parameters.AddWithValue("@title", appointmentTitle);
                        updateCommand.Parameters.AddWithValue("@description", appointmentDescription);
                        updateCommand.Parameters.AddWithValue("@location", appointmentLocation);
                        updateCommand.Parameters.AddWithValue("@contact", appointmentContact);
                        updateCommand.Parameters.AddWithValue("@type", appointmentType);
                        updateCommand.Parameters.AddWithValue("@url", customerID.ToString()); 
                        updateCommand.Parameters.AddWithValue("@start", appointmentStart);
                        updateCommand.Parameters.AddWithValue("@end", appointmentEnd);
                        updateCommand.Parameters.AddWithValue("@lastUpdate", appointmentLastUpdate);
                        updateCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);
                        updateCommand.Parameters.AddWithValue("@appointmentId", appointmentId);

                        conn.Open();
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while updating appointment: {ex.Message}");
            }
        }
        
        private int GetSelectedAppointmentId()
        {
            
            if (string.IsNullOrWhiteSpace(AppIDtext.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid appointment ID.");
                return 0; 
            }

            
            if (int.TryParse(AppIDtext.Text.Trim(), out int appointmentId))
            {
                return appointmentId; 
            }
            else
            {
                MessageBox.Show("Invalid appointment ID format. Please enter a numeric value.");
                return 0; 
            }
        }
        private bool IsOverlapAppointment()
        {

            if (DateTime.TryParse(StartTime1.SelectedItem?.ToString(), out DateTime selectedStartTime) &&
                DateTime.TryParse(EndTime1.SelectedItem?.ToString(), out DateTime selectedEndTime))
            {
                DateTime startDateTime = StartDate1.Value.Date + selectedStartTime.TimeOfDay;
                DateTime endDateTime = EndDate1.Value.Date + selectedEndTime.TimeOfDay;


                DateTime startUtc = TimeZoneInfo.ConvertTimeToUtc(startDateTime, TimeZoneInfo.Local);
                DateTime endUtc = TimeZoneInfo.ConvertTimeToUtc(endDateTime, TimeZoneInfo.Local);


                using (MySqlConnection conn = new MySqlConnection(myConnection))
                {
                    conn.Open();
                    string checkOverlappingAppointments = @"
                    SELECT COUNT(*) FROM appointment 
                    WHERE (start < @end AND end > @start)";

                    using (MySqlCommand command = new MySqlCommand(checkOverlappingAppointments, conn))
                    {
                        command.Parameters.AddWithValue("@start", startUtc);
                        command.Parameters.AddWithValue("@end", endUtc);

                        int overlappingCount = Convert.ToInt32(command.ExecuteScalar());
                        if (overlappingCount > 0)
                        {
                            MessageBox.Show("There is already an appointment at this time. Please select a new start time.");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool IsOutsideBusinessHours()
        {
            
            TimeSpan startBusinessHour = new TimeSpan(9, 0, 0); 
            TimeSpan endBusinessHour = new TimeSpan(17, 0, 0);  

            
            DateTime selectedStartTime = DateTime.ParseExact(StartTime1.SelectedItem.ToString(), "hh:mm tt", null);
            DateTime selectedEndTime = DateTime.ParseExact(EndTime1.SelectedItem.ToString(), "hh:mm tt", null);

            
            DateTime appointmentStart = StartDate1.Value.Date.Add(selectedStartTime.TimeOfDay);
            DateTime appointmentEnd = EndDate1.Value.Date.Add(selectedEndTime.TimeOfDay);

            
            if (appointmentStart.TimeOfDay < startBusinessHour || appointmentEnd.TimeOfDay > endBusinessHour)
            {
                MessageBox.Show("Appointment must be scheduled within business hours (9 AM - 5 PM).");
                return true;
            }

            return false;
        }
        private bool IsOutsideOfWeekday(DateTime appointmentDate)
        {

            if (appointmentDate.DayOfWeek == DayOfWeek.Saturday || appointmentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Appointments must be scheduled between Monday and Friday.");
                return true;
            }

            return false;
        }
        private void UpdateA_Click(object sender, EventArgs e)
        {
            
            if (!IsFormValid())
            {
                return; 
            }

            
            int appointmentId = GetSelectedAppointmentId();

            
            if (appointmentId != 0)
            {
                UpdateAppointmentInDb(appointmentId);
                MessageBox.Show("Records have been updated successfully.");
                Main main = new Main();
                this.Hide();
                main.Show();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }
    }
}
