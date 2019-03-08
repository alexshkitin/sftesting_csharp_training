using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.GroupsHelper.IsAnyGroupCreated())
            {
                GroupData group = new GroupData("TestName");
                app.GroupsHelper.Create(group);
            }

            app.GroupsHelper.Remove(1);
        }
    }
}
