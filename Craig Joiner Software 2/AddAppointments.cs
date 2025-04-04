using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types;

namespace Craig_Joiner_Software_2
{
    public partial class Add_Appointment : Form
    {
        //string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client_schedule";
        string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";


        public Add_Appointment()
        {
            InitializeComponent();
            StartTime1_ComboBox();
            EndTime1_ComboBox();

        }
       
        private void StartTime1_ComboBox()
        {

                StartTime1.Items.Clear();


                DateTime startTime = DateTime.Now.Date.AddHours(9);
                DateTime endTime = DateTime.Now.Date.AddHours(17);



                for (DateTime time = startTime; time < endTime; time = time.AddMinutes(15))
                {
                    StartTime1.Items.Add(time.ToString("hh:mm tt"));
                }


                if (StartTime1.Items.Count > 0)
                {
                    StartTime1.SelectedIndex = 0;
                }

        }

        private void EndTime1_ComboBox()
        {
        
                EndTime1.Items.Clear();


                DateTime startTime = DateTime.Now.Date.AddHours(9);
                DateTime endTime = DateTime.Now.Date.AddHours(17);


                for (DateTime time = startTime; time <= endTime; time = time.AddMinutes(15))
                {
                    EndTime1.Items.Add(time.ToString("hh:mm tt"));
                }


                if (EndTime1.Items.Count > 0)
                {
                    EndTime1.SelectedIndex = 0;
                }
         
        }
        
        public bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxDescription.Text.Trim()))
            {
                MessageBox.Show("Appointment title is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxType.Text.Trim()))
            {
                MessageBox.Show("Appointment description is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TitletextBox.Text.Trim()))
            {
                MessageBox.Show("Appointment location is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxLocation.Text.Trim()))
            {
                MessageBox.Show("Appointment type is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxContact.Text.Trim()))
            {
                MessageBox.Show("Appointment contact is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CustomerIDtext.Text.Trim()))
            {
                MessageBox.Show("Appointment customer is missing.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserIDtext.Text.Trim()))
            {
                MessageBox.Show("Appointment user is missing.");
                return false;
            }

            if (StartDate1.Value == null)
            {
                MessageBox.Show("Appointment start date is missing.");
                return false;
            }
         
            if (IsOutsideBusinessHours())
            {
                return false;
            }

            if (EndDate1.Value == null)
            {
                MessageBox.Show("Appointment end date is missing.");
                return false;
            }
          
            if (IsOutsideBusinessHours() || IsOutsideOfWeekday(StartDate1.Value))
            {
                return false;
            }

            if (IsOverlapAppointment())
            {
                return false;
            }


            return true;
        }

        public void AddAppointmentToDb(DateTime newStart, DateTime newEnd, int customerIds)//just added parameters to this method for testing
        {
            var currentUser = Environment.UserName;

           
            string appointmentTitle = TitletextBox.Text.Trim();
            string appointmentDescription = textBoxDescription.Text.Trim();
            string appointmentContact = textBoxContact.Text.Trim();
            string appointmentType = textBoxType.Text.Trim();
            string appointmentLocation = textBoxLocation.Text.Trim();
            string customerId = CustomerIDtext.Text.Trim();
            string userId = UserIDtext.Text.Trim();

            
            DateTime selectedStartTime = DateTime.ParseExact(StartTime1.SelectedItem.ToString(), "hh:mm tt", null);
            DateTime selectedEndTime = DateTime.ParseExact(EndTime1.SelectedItem.ToString(), "hh:mm tt", null);

           
            DateTime appointmentStart = StartDate1.Value.Date.Add(selectedStartTime.TimeOfDay).ToUniversalTime();
            DateTime appointmentEnd = EndDate1.Value.Date.Add(selectedEndTime.TimeOfDay).ToUniversalTime();

            DateTime appointmentCreatedDate = DateTime.UtcNow; 
            DateTime appointmentLastUpdate = DateTime.UtcNow;  

            int customerID = GetCustomerId(customerId);
            int userID = GetUserId(userId);

            try
            {
                string addAppointmentDB = @"
        INSERT INTO appointment 
        (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
        VALUES 
        (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                using (MySqlConnection conn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand addCommand = new MySqlCommand(addAppointmentDB, conn))
                    {
                        addCommand.Parameters.AddWithValue("@customerId", customerID);
                        addCommand.Parameters.AddWithValue("@userId", userID);
                        addCommand.Parameters.AddWithValue("@title", appointmentTitle);
                        addCommand.Parameters.AddWithValue("@description", appointmentDescription);
                        addCommand.Parameters.AddWithValue("@location", appointmentLocation);
                        addCommand.Parameters.AddWithValue("@contact", appointmentContact);
                        addCommand.Parameters.AddWithValue("@type", appointmentType);
                        addCommand.Parameters.AddWithValue("@url", customerId);  
                        addCommand.Parameters.AddWithValue("@start", appointmentStart);  
                        addCommand.Parameters.AddWithValue("@end", appointmentEnd);     
                        addCommand.Parameters.AddWithValue("@createDate", appointmentCreatedDate);  
                        addCommand.Parameters.AddWithValue("@createdBy", currentUser);
                        addCommand.Parameters.AddWithValue("@lastUpdate", appointmentLastUpdate); 
                        addCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                        conn.Open();
                        addCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while adding appointment: {ex.Message}");
            }
        }

        
        private int GetCustomerId(string customerId)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                conn.Open();
                string getCustomerID = @"SELECT customerId FROM customer WHERE customerId = @customerId";
                using (MySqlCommand command = new MySqlCommand(getCustomerID, conn))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    object result = command.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show($"No customer found with ID: {customerId}");
                        return 0; 
                    }
                    return Convert.ToInt32(result);
                }
            }
        }

        
        private int GetUserId(string userId)
        {
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                conn.Open();
                string getUserID = @"SELECT userId FROM user WHERE userId = @userId";
                using (MySqlCommand commandUser = new MySqlCommand(getUserID, conn))
                {
                    commandUser.Parameters.AddWithValue("@userId", userId);
                    object result = commandUser.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show($"No user found with ID: {userId}");
                        return 0; 
                    }
                    return Convert.ToInt32(result);
                }
            }
        }

         
        public bool IsOverlapAppointment() // i changed this from private to public for testing 
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

        private void SubmitA_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                return;
            }

            DateTime newStart = StartDate1.Value.Date.Add(DateTime.ParseExact(StartTime1.SelectedItem.ToString(), "hh:mm tt", null).TimeOfDay);
            DateTime newEnd = EndDate1.Value.Date.Add(DateTime.ParseExact(EndTime1.SelectedItem.ToString(), "hh:mm tt", null).TimeOfDay);
            int customerIds = int.Parse(CustomerIDtext.Text.Trim());

            AddAppointmentToDb(newStart, newEnd, customerIds);//added parameters to this method for testing
            Main main = new Main();
            this.Hide();
            main.Show();
        }
    private void Cancelbtn_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }
    }
}
