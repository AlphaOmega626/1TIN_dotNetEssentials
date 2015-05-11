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
        private String cardName; 
        private Image cardFrontImage;
        private Image cardBackImage;
        private int cardValue;
        public Card(String cardName, Image cardImage)
        {
            this.cardName = cardName;
            this.cardFrontImage = cardImage;
            this.cardBackImage = new Image();
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/ExamenVB;component/card_images/cardback.png");
            logo.EndInit();
            cardBackImage.Source = logo;
            SetCardValue();
        }

        public Image GetFrontCardImage()
        {
            return this.cardFrontImage;
        }

        public Image GetBackCardImage()
        {
            return this.cardBackImage;
        }

        public String GetFrontCardName()
        {
            return this.cardName;
        }

        public int GetCardValue()
        {
            return this.cardValue;
        }

        private void SetCardValue()
        {
            if (this.cardName.Contains("Deuce"))
            {
                this.cardValue = 2;
            }
            else if (this.cardName.Contains("Three"))
            {
                this.cardValue = 3;
            }
            else if (this.cardName.Contains("Four"))
            {
                this.cardValue = 4;
            }
            else if (this.cardName.Contains("Five"))
            {
                this.cardValue = 5;
            } 
            else if (this.cardName.Contains("Six"))
            {
                this.cardValue = 6;
            }
            else if (this.cardName.Contains("Seven"))
            {
                this.cardValue = 7;
            }
            else if (this.cardName.Contains("Eight"))
            {
                this.cardValue = 8;
            }
            else if (this.cardName.Contains("Nine"))
            {
                this.cardValue = 9;
            }
            else if (this.cardName.Contains("Ten"))
            {
                this.cardValue = 10;
            }
            else if (this.cardName.Contains("Jack"))
            {
                this.cardValue = 11;
            }
            else if (this.cardName.Contains("Queen"))
            {
                this.cardValue = 12;
            }
            else if (this.cardName.Contains("King"))
            {
                this.cardValue = 13;
            }
            else if (this.cardName.Contains("Ace"))
            {
                this.cardValue = 14;
            }
        }
    }
}
