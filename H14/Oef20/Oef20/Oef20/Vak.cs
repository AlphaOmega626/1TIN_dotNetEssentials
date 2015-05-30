using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oef20
{
    class Vak
    {
        String naam, docent;
        int uren;

        public Vak(String naam, String docent, int uren)
        {
            this.naam = naam;
            this.docent = docent;
            this.uren = uren;
        }

        public String GetNaam
        {
            get
            {
                return this.naam;
            }
        }

        public override string ToString()
        {
            return String.Format("Vakgegevens voor {0}\r\n\r\nDocent: {1}\r\nUren: {2}", this.naam, this.docent, this.uren);
        }
    }
}
