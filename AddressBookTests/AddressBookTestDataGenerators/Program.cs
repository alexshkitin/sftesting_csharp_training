using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressBookTestDataGenerators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string outputFile = args[1];
            string format = args[2];
            string dataType = args[3];

            if (dataType == "groups")
            {
                GenerateGroupsData(count, format, outputFile);
            }
            else if (dataType == "contacts")
            {
                GenerateContactsData(count, format, outputFile);
            }
            else
            {
                System.Console.Out.Write("Unrecognized data format.");
            }
        }

        static void GenerateContactsData(int count, string format, string outputFile)
        {
            List<ContactData> contacts = new List<ContactData>();

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        LastName = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "csv")
                {
                    WriteContactsToCSV(contacts, writer);
                }
                else if (format == "xml")
                {
                    WriteContactsToXML(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJSON(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized file format.");
                }
            }
        }


        static void GenerateGroupsData(int count, string format, string outputFile)
        {
            List<GroupData> groups = new List<GroupData>();

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "csv")
                {
                    WriteGroupsToCSV(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXML(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJSON(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized file format.");
                }
            }
        }

        static void WriteGroupsToCSV(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("{0},{1},{2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteContactsToCSV(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("{0},{1}",
                    contact.FirstName, contact.LastName));
            }
        }

        static void WriteGroupsToXML(List<GroupData> groupsData, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groupsData);
        }

        static void WriteContactsToXML(List<ContactData> contactsData, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contactsData);
        }

        static void WriteGroupsToJSON(List<GroupData> groupsData, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groupsData, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToJSON(List<ContactData> contactsData, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contactsData, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
