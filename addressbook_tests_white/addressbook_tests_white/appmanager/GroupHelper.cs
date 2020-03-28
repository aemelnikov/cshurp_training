using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Remove(GroupData group)
        {
            Window dialogue = OpenGroupsDialogue();
            SelectGroup(group, dialogue);
            Window deleteDialogue=OpenDeleteGroupDialogue(dialogue);
            deleteDialogue.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialogue(dialogue);
        }

        private void SelectGroup(GroupData group, Window dialogue)
        {
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                if (group.Name == item.Text) 
                {
                    item.Click(); 
                    break; 
                }
            }
        }

        public static string GROUPWINTITLE = "Group editor";

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree=dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData() { Name = item.Text });
            }
            CloseGroupsDialogue(dialogue);

            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox= (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        public void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }
        public Window OpenDeleteGroupDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            return dialogue.ModalWindow("Delete group");
        }
    }
}