using System;
using System.Collections.Generic;
using OpenQA.Selenium;


namespace AddressBookTests
{
    public class GroupsHelper : HelperBase
    {
        private List<GroupData> groupCache = null;


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

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

                foreach (IWebElement element in elements)
                { 
                    groupCache.Add(new GroupData(null){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;

                for(int i = 0; i<groupCache.Count; i++)
                {
                    if (i<shift)
                    {
                        groupCache[i].Name = "";
                    }
                    else
                    {
                        groupCache[i].Name = parts[i-shift].Trim();
                    }
                    
                }
            }

            return new List<GroupData>(groupCache);
        }

        public GroupsHelper Modify(GroupData groupData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(groupData.Id);
            InitGroupModification();
            FillGroupForm(groupData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupsHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
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

        public GroupsHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
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
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        public GroupsHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }

        public GroupsHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public bool IsAnyGroupCreated()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[2]"));
        }

        public GroupsHelper CreateGroupIfNotExsisted()
        {
            if (!IsAnyGroupCreated())
            {
                GroupData group = new GroupData("TestName");
                Create(group);
            }
            return this;
        }
    }
}
