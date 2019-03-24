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
            ContactData contactFromEditForm = app.ContactsHelper.GetContactInformationFromEditForm(0);
            string contactFromDetailes = app.ContactsHelper.GetContactInformationFromDetailes(0);
            string contactFormFormAsString = contactFromEditForm.AsSingleString();
            Assert.AreEqual(contactFormFormAsString, contactFromDetailes);
        }

    }
}
