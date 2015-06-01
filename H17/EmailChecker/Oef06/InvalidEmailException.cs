using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oef06
{
    public class InvalidEmailException : Exception
    {
        public String message;
        public String emailAdress;
        public InvalidEmailException(String message, String emailAdress)
        {
            this.message = message;
            this.emailAdress = emailAdress;
        }
    }
}
