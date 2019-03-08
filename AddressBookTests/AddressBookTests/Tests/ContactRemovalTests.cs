using NUnit.Framework;
using System.Collections.Generic;


namespace AddressBookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.ContactsHelper.CreateContactIfNotExisted();
            List<ContactData> oldContacts = app.ContactsHelper.GetContactList();

            app.ContactsHelper.Remove(0);

            oldContacts.RemoveAt(0);
            List<ContactData> newContacts = app.ContactsHelper.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
