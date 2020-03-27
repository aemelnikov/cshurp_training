using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

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

        public ContactData()
        {
            this.Birthday = new ContactDateData();
            this.Anniversary = new ContactDateData();
        }

        [Column(Name = "id")]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string NickName { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string SecondaryHomePhone { get; set; }
        public string SecondaryAddress { get; set; }
        public string Notes { get; set; }
        public ContactDateData Birthday { get; set; }
        public ContactDateData Anniversary { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
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
                    return CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3).Trim();
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

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    string fullName = FirstName + " " + MiddleName + " " + LastName;
                    string mainData = CleanUp(fullName) + CleanUp(NickName) + CleanUp(Title) + CleanUp(Company) + CleanUp(Address);

                    string homePhoneString = String.IsNullOrEmpty(HomePhone) ? "" : @"H: " + HomePhone.Trim() + "\r\n";
                    string mobilePhoneString = String.IsNullOrEmpty(MobilePhone) ? "" : @"M: " + MobilePhone.Trim() + "\r\n";
                    string workPhoneString = String.IsNullOrEmpty(WorkPhone) ? "" : @"W: " + WorkPhone.Trim() + "\r\n";
                    string faxString = String.IsNullOrEmpty(Fax) ? "" : @"F: " + Fax.Trim() + "\r\n";
                    string phoneData = AddEmptyRow(homePhoneString + mobilePhoneString + workPhoneString + faxString);

                    string homepageString = String.IsNullOrEmpty(Homepage) ? "" : "Homepage:\r\n" + Homepage.Trim() + "\r\n";
                    string emailData = AddEmptyRow(CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3) + homepageString);
                    string birthdayString = String.IsNullOrEmpty(Birthday.ToSrting()) ? "" : @"Birthday " + Birthday.ToSrting() + "\r\n";
                    string anniversaryString = String.IsNullOrEmpty(Anniversary.ToSrting()) ? "" : @"Anniversary " + Anniversary.ToSrting() + "\r\n";
                    string dateData = String.IsNullOrEmpty(AddEmptyRow(birthdayString + anniversaryString))? "\r\n": AddEmptyRow(birthdayString + anniversaryString);

                    string secondaryAddressData = AddEmptyRow(CleanUp(SecondaryAddress));
                    string secondaryPhoneString = String.IsNullOrEmpty(SecondaryHomePhone) ? "" : @"P: " + SecondaryHomePhone.Trim() + "\r\n";
                    string secondaryPhoneData = AddEmptyRow(secondaryPhoneString);
                    string notesData = AddEmptyRow(CleanUp(Notes));

                    string allData = mainData + phoneData + emailData + dateData + secondaryAddressData + secondaryPhoneData + notesData;
                    return Regex.Replace(allData, "[ ]+", " ").Trim(); 
                }
            }
            set
            {
                allDetails = value;
            }
        }

        private string AddEmptyRow(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return "";
            }
            else
            {
                return "\r\n" + text;
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

        private string CleanUp(string test)
        {
            if (test == null || test == "")
            {
                return "";
            }
            return test.Trim() + "\r\n";
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x=> x.Deprecated== "0000-00-00 00:00:00") select c).ToList();
            }
        }

    }
}
