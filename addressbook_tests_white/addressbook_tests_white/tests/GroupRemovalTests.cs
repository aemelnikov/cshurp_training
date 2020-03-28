using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.GetGroupList().Count() < 2)
            {
                app.Groups.Add(new GroupData() { Name="testtest"});
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toRemove = oldGroups[0];

            app.Groups.Remove(toRemove);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
