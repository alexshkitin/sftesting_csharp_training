using System.Collections.Generic;
using NUnit.Framework;

namespace AddressBookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void ComapreContactsUiDb()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> fromUI = app.ContactsHelper.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();

                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
