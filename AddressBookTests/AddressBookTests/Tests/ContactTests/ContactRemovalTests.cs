using NUnit.Framework;
using System.Collections.Generic;


namespace AddressBookTests
{
    [TestFixture]
    class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.ContactsHelper.CreateContactIfNotExisted();
            List<ContactData> oldContacts = ContactData.GetAll();

            app.ContactsHelper.Remove(oldContacts[0]);
            oldContacts.RemoveAt(0);

            System.Threading.Thread.Sleep(300);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(newContacts, oldContacts);
        }
    }
}
