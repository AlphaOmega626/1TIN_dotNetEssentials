using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voetbal
{
    public class Ploeg
    {

        public int stamNummer { get; set; }
        public String naam { get; set; }
        public String locatie { get; set; }
        public List<Speler> spelersList { get; set; }
        public int punten { get; set; }

        public Ploeg(int stamNummer, String naam, String locatie)
        {
            this.stamNummer = stamNummer;
            this.naam = naam;
            this.locatie = locatie;
        }

        public override string ToString()
        {
            return naam;
        }
    }
}
