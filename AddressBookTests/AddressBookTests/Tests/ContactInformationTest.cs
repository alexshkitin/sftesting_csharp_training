using NUnit.Framework;
using System.Collections.Generic;

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

            Assert.AreEqual(contactFromForm, contactFromForm);
            Assert.AreEqual(contactFromTable.Address, contactFromForm.Address);
            Assert.AreEqual(contactFromForm.AllPhones, contactFromTable.AllPhones);

        }

    }
}
