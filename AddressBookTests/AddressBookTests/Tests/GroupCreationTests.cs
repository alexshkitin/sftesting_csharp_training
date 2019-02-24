using System;
using System.Text;
using NUnit.Framework;
using NUnit;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.GroupsHelper.InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "bbbn";
            group.Footer = "ccc";
            app.GroupsHelper.FillGroupForm(group);
            app.GroupsHelper.SubmitGroupCreation();
            app.GroupsHelper.ReturnToGroupsPage();
        }
    }
}
