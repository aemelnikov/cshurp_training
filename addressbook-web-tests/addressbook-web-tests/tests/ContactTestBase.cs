using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactUI_DB()
        {
            if (PERFOM_LONG_UI_CHECK)
            {
                List<ContactData> fromIU = app.Contacts.GetContactList();
                List<ContactData> fromDB = ContactData.GetAll();
                fromDB.Sort();
                fromIU.Sort();
                Assert.AreEqual(fromDB, fromIU);
            }
        }
    }
}
