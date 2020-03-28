using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;

namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        public Window MainWindow { get; private set; }
        private GroupHelper groupHelper;
        public ApplicationManager() 
        {
            Application app = Application.Launch(@"c:\c_for_testers\AddressBook\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);

            groupHelper = new GroupHelper(this);

        }
         public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
