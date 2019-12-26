using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraperNet
{
    class Program
    {
        readonly static IWebDriver driver = new ChromeDriver();

        static void Main()
        {
            var scrapeData = Scraper.GetScrape(driver);
            driver.Quit();

            DBActions.WriteTable(scrapeData, "Scrapes");
        }
    }
}