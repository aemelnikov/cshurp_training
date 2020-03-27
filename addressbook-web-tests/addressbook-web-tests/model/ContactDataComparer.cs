using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactDataComparer : IEqualityComparer<ContactData>
    {
        public bool Equals(ContactData contact1, ContactData contact2)
        {
            if (object.ReferenceEquals(contact1, contact2))
            {
                return true;
            }
            return (contact1.FirstName == contact2.FirstName) && (contact1.LastName == contact2.LastName)&&(contact1.Id == contact2.Id);
        }

        public int GetHashCode(ContactData contact)
        {
            return contact.FirstName.Length;
        }
    }
}
