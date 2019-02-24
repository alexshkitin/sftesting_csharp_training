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
    }
}