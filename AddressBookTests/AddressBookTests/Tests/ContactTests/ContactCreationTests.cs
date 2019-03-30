using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace AddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(20))
                {
                    LastName = GenerateRandomString(20),
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            string workDirectoty = TestContext.CurrentContext.WorkDirectory;
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(workDirectoty + @"\contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            string workDirectoty = TestContext.CurrentContext.WorkDirectory;
            return JsonConvert.DeserializeObject<List<ContactData>>
                (File.ReadAllText(workDirectoty + @"\contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJSONFile")]
        public void ContactCreationTest(ContactData contact)
        {

            List<ContactData> oldContacts = ContactData.GetAll();

            app.ContactsHelper.Create(contact);
            oldContacts.Add(contact);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.LastName = "";

            List<ContactData> oldContacts = ContactData.GetAll();

            app.ContactsHelper.Create(contact);
            oldContacts.Add(contact);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
