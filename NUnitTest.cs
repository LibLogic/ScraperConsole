using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraperNet
{
    class NUnitTest
    {
        
        [SetUp]
        public void startBrowser()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(Settings.loginPage);
            Console.WriteLine("Web Page Was Opened");
        }

        [Test]
        public void test()
        {
            driver.FindElement(By.Id("login-username")).SendKeys(Settings.loginName + Keys.Enter);
            //    driver.Url = "https://finance.yahoo.com/";
            //   driver.Url = "https://login.yahoo.com/config/login?.src=fpctx&.intl=us&.lang=en-US&.done=https://www.yahoo.com";
            Console.WriteLine("User Name Was Entered");
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
            Console.WriteLine("Browser Was Closed");
        }
    }
}
