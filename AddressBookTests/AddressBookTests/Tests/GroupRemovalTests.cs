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

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupsList();

            app.GroupsHelper.Remove(0);

            List<GroupData> newGroups = app.GroupsHelper.GetGroupsList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
