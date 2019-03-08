using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.ContactsHelper.IsAnyContactCreated())
            {
                ContactData contact = new ContactData("FirstName");
                app.ContactsHelper.Create(contact);
            }

            ContactData newContactData = new ContactData("New Naame");
            newContactData.LastName = "new laast naame";

            app.ContactsHelper
                .Modify(1, newContactData);

        }
    }
}
