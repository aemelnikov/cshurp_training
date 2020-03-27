using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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



            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0];
            app.Groups.Modify(toBeModified, newData);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
