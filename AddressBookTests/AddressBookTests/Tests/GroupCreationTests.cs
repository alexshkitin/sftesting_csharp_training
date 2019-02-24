using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
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
            group.Header = "";
            group.Footer = "";

            app.GroupsHelper.Create(group);
        }
    }
}
