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
        public ContactsHelper(IWebDriver driver):base(driver)
        { }

        public void SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        public void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FistName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }

        public void InitAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
