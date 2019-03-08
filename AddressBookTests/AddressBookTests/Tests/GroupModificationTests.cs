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

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupsList();

            GroupData newGroupData= new GroupData("New name");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            app.GroupsHelper
                .Modify(0, newGroupData);

            List<GroupData> newGroups = app.GroupsHelper.GetGroupsList();
            oldGroups[0].Name = newGroupData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
