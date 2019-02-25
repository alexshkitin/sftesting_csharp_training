using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("New Naame");
            newContactData.LastName = "new laast naame";

            app.ContactsHelper
                .Modify(2, newContactData);

        }

    }
}
