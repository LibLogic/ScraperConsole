using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace ScraperConsole
{
    class Scraper
    {
        public static List<string> GetScrape()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            IWebDriver driver = new ChromeDriver(options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl(Settings.Yahoo.loginPage);

            Login(driver);

            driver.Navigate().GoToUrl(Settings.Yahoo.portfolioPage);

            return GetActions.ScrapeData(driver);
        }

        public static void Login(IWebDriver driver)
        {
            SubmitActions.SubmitText(driver, "Id", Settings.Yahoo.loginNameField, Settings.Yahoo.loginName);
            SubmitActions.SubmitText(driver, "Id", Settings.Yahoo.loginPassField, Settings.Yahoo.loginPass);
        }
    }
}
