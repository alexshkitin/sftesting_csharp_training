using NUnit.Framework;
using System.Collections.Generic;


namespace AddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("test naame");
            contact.LastName = "test laast naame";

            List<ContactData> oldContacts = app.ContactsHelper.GetContactList();

            app.ContactsHelper.Create(contact);
            oldContacts.Add(contact);

            List<ContactData> newContacts = app.ContactsHelper.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.LastName = "";

            List<ContactData> oldContacts = app.ContactsHelper.GetContactList();

            app.ContactsHelper.Create(contact);
            oldContacts.Add(contact);

            List<ContactData> newContacts = app.ContactsHelper.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
