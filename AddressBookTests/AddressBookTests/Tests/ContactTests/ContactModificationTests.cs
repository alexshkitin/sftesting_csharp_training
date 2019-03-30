using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookTests
{
    [TestFixture]
    class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.ContactsHelper.CreateContactIfNotExisted();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData newContactData = new ContactData("NewNaame", "NewLast", oldContacts[0].Id);

            app.ContactsHelper.Modify(newContactData);

            oldContacts[0] = newContactData;
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
