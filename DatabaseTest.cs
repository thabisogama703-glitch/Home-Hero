using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace HomeHero_2
{
    public class DatabaseTest
    {
        public static bool TestConnection()
        {
            DatabaseConnection database = new DatabaseConnection();

            try
            {
                using (SqlConnection connection = database.GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
