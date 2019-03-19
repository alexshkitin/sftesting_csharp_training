using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData contactFromTable = app.ContactsHelper.GetContactInformationFromTable(0);
            ContactData contactFromForm = app.ContactsHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(contactFromForm, contactFromTable);
            Assert.AreEqual(contactFromForm.Address, contactFromTable.Address);
            Assert.AreEqual(contactFromForm.AllPhones, contactFromTable.AllPhones);

        }

    }
}
