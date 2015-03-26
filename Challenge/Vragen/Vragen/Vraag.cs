using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeheerVragen
{
    abstract class Vraag : VraagActies
    {
        protected char vak;
        protected char type;
        protected int mGraad;
        protected String opgave;
        protected int score;

        public Vraag(char vak, char type, int mGraad, String opgave)
        {
            this.vak = vak;
            this.type = type;
            this.mGraad = mGraad;
            this.opgave = opgave;
        }

        public abstract char GetVak();
        public abstract char GetVraagType();
        public abstract int GetmGraad();
        public abstract String GetOpgave();
        public abstract int GetScore();
        public abstract void SetVak(char vak);
        public abstract void SetVraagType(char type);
        public abstract void SetmGraad(int mGraad);
        public abstract void SetOpgave(String opgave);
        public abstract void SetScore(int score);
    }
}
