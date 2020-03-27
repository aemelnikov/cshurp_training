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
            GroupData group = new GroupData();
            foreach (GroupData g in GroupData.GetAll())
            {
                if (g.GetContacts().Count > 0)
                {
                    group = g;
                    break;
                }
            }

            Assert.IsTrue(group.Id != null, "All groups are empty");

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
