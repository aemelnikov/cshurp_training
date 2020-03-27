using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(new ContactData("NewUserName", "NewUserLastName", "NewUserNickName"));
            }

            List<ContactData> oldContacts= ContactData.GetAll();
            ContactData contactToRemove = oldContacts[0];
            app.Contacts.Remove(contactToRemove);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
