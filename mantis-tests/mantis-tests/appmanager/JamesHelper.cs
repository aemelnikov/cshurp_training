using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager)
        {

        }


        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }

            TelnetConnection telnet = LoginToTelnet();
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }

        private TelnetConnection LoginToTelnet()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());

            return telnet;
        }

        public void Delete(AccountData account)
        {
            if (!Verify(account))
            {
                return;
            }

            TelnetConnection telnet = LoginToTelnet();
            telnet.WriteLine("deluser " + account.Name);
            System.Console.Out.WriteLine(telnet.Read());
        }

        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = LoginToTelnet();
            telnet.WriteLine("verify " + account.Name);
            String s = telnet.Read();
            System.Console.Out.WriteLine(s);
            return !s.Contains("does not exist");
            
        }
    }
}
