using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraperNet
{
    class DBConnection
    {
        public static string connectionString = @"Data Source=WINDOWS-10; Initial Catalog=WebScraper; Integrated Security=SSPI";
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}