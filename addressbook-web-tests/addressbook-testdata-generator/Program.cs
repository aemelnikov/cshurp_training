using System;
using System.IO;
using addressbook_web_tests;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_testdata_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            string fileName = args[2];
            string format = args[3];



            StreamWriter writer = new StreamWriter(fileName);
           

            if (format == "xml")
            {
                if (dataType== "groups")
                {
                    WriteGroupsToXmlFile(GroupsGenerator(count), writer);
                } 
                else if (dataType == "contacts")
                {
                    WriteContactsToXmlFile(ContactsGenerator(count), writer);
                }
                else
                {
                    System.Console.Out.WriteLine("Unrecognized data type " + dataType);
                }

            } 
            else if(format == "json")
            {
                if (dataType == "groups")
                {
                    WriteGroupsToJsonFile(GroupsGenerator(count), writer);
                }
                else if (dataType == "contacts")
                {
                    WriteContactsToJsonFile(ContactsGenerator(count), writer);
                }
                else
                {
                    System.Console.Out.WriteLine("Unrecognized data type " + dataType);
                }

            }
            else
            {
                System.Console.Out.WriteLine("Unrecognized format " + format);
            }
            
            writer.Close();
        }

        static List<GroupData> GroupsGenerator(int count)
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = TestBase.GenerateRandomString(10),
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            return groups;
        }
        static List<ContactData> ContactsGenerator(int count)
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData()
                {
                    FirstName = TestBase.GenerateRandomString(10),
                    LastName = TestBase.GenerateRandomString(10),
                    MiddleName = TestBase.GenerateRandomString(10)
                });
            }

            return contacts;
        }


        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
