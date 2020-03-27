using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupUI_DB()
        {
            if (PERFOM_LONG_UI_CHECK)
            {
                List<GroupData> fromIU = app.Groups.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAll();
                fromDB.Sort();
                fromIU.Sort();
                Assert.AreEqual(fromDB, fromIU);
            }
        }
    }
}
