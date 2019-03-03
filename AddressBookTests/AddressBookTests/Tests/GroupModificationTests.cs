using NUnit.Framework;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData= new GroupData("New name");
            newGroupData.Header = null;
            newGroupData.Footer = null;

            app.GroupsHelper
                .Modify(1, newGroupData);
        }
    }
}
