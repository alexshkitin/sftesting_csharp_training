using NUnit.Framework;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroupData= new GroupData("New name");
            newGroupData.Header = "tter";
            newGroupData.Footer = "qweasdzxc";

            app.GroupsHelper
                .Modify(1, newGroupData);
        }
    }
}
