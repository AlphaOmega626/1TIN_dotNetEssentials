using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voetbal
{
    public enum SpelersFunctie
    {
        Doelman = 'D',
        Verdediger = 'V',
        Middenvelder = 'M',
        Aanvaller = 'A'
    }

    public class Speler
    {
        public int rugNummer { get; set; }
        public String voornaam { get; set; }
        public String naam { get; set; }
        public SpelersFunctie functie { get; set; }

        public Speler(int rugNummer, String voornaam, String naam, char functie)
        {
            this.rugNummer = rugNummer;
            this.voornaam = voornaam;
            this.naam = naam;
            this.functie = BepaalFunctie(functie);
        }

        private SpelersFunctie BepaalFunctie(char functie)
        {
            switch (functie)
            {
                case 'D':
                    return SpelersFunctie.Doelman;
                case 'V':
                    return SpelersFunctie.Verdediger;
                case 'M':
                    return SpelersFunctie.Middenvelder;
                case 'A':
                    return SpelersFunctie.Aanvaller;
                default: return SpelersFunctie.Aanvaller;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", naam, voornaam);
        }
    }
}