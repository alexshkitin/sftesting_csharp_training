using NUnit.Framework;
using System.Collections.Generic;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbbn";
            group.Footer = "ccc";

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupList();

            app.GroupsHelper.Create(group);
            oldGroups.Add(group);
            List<GroupData> newGroups = app.GroupsHelper.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = null;
            group.Footer = null;

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupList();

            app.GroupsHelper.Create(group);

            oldGroups.Add(group);
            List<GroupData> newGroups = app.GroupsHelper.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = null;
            group.Footer = null;

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupList();

            app.GroupsHelper.Create(group);

            oldGroups.Add(group);
            List<GroupData> newGroups = app.GroupsHelper.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
