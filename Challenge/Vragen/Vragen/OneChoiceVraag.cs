using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeheerVragen
{
    class OneChoiceVraag : Vraag
    {
        String correctAnswer;
        public OneChoiceVraag(char vak, char type, int mGraad, String correctAnswer, String opgave
            )
            : base(vak, type, mGraad, opgave)
        {
            this.correctAnswer = correctAnswer;
        }

        public override char GetVak()
        {
            return this.vak;
        }

        public override char GetVraagType()
        {
            return this.type;
        }

        public override int GetmGraad()
        {
            return this.mGraad;
        }

        public override String GetOpgave()
        {
            return this.opgave;
        }

        public override int GetScore()
        {
            return this.score;
        }

        public String GetCorrectAnswer()
        {
            return this.correctAnswer;
        }

        public override void SetVak(char vak)
        {
            this.vak = vak;
        }

        public override void SetVraagType(char type)
        {
            this.type = type;
        }

        public override void SetmGraad(int mGraad)
        {
            this.mGraad = mGraad;
        }

        public override void SetOpgave(string opgave)
        {
            this.opgave = opgave;
        }

        public override void SetScore(int score)
        {
            this.score = score;
        }

        public override string ToString()
        {
            return String.Format("{0} | {1} | {2} | {3} | {4}", this.vak, this.type, this.mGraad, this.correctAnswer, this.opgave);
        }
    }
}
