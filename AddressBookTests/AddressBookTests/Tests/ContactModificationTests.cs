using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.ContactsHelper.CreateContactIfNotExisted();

            ContactData newContactData = new ContactData("New Naame");
            newContactData.LastName = "new laast naame";

            List<ContactData> oldContacts = app.ContactsHelper.GetContactList();
            
            app.ContactsHelper
                .Modify(0, newContactData);

            oldContacts[0] = newContactData;
            List<ContactData> newContacts = app.ContactsHelper.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }
    }
}
