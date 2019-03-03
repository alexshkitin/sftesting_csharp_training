using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

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
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupsHelper = new GroupsHelper(this);
            contsctsHelper = new ContactsHelper(this);
        }

         ~ApplicationManager()
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

        public IWebDriver Driver
        {
            get
            {
                return driver;
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

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
