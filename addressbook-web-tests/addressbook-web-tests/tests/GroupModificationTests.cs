using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modified test group");
            newData.Header = "modified test header";
            newData.Footer = "modified test footer";

            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(new GroupData("NewGroupName", "NewGroupHeader", "NewGroupFooter"));
            }

            app.Groups.Modify(0, newData);
        }
    }
}
