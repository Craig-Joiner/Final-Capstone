using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Craig_Joiner_Software_2.Model
{
    public class Directory
    {
        public static Customer LookupCustomer(int customerID)
        {
            string myConnection = "server=localhost;port=3306;username=sqlUser;password=Passw0rd!;database=client";

            // SQL query to select the customer by customerID
            string query = "SELECT * FROM customer WHERE CustomerID = @CustomerID";

            // Create a connection and a command object
            using (MySqlConnection conn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    try
                    {
                        // Add the parameter for the query
                        command.Parameters.AddWithValue("@CustomerID", customerID);

                        // Open the connection
                        conn.Open();

                        // Execute the query and get the result
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // We only need to read the first (and only) row
                            {
                                // Create a customer object and map the database values to the object
                                var customer = new Customer
                                {
                                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"))
                                };

                                return customer; // Return the customer object
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        // It's better to log this error or handle it accordingly in a real application
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }

            return null; // Return null if no customer is found
        }
    }
}
