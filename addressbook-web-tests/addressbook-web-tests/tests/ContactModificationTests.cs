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
            ContactData newData = new ContactData("TestFirstName", "TestLastName");
            newData.NickName = "TestNickname";
            app.Contacts.Modify(1, newData);
        }
    }
}
