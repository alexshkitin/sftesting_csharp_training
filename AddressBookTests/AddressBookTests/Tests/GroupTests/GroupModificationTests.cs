using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.GroupsHelper.CreateGroupIfNotExsisted();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0];
            toBeModified.Name = "New teestNaame";
            toBeModified.Footer = "New shining footer";
            toBeModified.Header = "New cool header";

            app.GroupsHelper.Modify(toBeModified);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0] = toBeModified;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if(group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(toBeModified.Name, group.Name);
                }
            }
        }
    }
}
