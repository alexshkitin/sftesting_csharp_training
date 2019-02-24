using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupsHelper.Remove(1);
        }

    }
}
