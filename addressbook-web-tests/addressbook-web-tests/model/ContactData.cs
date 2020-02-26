using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }
        public ContactData(string firstname, string lastname, string nickname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.NickName = nickname;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public bool Equals(ContactData other)
        {
            if(object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName) && (LastName == other.LastName);
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int result = LastName.CompareTo(other.LastName);
            if (result == 0)
            {
                result = FirstName.CompareTo(other.FirstName);
            }
            return result;
        }

        public override string ToString()
        {
            return LastName.ToString()+" "+FirstName.ToString();
        }

    }
}
