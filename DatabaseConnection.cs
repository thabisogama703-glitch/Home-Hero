using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace HomeHero_2
{
    public class DatabaseConnection
    {
        private string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HomeHeroDB;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
        
        
    
}
