using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace AddressBookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupsHelper groupsHelper;
        protected ContactsHelper contsctsHelper;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupsHelper = new GroupsHelper(this);
            contsctsHelper = new ContactsHelper(this);
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

        public LoginHelper Auth
        {
            get
            {
                return this.loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return this.navigator;
            }
        }

        public GroupsHelper GroupsHelper
        {
            get
            {
                return this.groupsHelper;
            }
        }

        public ContactsHelper ContactsHelper
        {
            get
            {
                return this.contsctsHelper;
            }
        }


    }
}
