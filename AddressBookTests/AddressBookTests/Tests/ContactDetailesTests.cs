using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookTests
{
    [TestFixture]
    public class ContactDetailedInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactDetailes()
        {
            ContactData contactFromTable = app.ContactsHelper.GetContactInformationFromTable(0);
            string contactFromDetailes = app.ContactsHelper.GetContactInformationFromDetailes(0);

            Assert.AreEqual(contactFromTable.AsSingleString(), contactFromDetailes);
        }

    }
}
