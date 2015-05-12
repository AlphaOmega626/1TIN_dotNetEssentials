using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace ExamenVB
{
    public class Card
    {
        private String cardFace;
        private String cardSuit;
        private Image cardFrontImage;
        private int cardValue;
        public Card(String cardFace, String cardSuit, Image cardImage)
        {
            this.cardFace = cardFace;
            this.cardSuit = cardSuit;
            this.cardFrontImage = cardImage;
            SetCardValue();
        }

        public Image GetFrontCardImage()
        {
            return this.cardFrontImage;
        }

        public int GetCardValue()
        {
            return this.cardValue;
        }

        private void SetCardValue()
        {
            if (this.cardFace.Contains("Deuce"))
            {
                this.cardValue = 2;
            }
            else if (this.cardFace.Contains("Three"))
            {
                this.cardValue = 3;
            }
            else if (this.cardFace.Contains("Four"))
            {
                this.cardValue = 4;
            }
            else if (this.cardFace.Contains("Five"))
            {
                this.cardValue = 5;
            }
            else if (this.cardFace.Contains("Six"))
            {
                this.cardValue = 6;
            }
            else if (this.cardFace.Contains("Seven"))
            {
                this.cardValue = 7;
            }
            else if (this.cardFace.Contains("Eight"))
            {
                this.cardValue = 8;
            }
            else if (this.cardFace.Contains("Nine"))
            {
                this.cardValue = 9;
            }
            else if (this.cardFace.Contains("Ten"))
            {
                this.cardValue = 10;
            }
            else if (this.cardFace.Contains("Jack"))
            {
                this.cardValue = 11;
            }
            else if (this.cardFace.Contains("Queen"))
            {
                this.cardValue = 12;
            }
            else if (this.cardFace.Contains("King"))
            {
                this.cardValue = 13;
            }
            else if (this.cardFace.Contains("Ace"))
            {
                this.cardValue = 14;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", this.cardFace, this.cardSuit);
        }
    }
}
