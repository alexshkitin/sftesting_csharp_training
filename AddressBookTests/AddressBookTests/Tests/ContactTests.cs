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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            ContactData contact = new ContactData("test naame");
            contact.LastName = "test laast naame";
            app.ContactsHelper.InitAddNewContact();
            app.ContactsHelper.FillContactForm(contact);
            app.ContactsHelper.SubmitContact();
        }
    }
}
