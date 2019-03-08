using System.Threading;
using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class LoginTests:TestBase
    {

        [Test]
        public void LoginWithValidCreds()
        {
            //prepare
            AccountData account = new AccountData("admin", "secret");

            //action
            app.Auth.Logout();
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCreds()
        {
            //prepare
            AccountData account = new AccountData("admin", "123");

            //action
            app.Auth.Logout();
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }

    }
}
