using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraperNet
{
    class DBActions
    {
        public class DisplayTable
        {
            public static void ToConsole(string table)
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {table}", conn);
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}",
                                            reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7],
                                            reader[8], reader[9], reader[10], reader[11], reader[12], reader[13], reader[14]);
                    }
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=WINDOWS-10; Initial Catalog=WebScraper; Integrated Security=SSPI");
            return conn;
        }

        public static void WriteTable(List<string> scrapeData, string table)
        {

            string CSVFile = FileActions.WriteCSVFile(scrapeData);

            DataTable dt = new DataTable();
            string line = null;
            int i = 0;

            using (StreamReader stream = File.OpenText(CSVFile))
            {
                while ((line = stream.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (data.Length > 0)
                    {
                        if (i == 0)
                        {
                            foreach (var item in data)
                            {
                                dt.Columns.Add(new DataColumn());
                            }
                            i++;
                        }
                        else
                        {
                            DataRow row = dt.NewRow();
                            row.ItemArray = data;
                            dt.Rows.Add(row);
                        }
                    }
                }
            }

            SqlConnection conn = GetConnection();
            conn.Open();

            using (SqlBulkCopy copy = new SqlBulkCopy(conn))
            {
                copy.DestinationTableName = table;
                copy.WriteToServer(dt);
            }
            conn.Close();
        }
    }
}