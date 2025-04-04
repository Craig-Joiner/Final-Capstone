using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Craig_Joiner_Software_2
{
    public partial class UpdateCustomerRecords : Form
    {
        //string myConnection = "server=localhost;username=sqlUser;password=Passw0rd!;database=client_schedule";
        string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";
        private int customerId;

        public UpdateCustomerRecords(int passedCustomerId)
        {
            InitializeComponent();
            customerId = passedCustomerId;
            PopulateCustomerFields();
        }

        
        private void PopulateCustomerFields()
        {
            textBoxCustomerID.Text = customerId.ToString();

            string query = @"
        SELECT c.customerName, c.addressId, c.active, c.createDate, c.createdBy, c.lastUpdate, c.lastUpdateBy,
               a.address, a.postalCode, a.phone, ci.city, co.country 
        FROM customer c
        JOIN address a ON c.addressId = a.addressId
        JOIN city ci ON a.cityId = ci.cityId
        JOIN country co ON ci.countryId = co.countryId
        WHERE c.customerId = @customerId";

            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                try
                {
                    conn.Open(); 

                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@customerId", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                textBoxName.Text = reader["customerName"].ToString().Trim();
                                textBoxAddress.Text = reader["address"].ToString().Trim();
                                textBoxPhoneNumber.Text = reader["phone"].ToString().Trim();
                                textBoxCountry.Text = reader["Country"].ToString().Trim();
                                textBoxCity.Text = reader["City"].ToString().Trim();
                                textBoxZipCode.Text = reader["postalCode"].ToString().Trim();


                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error loading customer data: " + ex.Message);
                }
            } 
        }
        //Added .Trim() to textboxes to remove white space
        public bool IsFormValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxCustomerID.Text.Trim()))
            {
                MessageBox.Show("CustomerID is missing.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxName.Text.Trim()))
            {
                MessageBox.Show("Customer name is missing.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAddress.Text.Trim()))
            {
                MessageBox.Show("Address is missing.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxCity.Text.Trim()))
            {
                MessageBox.Show("City is missing.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxZipCode.Text.Trim()))
            {
                MessageBox.Show("Zip code is missing.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxCountry.Text.Trim()))
            {
                MessageBox.Show("Country is missing.");
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text.Trim()))
            {
                MessageBox.Show("Phone number is missing.");
                return false;
            }

            return true;
        }

        public void UpdateDBCustomer()
        {
            var currentUser = Environment.UserName;
            string customerName = textBoxName.Text;
            int active = 1;
            DateTime customerCreateDate = DateTime.Today;
            string customerCreatedBy = currentUser;
            DateTime customerLastUpdate = DateTime.Today;
            string customerLastUpdateBy = currentUser;
            var addressLine1 = textBoxAddress.Text;
            string address2 = "";
            int addressID = 0;
            int cityID = 0;
            int countryID = 0; 

            
            string countryName = textBoxCountry.Text;
            string cityName = textBoxCity.Text; 

            using (var conn = new MySqlConnection(myConnection))
            {
                conn.Open();

                
                string getCountryID = @"SELECT countryId FROM country WHERE country = @countryName";
                MySqlCommand commandCountry = new MySqlCommand(getCountryID, conn);
                commandCountry.Parameters.AddWithValue("@countryName", countryName);

                MySqlDataReader readerCountry = commandCountry.ExecuteReader();
                if (readerCountry.Read())
                {
                    countryID = readerCountry.GetInt32("countryId");
                }
                readerCountry.Close();

                
                if (countryID == 0)
                {
                    string insertCountry = @"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                     VALUES (@countryName, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                                     SELECT LAST_INSERT_ID();"; 

                    MySqlCommand insertCountryCommand = new MySqlCommand(insertCountry, conn);
                    insertCountryCommand.Parameters.AddWithValue("@countryName", countryName);
                    insertCountryCommand.Parameters.AddWithValue("@createDate", customerCreateDate);
                    insertCountryCommand.Parameters.AddWithValue("@createdBy", customerCreatedBy);
                    insertCountryCommand.Parameters.AddWithValue("@lastUpdate", customerLastUpdate);
                    insertCountryCommand.Parameters.AddWithValue("@lastUpdateBy", customerLastUpdateBy);

                    countryID = Convert.ToInt32(insertCountryCommand.ExecuteScalar()); 
                }

                
                string getCityID = @"SELECT cityId FROM city WHERE city = @cityName AND countryId = @countryID";
                MySqlCommand commandCity = new MySqlCommand(getCityID, conn);
                commandCity.Parameters.AddWithValue("@cityName", cityName);
                commandCity.Parameters.AddWithValue("@countryID", countryID);

                MySqlDataReader readerCity = commandCity.ExecuteReader();
                if (readerCity.Read())
                {
                    cityID = readerCity.GetInt32("cityId");
                }
                readerCity.Close();

                
                if (cityID == 0)
                {
                    string insertCity = @"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                  VALUES (@cityName, @countryID, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);
                                  SELECT LAST_INSERT_ID();"; 

                    MySqlCommand insertCityCommand = new MySqlCommand(insertCity, conn);
                    insertCityCommand.Parameters.AddWithValue("@cityName", cityName);
                    insertCityCommand.Parameters.AddWithValue("@countryID", countryID); 
                    insertCityCommand.Parameters.AddWithValue("@createDate", customerCreateDate);
                    insertCityCommand.Parameters.AddWithValue("@createdBy", customerCreatedBy);
                    insertCityCommand.Parameters.AddWithValue("@lastUpdate", customerLastUpdate);
                    insertCityCommand.Parameters.AddWithValue("@lastUpdateBy", customerLastUpdateBy);

                    cityID = Convert.ToInt32(insertCityCommand.ExecuteScalar()); 
                }

                
                string getAddressID = @"SELECT addressId FROM address WHERE address = @addressLine1";
                MySqlCommand commandAddress = new MySqlCommand(getAddressID, conn);
                commandAddress.Parameters.AddWithValue("@addressLine1", addressLine1);

                MySqlDataReader readerAddress = commandAddress.ExecuteReader();
                if (readerAddress.Read())
                {
                    addressID = readerAddress.GetInt32("addressId");
                }
                readerAddress.Close();

                
                if (addressID == 0)
                {
                    string insertAddress = @"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) 
                         VALUES (@addressLine1, @address2, @cityID, @zipCode, @phoneNumber, @customerCreateDate, @customerCreatedBy, @customerLastUpdate, @customerLastUpdateBy);
                         SELECT LAST_INSERT_ID();"; 

                    MySqlCommand insertAddressCommand = new MySqlCommand(insertAddress, conn);
                    insertAddressCommand.Parameters.AddWithValue("@addressLine1", addressLine1);
                    insertAddressCommand.Parameters.AddWithValue("@address2", address2);
                    insertAddressCommand.Parameters.AddWithValue("@cityID", cityID); 
                    insertAddressCommand.Parameters.AddWithValue("@zipCode", textBoxZipCode.Text);
                    insertAddressCommand.Parameters.AddWithValue("@phoneNumber", textBoxPhoneNumber.Text);
                    insertAddressCommand.Parameters.AddWithValue("@customerCreateDate", customerCreateDate);
                    insertAddressCommand.Parameters.AddWithValue("@customerCreatedBy", customerCreatedBy);
                    insertAddressCommand.Parameters.AddWithValue("@customerLastUpdate", customerLastUpdate);
                    insertAddressCommand.Parameters.AddWithValue("@customerLastUpdateBy", customerLastUpdateBy);

                    addressID = Convert.ToInt32(insertAddressCommand.ExecuteScalar()); 
                }
            }

            try
            {
                string updateDBCustomer = @"UPDATE customer SET customerName = @customerName, addressId = @addressID, active = @isActive, 
                                     createDate = @customerCreateDate, createdBy = @customerCreatedBy, 
                                     lastUpdate = @customerLastUpdate, lastUpdateBy = @customerLastUpdateBy 
                                     WHERE customerId = @customerID";

                using (var conn = new MySqlConnection(myConnection))
                {
                    MySqlCommand updateCommand = new MySqlCommand(updateDBCustomer, conn);
                    updateCommand.Parameters.AddWithValue("@customerID", customerId);
                    updateCommand.Parameters.AddWithValue("@customerName", customerName);
                    updateCommand.Parameters.AddWithValue("@addressID", addressID);
                    updateCommand.Parameters.AddWithValue("@isActive", active);
                    updateCommand.Parameters.AddWithValue("@customerCreateDate", customerCreateDate);
                    updateCommand.Parameters.AddWithValue("@customerCreatedBy", customerCreatedBy);
                    updateCommand.Parameters.AddWithValue("@customerLastUpdate", customerLastUpdate);
                    updateCommand.Parameters.AddWithValue("@customerLastUpdateBy", customerLastUpdateBy);

                    conn.Open();
                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDBAddress()
        {
            var currentUser = Environment.UserName;
            string addressLine1 = textBoxAddress.Text;
            int zipCode = int.Parse(textBoxZipCode.Text);
            string phoneNumber = textBoxPhoneNumber.Text;
            string cityName = textBoxCity.Text;
            int cityID = 0;
            int addressID = 0;

            using (var conn = new MySqlConnection(myConnection))
            {
                conn.Open();

                
                string getCityID = @"SELECT cityId FROM city WHERE city = @cityName";
                using (var command = new MySqlCommand(getCityID, conn))
                {
                    command.Parameters.AddWithValue("@cityName", cityName);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cityID = reader.GetInt32("cityId");
                        }
                    }
                }

                
                string getAddressID = @"SELECT addressId FROM address WHERE address = @addressLine1";
                using (var commandAddress = new MySqlCommand(getAddressID, conn))
                {
                    commandAddress.Parameters.AddWithValue("@addressLine1", addressLine1);
                    using (var readerAddress = commandAddress.ExecuteReader())
                    {
                        while (readerAddress.Read())
                        {
                            addressID = readerAddress.GetInt32("addressId");
                        }
                    }
                }

                
                string updateAddress = @"UPDATE address SET address = @addressLine1, cityId = @cityID, postalCode = @zipCode, phone = @phoneNumber,
                                     lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy WHERE addressId = @addressID";
                using (var updateCommand = new MySqlCommand(updateAddress, conn))
                {
                    updateCommand.Parameters.AddWithValue("@addressID", addressID);
                    updateCommand.Parameters.AddWithValue("@addressLine1", addressLine1);
                    updateCommand.Parameters.AddWithValue("@cityID", cityID);
                    updateCommand.Parameters.AddWithValue("@zipCode", zipCode);
                    updateCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    updateCommand.Parameters.AddWithValue("@lastUpdate", DateTime.Today);
                    updateCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDBCity()
        {
            var currentUser = Environment.UserName;
            string customerCity = textBoxCity.Text;
            string countryName = textBoxCountry.Text;
            int countryID = 0;
            int cityID = 0;

            using (var conn = new MySqlConnection(myConnection))
            {
                conn.Open();

                
                string getCountryID = @"SELECT countryId FROM country WHERE country = @countryName";
                using (var command = new MySqlCommand(getCountryID, conn))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            countryID = reader.GetInt32("countryId");
                        }
                    }
                }

                
                string getCityID = @"SELECT cityId FROM city WHERE city = @customerCity";
                using (var commandCity = new MySqlCommand(getCityID, conn))
                {
                    commandCity.Parameters.AddWithValue("@customerCity", customerCity);
                    using (var readerCity = commandCity.ExecuteReader())
                    {
                        while (readerCity.Read())
                        {
                            cityID = readerCity.GetInt32("cityId");
                        }
                    }
                }

                
                string updateCity = @"UPDATE city SET city = @customerCity, countryId = @countryID, lastUpdate = @lastUpdate, 
                                  lastUpdateBy = @lastUpdateBy WHERE cityId = @cityID";
                using (var updateCommand = new MySqlCommand(updateCity, conn))
                {
                    updateCommand.Parameters.AddWithValue("@cityID", cityID);
                    updateCommand.Parameters.AddWithValue("@customerCity", customerCity);
                    updateCommand.Parameters.AddWithValue("@countryID", countryID);
                    updateCommand.Parameters.AddWithValue("@lastUpdate", DateTime.Today);
                    updateCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDBCountry()
        {
            var currentUser = Environment.UserName;
            string customerCountry = textBoxCountry.Text;
            int countryID = 0;

            using (var conn = new MySqlConnection(myConnection))
            {
                conn.Open();

                
                string getCountryID = @"SELECT countryId FROM country WHERE country = @customerCountry";
                using (var command = new MySqlCommand(getCountryID, conn))
                {
                    command.Parameters.AddWithValue("@customerCountry", customerCountry);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            countryID = reader.GetInt32("countryId");
                        }
                    }
                }

                
                string updateCountry = @"UPDATE country SET country = @customerCountry, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy 
                                     WHERE countryId = @countryID";
                using (var updateCommand = new MySqlCommand(updateCountry, conn))
                {
                    updateCommand.Parameters.AddWithValue("@countryID", countryID);
                    updateCommand.Parameters.AddWithValue("@customerCountry", customerCountry);
                    updateCommand.Parameters.AddWithValue("@lastUpdate", DateTime.Today);
                    updateCommand.Parameters.AddWithValue("@lastUpdateBy", currentUser);

                    updateCommand.ExecuteNonQuery();
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                UpdateDBCustomer();
                UpdateDBAddress();
                UpdateDBCity();
                UpdateDBCountry();
                MessageBox.Show("Records have been updated successfully.");
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }
    private void Cancel_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
