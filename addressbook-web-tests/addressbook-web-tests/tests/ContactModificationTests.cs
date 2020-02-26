using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    { 
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("ModifiedFirstName", "ModifiedLastName");
            newData.NickName = "ModifiedNickname";

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(new ContactData("NewUserName", "NewUserLastName", "NewUserNickName"));
            }


            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(0, newData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName= newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
