using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5 ;i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(103),
                    Footer = GenerateRandomString(103)

                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCSVFIle()
        {
            List<GroupData> groups = new List<GroupData>();
            string workDirectoty = TestContext.CurrentContext.WorkDirectory;
            string[] lines = File.ReadAllLines(workDirectoty + @"\groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXMLFile()
        {
            string workDirectoty = TestContext.CurrentContext.WorkDirectory;
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(workDirectoty+@"\groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJSONFile()
        {
            string workDirectoty = TestContext.CurrentContext.WorkDirectory;
            return JsonConvert.DeserializeObject<List<GroupData>>
                (File.ReadAllText(workDirectoty + @"\groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJSONFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.GroupsHelper.GetGroupList();

            app.GroupsHelper.Create(group);
            oldGroups.Add(group);
            List<GroupData> newGroups = app.GroupsHelper.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = null;
            group.Footer = null;

            List<GroupData> oldGroups = app.GroupsHelper.GetGroupList();

            app.GroupsHelper.Create(group);

            oldGroups.Add(group);
            List<GroupData> newGroups = app.GroupsHelper.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
