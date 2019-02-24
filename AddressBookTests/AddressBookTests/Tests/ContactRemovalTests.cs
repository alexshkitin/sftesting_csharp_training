using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.ContactsHelper.Remove(2);
        }
    }
}
