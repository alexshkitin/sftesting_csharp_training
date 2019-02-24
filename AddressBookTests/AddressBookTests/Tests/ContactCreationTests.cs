using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("test naame");
            contact.LastName = "test laast naame";

            app.ContactsHelper.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.LastName = "";

            app.ContactsHelper.Create(contact);
        }


    }
}
