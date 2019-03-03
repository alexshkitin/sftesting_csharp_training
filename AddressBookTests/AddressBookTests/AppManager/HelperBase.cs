using OpenQA.Selenium;

namespace AddressBookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            driver = manager.Driver;
            this.manager = manager;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
    }
}