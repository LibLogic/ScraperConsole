using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebScraperNet
{
    class GetActions
    {
        public static List<string> ScrapeData()
        {
            IWebElement element;
            List<string> innerText = new List<string>();
            string xPath;

            Program._wait.Until(d => d.FindElement(By.XPath("//*[@id='pf-detail-table']/div[1]/table")));

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

                for (int j = 2; j <= 13; j++)
                {
                    if (j == 10 || j == 11 || j == 12)
                    {
                        innerText.Add("-");
                    } else
                    {
                        xPath = $"//*[@id='pf-detail-table']/div[1]/table/tbody/tr[{i}]/td[{j}]";

                        element = Program.driver.FindElement(By.XPath(xPath));
                        innerText.Add(element.Text);
                    }
                }
            }
 //           Console.WriteLine(innerText);
            return innerText;
           // System.IO.File.WriteAllLines(@"C:\Users\Tom\Desktop\Development\CapstoneProject\WebScraperNet\tableData.txt", innerText);

           // driver.Quit();
        }
    }
}