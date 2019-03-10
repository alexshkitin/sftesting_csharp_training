using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace AddressBookTests
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(ApplicationManager manager):base(manager)
        { }

        private List<ContactData> contactCache = null;

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

            int actualRowId = rowId + 2;
            Select(actualRowId);
            InitModification(actualRowId);
            FillContactForm(contactData);
            SubmitModification();
            return this;
        }

        public ContactsHelper Remove(int rowId)
        {
            manager.Navigator.GoToHomePage();

            int actualRowId = rowId + 2;
            Select(actualRowId);
            DeleteContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactsHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactsHelper Select(int rowId)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["
                + rowId + "]/td/input")).Click();
            return this;
        }

        public bool IsAnyContactCreated()
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']" +
                "/tbody/tr[2]/td/input"));
        }

        public ContactsHelper SubmitModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public ContactsHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactsHelper InitAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactsHelper CreateContactIfNotExisted()
        {
            if (!IsAnyContactCreated())
            {
                ContactData contact = new ContactData("FirstName");
                Create(contact);
            }
            return this;
        }


        public List<ContactData> GetContactList()
        {
            if (contactCache==null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

                foreach (IWebElement element in elements)
                {
                    ContactData contact = new ContactData(element.FindElements(By.TagName("td"))[2].Text)
                    {
                        LastName = element.FindElements(By.TagName("td"))[1].Text
                    };
                    contactCache.Add(contact);
                }
            }
            return new List<ContactData>(contactCache); ;
        }
    }
}
