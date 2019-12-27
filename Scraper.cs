using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace ScraperConsole
{
    class Scraper
    {
        public static List<string> GetScrape(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));

            driver.Navigate().GoToUrl(Settings.Yahoo.loginPage);
            //LoginAction.Login(driver);
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
