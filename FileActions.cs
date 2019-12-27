using System;
using System.IO;
using System.Collections.Generic;

namespace ScraperConsole
{
    class FileActions
    {
        public static string WriteCSVFile(List<string> innerText)
        {
            string CSV = string.Join(",", innerText);
            string path = @"C:\Users\Tom\Desktop\Development\CapstoneProject\WebScraperNet\lastScrape.csv";
            File.WriteAllText(path, CSV);
            return path;
        }
    }
}
