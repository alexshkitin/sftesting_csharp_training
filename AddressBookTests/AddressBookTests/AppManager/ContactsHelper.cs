using OpenQA.Selenium;

namespace AddressBookTests
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(ApplicationManager manager):base(manager)
        { }

        public ContactsHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitAddNewContact();
            FillContactForm(contact);
            SubmitContact();
            return this;
        }

        public ContactsHelper Modify(int rowId, ContactData contactData)
        {
            manager.Navigator.GoToHomePage();

            int actualRowId = rowId + 1;
            Select(actualRowId);
            InitModification(actualRowId);
            FillContactForm(contactData);
            SubmitModification();
            return this;
        }

        public ContactsHelper Remove(int rowId)
        {
            manager.Navigator.GoToHomePage();
            int actualRowId = rowId + 1;

            Select(actualRowId);
            DeleteContact();
            return this;
        }

        public ContactsHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactsHelper Select(int rowId)
        {
            try
            {
                driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["
                    + rowId + "]/td/input")).Click();
            }
            catch(NoSuchElementException)
            {
                Create(new ContactData("test contact"));
                manager.Navigator.GoToHomePage();
            }
            return this;
        }

        public ContactsHelper SubmitModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactsHelper InitModification(int rowId)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["
                +rowId+"]/td[8]/a/img")).Click();
            return this;
        }

        public ContactsHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactsHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FistName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactsHelper InitAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

    }
}
