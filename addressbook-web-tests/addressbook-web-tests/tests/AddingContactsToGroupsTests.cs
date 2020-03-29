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
            if (GroupData.GetAll().Count==0)
            {
                app.Groups.Create(new GroupData("NewGroupName", "NewGroupHeader", "NewGroupFooter"));
            }

            if (ContactData.GetAll().Count == 0)
            {
                app.Contacts.Create(new ContactData("NewUserName", "NewUserLastName", "NewUserNickName"));
            }

            GroupData group = new GroupData();

            foreach (GroupData g in GroupData.GetAll())
            {
                if (g.GetContacts().Count < ContactData.GetAll().Count)
                {
                    group = g;
                    break;
                }
            }

            if (group.Id==null)
            {
                app.Contacts.Create(new ContactData("NewUserName", "NewUserLastName", "NewUserNickName"));
                group = GroupData.GetAll()[0];
            }

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
