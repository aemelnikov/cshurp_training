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

            app.Contacts.Modify(1, newData);
        }
    }
}
