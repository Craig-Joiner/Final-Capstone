using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace Craig_Joiner_Software_2
{
    public partial class Add_Customers : Form
    {

        MySql.Data.MySqlClient.MySqlConnection conn;
        //string myConnection = "server=localhost;username=sqlUser;password=Passw0rd!;database=client_schedule";
        string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";

        public Add_Customers()
        {
            InitializeComponent();
        }
        //Added .Trim() to textboxes to remove white space
        public bool IsFormValid()
        {
            
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


            if (!textBoxPhoneNumber.MaskFull)
            {
                MessageBox.Show("Phone number is missing or invalid.");
                return false;
            }
        
            return true;
        }

        public void GetDBConnection()
        {
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnection);
                conn.Open();  
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);  
                
            }
        }

        
        public void CloseDBConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();  
                
            }
        }

        
        public void AddCustomerToDB(int addressID)
        {
            GetDBConnection();
            
            try
            {
                string customerName = textBoxName.Text;
                int active = 1;
                DateTime customerCreateDate = DateTime.Today;

                string insertCustomerDB = @"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                 VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand insertCommand = new MySqlCommand(insertCustomerDB, conn);

                insertCommand.Parameters.AddWithValue("@customerName", customerName);
                insertCommand.Parameters.AddWithValue("@addressId", addressID); 
                insertCommand.Parameters.AddWithValue("@active", active);
                insertCommand.Parameters.AddWithValue("@createDate", customerCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", Environment.UserName);
                insertCommand.Parameters.AddWithValue("@lastUpdate", DateTime.Today);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", Environment.UserName);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                {
                    CloseDBConnection();
                }
            }
        }
        public int AddAddressToDB()
        {
            string address2 = "";
            int addressID = 0;

            GetDBConnection();

            try
            {
                string addressLine1 = textBoxAddress.Text;
                int zipCode = int.Parse(textBoxZipCode.Text);
                var phoneNumber = textBoxPhoneNumber.Text;
                string cityName = textBoxCity.Text;
                int cityID = 0;

                
                string getCityID = @"SELECT cityId FROM city WHERE city = @cityName";
                MySqlCommand cityCommand = new MySqlCommand(getCityID, conn);
                cityCommand.Parameters.AddWithValue("@cityName", cityName);

                MySqlDataReader cityReader = cityCommand.ExecuteReader();
                if (cityReader.Read())
                {
                    cityID = cityReader.GetInt32("cityId");
                }
                cityReader.Close();

                
                string checkAddressSQL = @"SELECT addressId FROM address WHERE address = @address AND cityId = @cityId AND postalCode = @postalCode";
                MySqlCommand checkAddressCommand = new MySqlCommand(checkAddressSQL, conn);
                checkAddressCommand.Parameters.AddWithValue("@address", addressLine1);
                checkAddressCommand.Parameters.AddWithValue("@cityId", cityID);
                checkAddressCommand.Parameters.AddWithValue("@postalCode", zipCode);

                MySqlDataReader addressReader = checkAddressCommand.ExecuteReader();
                if (addressReader.Read())
                {
                    
                    addressID = addressReader.GetInt32("addressId");
                }
                addressReader.Close();

                
                if (addressID == 0)
                {
                    string insertAddressSQL = @"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
                                        VALUES (@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                    MySqlCommand insertAddressCommand = new MySqlCommand(insertAddressSQL, conn);
                    insertAddressCommand.Parameters.AddWithValue("@address", addressLine1);
                    insertAddressCommand.Parameters.AddWithValue("@address2", address2);
                    insertAddressCommand.Parameters.AddWithValue("@cityId", cityID);
                    insertAddressCommand.Parameters.AddWithValue("@postalCode", zipCode);
                    insertAddressCommand.Parameters.AddWithValue("@phone", phoneNumber);
                    insertAddressCommand.Parameters.AddWithValue("@createDate", DateTime.Today);
                    insertAddressCommand.Parameters.AddWithValue("@createdBy", Environment.UserName);
                    insertAddressCommand.Parameters.AddWithValue("@lastUpdate", DateTime.Today);
                    insertAddressCommand.Parameters.AddWithValue("@lastUpdateBy", Environment.UserName);

                    insertAddressCommand.ExecuteNonQuery();

                    
                    string getLastInsertIDSQL = "SELECT LAST_INSERT_ID()";
                    MySqlCommand getLastInsertIDCommand = new MySqlCommand(getLastInsertIDSQL, conn);
                    addressID = Convert.ToInt32(getLastInsertIDCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                {
                    CloseDBConnection();
                }
            }

            return addressID; 
        }

        public void AddCityToDB()
        {
            var currentUser = Environment.UserName;
            var customerCity = textBoxCity.Text;
            var cityCreateDate = DateTime.Today;
            var cityCreatedBy = currentUser;
            var cityLastUpdate = DateTime.Today;
            var cityLastUpdateBy = currentUser;
            int countryID = 0;
            var countryName = textBoxCountry.Text;

            
            GetDBConnection();

            try
            {
                
                string getCountryID = @"SELECT countryId FROM country WHERE country = @countryName";
                MySqlCommand command = new MySqlCommand(getCountryID, conn);
                command.Parameters.AddWithValue("@countryName", countryName);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        countryID = reader.GetInt32("countryId");
                    }
                }

                
                string insertCityDB = @"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                VALUES(@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                MySqlCommand insertCommand = new MySqlCommand(insertCityDB, conn);
                insertCommand.Parameters.AddWithValue("@city", customerCity);
                insertCommand.Parameters.AddWithValue("@countryId", countryID);
                insertCommand.Parameters.AddWithValue("@createDate", cityCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", cityCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", cityLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", cityLastUpdateBy);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                {
                    CloseDBConnection();
                }
            }
        }


        public void AddCountryToDB()
        {
            var currentUser = Environment.UserName;
            var customerCountry = textBoxCountry.Text;
            var countryCreateDate = DateTime.Today;
            var countryCreatedBy = currentUser;
            var countryLastUpdate = DateTime.Today;
            var countryLastUpdateBy = currentUser;

            GetDBConnection();

            try
            {
                string insertCountryDB = @"INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) 
                                   VALUES(@country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";

                MySqlCommand insertCommand = new MySqlCommand(insertCountryDB, conn);
                insertCommand.Parameters.AddWithValue("@country", customerCountry);
                insertCommand.Parameters.AddWithValue("@createDate", countryCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", countryCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", countryLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", countryLastUpdateBy);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                {
                    CloseDBConnection();
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                try
                {
                    GetDBConnection();

                    
                    AddCountryToDB();  
                    AddCityToDB();      

                    
                    int addressID = AddAddressToDB();

                   
                    AddCustomerToDB(addressID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding customer: " + ex.Message);
                }
                finally
                {
                    CloseDBConnection();
                }

                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Form is invalid. Please verify all fields and click Save again.");
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}



