using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class ContactInformationTest : ContactTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData contactFromTable = app.ContactsHelper.GetContactInformationFromTable(0);
            ContactData contactFromEditForm = app.ContactsHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(contactFromTable, contactFromEditForm);
            Assert.AreEqual(contactFromTable.Address, contactFromEditForm.Address);
            Assert.AreEqual(contactFromTable.AllPhones, contactFromEditForm.AllPhones);
            Assert.AreEqual(contactFromTable.AllEmails, contactFromEditForm.AllEmails);
        }

    }
}
