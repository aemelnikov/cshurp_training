using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactDateData
    {
        public ContactDateData()
        {

        }
        public string Day { get; set; }
        public string Mounth { get; set; }
        public string Year { get; set; }





        public string ToSrting()
        {
            string day= (Day != null && Day != "-")? Day+@". ":"";
            string mounth = (Mounth != null && Mounth != "-") ? Mounth +" " : "";
            string year = (Year != null && Year != "-") ? Year + Age(): "";
            return day + mounth + year;
        }

        public string Age()
        {
            if (Date() == DateTime.MinValue)
            {
                return "";
            }
            int age = DateTime.Today.Year - Date().Year;
            if(DateTime.Today.DayOfYear < Date().DayOfYear){ age--; }
            if (age<0||age>=150)
            {
                return "";
            }
            return " (" + age + ")";
        }

        public DateTime Date()
        {
            DateTime date = new DateTime();
            bool isYearCorrect = Int32.TryParse(Year, out int year);
            if (!isYearCorrect || year<=0 || year>=9999)
            {
                return date;
            }

            int mounth;
            switch (Mounth)
            {
                case "January": mounth = 1;
                    break;
                case "February":
                    mounth = 2;
                    break;
                case "March":
                    mounth = 3;
                    break;
                case "April":
                    mounth = 4;
                    break;
                case "May":
                    mounth = 5;
                    break;
                case "June":
                    mounth = 6;
                    break;
                case "July":
                    mounth = 7;
                    break;
                case "August":
                    mounth = 8;
                    break;
                case "September":
                    mounth = 9;
                    break;
                case "October":
                    mounth = 10;
                    break;
                case "November":
                    mounth = 11;
                    break;
                case "December":
                    mounth = 12;
                    break;
                default: mounth = 1;
                    break;


            }

            bool isDayCorrect= Int32.TryParse(Day, out int day);
            if (!isDayCorrect) { day = 1; }

            return date.AddDays(day-1).AddMonths(mounth-1).AddYears(year-1);
            
        }
    }
}
