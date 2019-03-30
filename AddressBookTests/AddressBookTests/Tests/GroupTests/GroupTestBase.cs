using System.Collections.Generic;
using NUnit.Framework;
    
namespace AddressBookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void ComapreGroupsUiDb()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = app.GroupsHelper.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();

                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
