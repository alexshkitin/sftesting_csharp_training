using System;
using System.Text;
using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace AddressBookTests
{
    public class ContactsHelper : HelperBase
    {
        public ContactsHelper(ApplicationManager manager):base(manager)
        { }

        public ContactsHelper Create(ContactData contact)
        {
            InitAddNewContact();
            FillContactForm(contact);
            SubmitContact();
            return this;
        }

        public ContactsHelper Modify(ContactData contactData)
        {
            InitModification();
            FillContactForm(contactData);
            SubmitModification();
            return this;
        }

        public ContactsHelper Remove(int contactId)
        {
            Select(contactId);
            DeleteContact();
            return this;
        }

        public ContactsHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactsHelper Select(int contactId)
        {
            driver.FindElement(By.Id(contactId.ToString())).Click();
            return this;
        }

        public ContactsHelper SubmitModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactsHelper InitModification()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
            return this;
        }

        public ContactsHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactsHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FistName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }

        public ContactsHelper InitAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

    }
}
