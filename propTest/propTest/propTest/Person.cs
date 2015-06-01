using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace propTest
{
    class Person
    {
        public String naam { get; set; }
        public String voornaam { get; set; }
        public int leeftijd { get; set; }

        public Person(String naam, String voornaam, int leeftijd)
        {
            this.naam = naam;
            this.voornaam = voornaam;
            this.leeftijd = leeftijd;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", naam, voornaam, leeftijd);
        }
    }
}
