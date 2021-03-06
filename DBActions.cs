﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace ScraperConsole
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

        public static void WriteTables(List<string> scrapeData, string table, Settings.Yahoo.UserCredentials currentUser)
        {
            string scrapetime = "";
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
                            if (i == 1)
                            {
                                scrapetime = data[1];
                            }
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

            string name = currentUser.UserName;
            //write to Users_Scrapes table  need currentUser & ScapeTime
            string query = $"INSERT INTO Users_Scrapes (ScrapeId, UserName) VALUES (@ScrapeId, @UserName)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ScrapeId", SqlDbType.DateTime2, 7).Value = scrapetime;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 450).Value = name;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }


        }
    }
}


