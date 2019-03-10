using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.GroupsHelper.CreateGroupIfNotExsisted();

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupList();
            GroupData oldGroup = oldGroups[0];

            GroupData newGroupData= new GroupData("New name");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            app.GroupsHelper
                .Modify(0, newGroupData);

            List<GroupData> newGroups = app.GroupsHelper.GetGroupList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if(group.Id == oldGroup.Id)
                {
                    Assert.AreEqual(oldGroup.Name, group.Name);
                }
            }
        }
    }
}
