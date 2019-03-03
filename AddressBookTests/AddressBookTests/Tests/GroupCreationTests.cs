using NUnit.Framework;

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

            app.GroupsHelper.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = null;
            group.Footer = null;

            app.GroupsHelper.Create(group);
        }
    }
}
