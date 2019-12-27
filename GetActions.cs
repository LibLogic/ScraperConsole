using System;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace ScraperConsole
{
    class GetActions
    {
        public static List<string> ScrapeData(IWebDriver driver)
        {
            IWebElement element;
            List<string> innerText = new List<string>();
            string xPath;

            innerText.Add("id");
            innerText.Add("Scrape Time");
            for (int i = 1; i <= 13; i++)
            {
                if (i == 13)
                {
                    xPath = $"//*[@id='pf-detail-table']/div[1]/table/thead/tr/th[{i}]";
                    element = driver.FindElement(By.XPath(xPath));
                    innerText.Add(element.Text + "\n");

                }
                else
                {
                    xPath = $"//*[@id='pf-detail-table']/div[1]/table/thead/tr/th[{i}]";
                    element = driver.FindElement(By.XPath(xPath));
                    innerText.Add(element.Text);
                }
            }

            DateTime time = DateTime.Now;               ;

            for (int i = 1; i <= 10; i++)
            {
                innerText.Add(time.ToString());

                xPath = $"//*[@id='pf-detail-table']/div[1]/table/tbody/tr[{i}]/td[1]/a";
                element = driver.FindElement(By.XPath(xPath));

                innerText.Add(element.Text);


                for (int j = 2; j <= 13; j++)
                {
                    switch (j)
                    {
                        case 2:
                            xPath = $"//*[@id='pf-detail-table']/div[1]/table/tbody/tr[{i}]/td[{j}]";
                            element = driver.FindElement(By.XPath(xPath));
                            innerText.Add(element.Text.Replace(",", ""));
                            break;
                        case 10:
                        case 11:
                        case 12:
                            innerText.Add("-");
                            break;
                        case 13:
                            innerText.Add(element.Text + "\n");
                            break;
                        default:
                            xPath = $"//*[@id='pf-detail-table']/div[1]/table/tbody/tr[{i}]/td[{j}]";
                            element = driver.FindElement(By.XPath(xPath));
                            innerText.Add(element.Text.Replace(",", ""));
                            break;
                    }
                }
            }
            return innerText;
        }
    }
}