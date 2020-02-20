using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string nickname;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public ContactData(string firstname, string lastname, string nickname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
        }
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string NickName
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
    }
}
