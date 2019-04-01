using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookTests
{
    public class AddContsctsToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.ContactsHelper.AddContactToGroup(contact, group);
            oldList.Add(contact);
            List<ContactData> newList = group.GetContacts();
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(newList, oldList);
        }
    }
}
