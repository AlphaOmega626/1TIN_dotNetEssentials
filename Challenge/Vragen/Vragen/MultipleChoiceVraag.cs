using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeheerVragen
{
    class MultipleChoiceVraag : Vraag
    {
        String[] possibleAnswers = new String[3];
        bool[] correctAnswers = new bool[3];

        public MultipleChoiceVraag(char vak, char type, int mGraad, String opgave, 
            String[]answers, bool[] correctAnswers) : 
            base(vak, type, mGraad,opgave)
        {
            for (int i = 0; i < answers.Length; i++)
            {
                this.possibleAnswers[i] = answers[i];
                this.correctAnswers[i] = correctAnswers[i];
            }
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

        public int CalculateScore(bool[] givenAnswers) {
            for (int i = 0; i < correctAnswers.Length; i++)
            {
                if (givenAnswers[i].Equals(correctAnswers[i]))
                {
                    this.score += mGraad;
                }
            }
                return score;
        }

        public override String ToString()
        {
            return String.Format("{0} | {1}", this.vak, this.type);
        }
    }
}
