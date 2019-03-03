using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.ContactsHelper.Remove(1);
        }
    }
}
