using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeheerVragen
{
    interface VraagActies
    {
        char GetVak();
        char GetVraagType();
        int GetmGraad();
        String GetOpgave();
        int GetScore();
        void SetVak(char vak);
        void SetVraagType(char type);
        void SetmGraad(int mGraad);
        void SetOpgave(String opgave);
        void SetScore(int score);
    }
}
