using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupsHelper.CreateGroupIfNotExsisted();

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];

            app.GroupsHelper.Remove(0);

            List<GroupData> newGroups = app.GroupsHelper.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
