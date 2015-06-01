using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Oef06
{
    class EmailChecker
    {
        public bool CheckAddress(String emailAddress)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                throw new InvalidEmailException("Foutief emailadres", emailAddress);
            }
        }
    }
}
