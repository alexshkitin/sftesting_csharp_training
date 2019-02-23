using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            ContactData contact = new ContactData("test naame");
            contact.LastName = "test laast naame";
            InitAddNewContact();
            FillContactForm(contact);
            SubmitContact();
        }
    }
}
