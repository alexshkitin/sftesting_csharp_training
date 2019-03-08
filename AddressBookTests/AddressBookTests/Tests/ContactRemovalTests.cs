using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.ContactsHelper.IsAnyContactCreated())
            {
                ContactData contact = new ContactData("FirstName");
                app.ContactsHelper.Create(contact);
            }

            app.ContactsHelper.Remove(1);
        }
    }
}
