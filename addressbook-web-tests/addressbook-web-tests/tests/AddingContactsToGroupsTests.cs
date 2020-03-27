using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests 
{
    class AddingContactsToGroupsTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest() 
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactDataComparer comparer = new ContactDataComparer();
            ContactData contact = ContactData.GetAll().Except(oldList, comparer).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
            System.Console.Out.WriteLine(group.Name + " " + contact);
        }
    }
}
