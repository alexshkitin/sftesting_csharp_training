using System;
using OpenQA.Selenium;


namespace AddressBookTests
{
    public class GroupsHelper : HelperBase
    {
        public GroupsHelper(ApplicationManager manager) : base(manager)
        { }

        public GroupsHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupsHelper Modify(int groupId, GroupData groupData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(groupId);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupsHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupsHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupsHelper Remove(int groupId)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(groupId);
            RemoveSelectedGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupsHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupsHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupsHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupsHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupsHelper RemoveSelectedGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        public GroupsHelper SelectGroup(int index)
        {
            try
            {
                driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            }
            catch(NoSuchElementException)
            {
                Create(new GroupData("test group"));
                manager.Navigator.GoToGroupsPage();
            }
            return this;
        }
    }
}
