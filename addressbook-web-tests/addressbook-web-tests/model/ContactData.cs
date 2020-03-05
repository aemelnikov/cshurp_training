using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

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
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string SecondaryHomePhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return EmailCleanUp(Email) + EmailCleanUp(Email2) + EmailCleanUp(Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllPhones 
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return PhoneCleanUp(HomePhone) + PhoneCleanUp(MobilePhone) + PhoneCleanUp(WorkPhone)+ PhoneCleanUp(SecondaryHomePhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string PhoneCleanUp(string phone)
        {
           if (phone == null|| phone=="")
            {
                return "";
            }
            return Regex.Replace(phone, @"[- ()]", "") + "\r\n";
        }

        private string EmailCleanUp(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Trim() + "\r\n";
        }

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
