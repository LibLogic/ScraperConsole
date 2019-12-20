using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebScraperNet
{
    class Program
    {
        public static IWebDriver driver = new ChromeDriver();
        
        public static readonly WebDriverWait _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));

        static void Main()
        {
            driver.Navigate().GoToUrl(Settings.loginPage);
            SubmitActions.SubmitText(driver, "Id", Settings.loginNameField, Settings.loginName);

            _wait.Until(d => d.FindElement(By.Id(Settings.loginPassField)));
            SubmitActions.SubmitText(driver, "Id", Settings.loginPassField, Settings.loginPass);

            Program.driver.Navigate().GoToUrl(Settings.portfolioPage);

            var innerText = GetActions.ScrapeData();
            WriteFile.WriteToFile(innerText);
            driver.Quit();
        }
    }
}