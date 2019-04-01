using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookTests
{
    public class RemoveContactFromGroup : AuthTestBase
    {
        [Test]
        public void RemoveContactFromGroupTest()
        {
            if (GroupData.GetGroupsWithContacts().Count == 0)
            {
                ContactData contact = ContactData.GetAll().First();
                List<GroupData> allGroups = GroupData.GetAll();
                app.ContactsHelper.AddContactToGroup(contact, allGroups[0]);
            }

            GroupData group = GroupData.GetGroupsWithContacts().First();
            List<ContactData> oldContactList = group.GetContacts();
            ContactData contactToRemove = oldContactList.First();

            app.ContactsHelper.RemoveContactFromGroup(contactToRemove, group);
            oldContactList.Remove(contactToRemove);
            List<ContactData> newContactList = group.GetContacts();
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
        }
    }
}
