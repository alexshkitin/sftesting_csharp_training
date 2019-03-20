using NUnit.Framework;
using System.Collections.Generic;


namespace AddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(20))
                {
                    LastName = GenerateRandomString(20),
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {

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
