using NUnit.Framework;
using System.Collections.Generic;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5 ;i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(103),
                    Footer = GenerateRandomString(103)

                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
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
