using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {

            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(new GroupData("NewGroupName", "NewGroupHeader", "NewGroupFooter"));
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            
        }
    }
}
