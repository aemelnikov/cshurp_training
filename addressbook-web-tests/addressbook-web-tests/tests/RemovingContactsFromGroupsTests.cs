using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    class RemovingContactsFromGroupsTests : AuthTestBase
    {

        [Test]
        public void RemovingContactFromGroupTest()
        {

            if (GroupData.GetAll().Count == 0)
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
                if (g.GetContacts().Count > 0)
                {
                    group = g;
                    break;
                }
            }

           if (group.Id == null)
            {
                app.Contacts.AddContactToGroup(ContactData.GetAll()[0], GroupData.GetAll()[0]);
                group = GroupData.GetAll()[0];
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
            System.Console.Out.WriteLine(group.Name + " " + contact);
        }
    }
}
