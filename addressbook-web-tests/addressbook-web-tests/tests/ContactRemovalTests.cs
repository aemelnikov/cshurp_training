using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(new ContactData("NewUserName", "NewUserLastName", "NewUserNickName"));
            }
            app.Contacts.Remove(0);
        }
    }
}
