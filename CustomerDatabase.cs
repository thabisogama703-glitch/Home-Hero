using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace HomeHero_2
{
    public class CustomerDatabase
    {
        public void AddCustomer(Customer customer)
        {
            DatabaseConnection database = new DatabaseConnection();

            using (SqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string query = @"INSERT INTO Customers
                                (CustomerId, Name, Email, PhoneNumber, Password)
                                VALUES
                                (@CustomerId, @Name, @Email, @PhoneNumber, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customer.UserId);
                    command.Parameters.AddWithValue("@Name", customer.FirstName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@Password", customer.GetPassword());

                    command.ExecuteNonQuery();
                }
            }
        }

        public Customer LoginCustomer(string email, string password)
        {
            DatabaseConnection database = new DatabaseConnection();

            using (SqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT CustomerId, Name, Email, PhoneNumber, Password
                         FROM Customers
                         WHERE Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Customer customer = new Customer(
                                reader["Name"].ToString(),
                                "",
                                reader["PhoneNumber"].ToString(),
                                reader["Email"].ToString(),
                                reader["Password"].ToString());

                            return customer;
                        }
                    }
                }
            }

            return null;
        }

        public ServiceProvider LoginServiceProvider(string email, string password)
        {
            DatabaseConnection database = new DatabaseConnection();

            using (SqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT ServiceProviderId, Name, Email, PhoneNumber, Password
                         FROM ServiceProviders
                         WHERE Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ServiceProvider serviceProvider = new ServiceProvider(
                                reader["Name"].ToString(),
                                "",
                                reader["Email"].ToString(),
                                reader["Password"].ToString(),
                                reader["PhoneNumber"].ToString());

                            return serviceProvider;
                        }
                    }
                }
            }

            return null;
        }

        public Administrator LoginAdministrator(string email, string password)
        {
            DatabaseConnection database = new DatabaseConnection();

            using (SqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string query = @"SELECT AdministratorId, Name, Email, PhoneNumber, Password
                         FROM Administrators
                         WHERE Email = @Email AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Administrator administrator = new Administrator(
                                reader["Name"].ToString(),
                                "",
                                reader["Email"].ToString(),
                                reader["PhoneNumber"].ToString(),
                                reader["Password"].ToString());

                            return administrator;
                        }
                    }
                }
            }

            return null;
        }

        public bool UpdateCustomerPassword(string email, string newPassword)
        {
            DatabaseConnection database = new DatabaseConnection();

            using (SqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE Customers
                         SET Password = @Password
                         WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateServiceProviderPassword(string email, string newPassword)
        {
            DatabaseConnection database = new DatabaseConnection();

            using (SqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE ServiceProviders
                         SET Password = @Password
                         WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateAdministratorPassword(string email, string newPassword)
        {
            DatabaseConnection database = new DatabaseConnection();

            using (SqlConnection connection = database.GetConnection())
            {
                connection.Open();

                string query = @"UPDATE Administrators
                         SET Password = @Password
                         WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

    }



}
