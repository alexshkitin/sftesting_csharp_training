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
            if (GroupData.GetAll().Count == 0)
            {
                GroupData newGroup = new GroupData("Test group");
                app.GroupsHelper.Create(newGroup);
            }

            if (ContactData.GetAll().Count == 0)
            {
                ContactData newContact = new ContactData("Test fName", "Test lName");
                app.ContactsHelper.Create(newContact);
            }

            GroupData group = GroupData.GetAll().First();

            //нам не повезло - все контакты уже есть в выбранной группе
            //в этом случае создадим новый контакт
            if (ContactData.GetAll().Except(group.GetContacts()).Count()==0)
            {
                ContactData newContact = new ContactData("Test fName", "Test lName");
                app.ContactsHelper.Create(newContact);
            }

            List<ContactData> oldList = group.GetContacts();

            //получим все контакты, которых нет в выбранной группе. Сейчас они точно есть.
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
