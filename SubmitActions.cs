using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebScraperNet
{
    class SubmitActions
    {
        public static void SubmitText(IWebDriver driver, string elementType, string element, string value)
        {
            if (elementType == "Id") 
                driver.FindElement(By.Id(element)).SendKeys(value + Keys.Enter);
            
            if (elementType == "Name")
                driver.FindElement(By.Name(element)).SendKeys(value + Keys.Enter);
        }

        public static void SelectDropDown(IWebDriver driver, string elementType, string element, string value)
        {
            if (elementType == "Id")
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);

            if (elementType == "Name")
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
        }
    }
}
