using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oef08
{
    public class Persoon
    {
        String naam, voornaam;
        char geslacht;
        String adres;
        int telefoonNummer;
        String geboorteDatum;

        public Persoon(String naam, String voornaam, char geslacht, String adres, int telefoonNummer, String geboorteDatum)
        {
            this.naam = naam;
            this.voornaam = voornaam;
            this.geslacht = geslacht;
            this.adres = adres;
            this.telefoonNummer = telefoonNummer;
            this.geboorteDatum = geboorteDatum;
        }

        public Persoon(Persoon tempPersoon) 
        {
            this.voornaam = tempPersoon.GetVoornaam;
            this.naam = tempPersoon.naam;
            this.geslacht = tempPersoon.GetGeslacht;
            this.adres = tempPersoon.GetAdres;
            this.telefoonNummer = tempPersoon.GetTelefoonNummer;
            this.geboorteDatum = tempPersoon.GetGeboorteDatum;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.voornaam, this.naam);
        }

        public String GetVoornaam
        {
            get
            {
                return this.voornaam;
            }
        }

        public String GetNaam
        {
            get
            {
                return this.naam;
            }
        }

        public char GetGeslacht
        {
            get
            {
                return this.geslacht;
            }
        }

        public String GetAdres
        {
            get
            {
                return this.adres;
            }
        }

        public int GetTelefoonNummer
        {
            get
            {
                return this.telefoonNummer;
            }
        }

        public String GetGeboorteDatum
        {
            get
            {
                return this.geboorteDatum;
            }
        }

        public void SetVoornaam(String voornaam)
        {
            this.voornaam = voornaam;
        }

        public void SetNaam(String naam)
        {
            this.naam = naam;
        }

        public void SetGeslacht(char geslacht)
        {
            this.geslacht = geslacht;
        }

        public void SetAdres(String adres)
        {
            this.adres = adres;
        }

        public void SetTelefoonNummer(int telefoonNummer)
        {
            this.telefoonNummer = telefoonNummer;
        }

        public void SetGeboorteDatum(String geboorteDatum)
        {
            this.geboorteDatum = geboorteDatum;
        }
    }
}
