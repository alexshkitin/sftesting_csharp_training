using NUnit.Framework;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            if (!app.GroupsHelper.IsAnyGroupCreated())
            {
                GroupData group = new GroupData("TestName");
                app.GroupsHelper.Create(group);
            }

            GroupData newGroupData= new GroupData("New name");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            app.GroupsHelper
                .Modify(1, newGroupData);
        }
    }
}
