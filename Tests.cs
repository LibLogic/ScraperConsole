using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebScraperNet
{
    public class Tests
    {
        [SetUp]
        public void BrowserLogin()
        {
            Program.driver.Navigate().GoToUrl(Settings.loginPage);
            Program.driver.FindElement(By.Id("login-username")).SendKeys(Settings.loginName + Keys.Enter);

            Program._wait.Until(d => d.FindElement(By.Id("login-passwd")));
            Program.driver.FindElement(By.Id("login-passwd")).SendKeys(Settings.loginPass + Keys.Enter);

            Program.driver.Navigate().GoToUrl(Settings.portfolioPage);
            Program._wait.Until(d => d.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table")));
        }

        [Test]
        public void ScrapeData()
        {
            IWebElement element;
            List<string> innerText = new List<string>();
            string xPath;
                       
            for (int i = 1; i <= 9; i++)
            {
                xPath = $"//*[@id='pf-detail-table']/div[1]/table/thead/tr/th[{i}]";

                element = Program.driver.FindElement(By.XPath(xPath));
                innerText.Add(element.Text);
            }

            for (int i = 1; i <= 10; i++)
            {
                xPath = $"//*[@id='pf-detail-table']/div[1]/table/tbody/tr[{i}]/td[1]/a";

                element = Program.driver.FindElement(By.XPath(xPath));
                innerText.Add(element.Text);

                for (int j = 2; j <= 9; j++)
                {
                    xPath = $"//*[@id='pf-detail-table']/div[1]/table/tbody/tr[{i}]/td[{j}]";

                    element = Program.driver.FindElement(By.XPath(xPath));
                    innerText.Add(element.Text);
                }
            }
            System.IO.File.WriteAllLines(@"C:\Users\Tom\Desktop\Development\CapstoneProject\WebScraperNet\tableData.txt", innerText);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Program.driver.Quit();
        }
    }
}