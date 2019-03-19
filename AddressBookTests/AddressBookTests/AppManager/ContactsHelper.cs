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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;

            string phones = cells[5].Text;

            string emails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = phones,
                AllEmails = emails
            };
        }

        public string GetContactInformationFromDetailes(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenDetailes(index);
            string contactInfo = driver.FindElement(By.Id("content")).Text;
            string result = contactInfo.Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("-","")
                .Replace("W:", "").Replace("H:", "").Replace("M:", "");
            return result;

        }

        public void OpenDetailes(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[6]
                  .FindElement(By.TagName("a")).Click();
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }

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

            Select(rowId);
            InitModification(rowId);
            FillContactForm(contactData);
            SubmitModification();
            return this;
        }

        public ContactsHelper Remove(int rowId)
        {
            manager.Navigator.GoToHomePage();

            Select(rowId);
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
            driver.FindElements(By.Name("entry"))[rowId]
                   .FindElements(By.TagName("td"))[0]
                   .FindElement(By.Name("selected[]")).Click();
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
            driver.FindElements(By.Name("entry"))[rowId]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
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
