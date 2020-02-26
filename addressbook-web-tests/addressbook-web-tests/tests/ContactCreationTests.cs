﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace addressbook_web_tests 
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
      

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("TestFirstName", "TestLastName");
            contact.NickName = "TestNickname";
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);



        }


    }
}
