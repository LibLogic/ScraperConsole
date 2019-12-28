using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace ScraperConsole
{
    class Program
    {
        static void Main()
        {
            var scrapeData = Scraper.GetScrape();

            DBActions.WriteTable(scrapeData, "Scrapes");
        }
    }
}