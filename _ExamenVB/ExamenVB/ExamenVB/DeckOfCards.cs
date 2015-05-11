using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Reflection;
using System.Windows.Controls;

namespace ExamenVB
{
    class DeckOfCards
    {
        private String cardsTXTPath = "Cards.txt";
        private List<Card> cardsList = new List<Card>();
        private Random random;

        public DeckOfCards()
        {
            GenerateCards();
            random = random = new Random();
        }

        public void GenerateCards()
        {
            String temp = Path.GetFullPath(cardsTXTPath);
            String[] cardTypes;
            String[] cardNumbers;
            using (StreamReader reader = new StreamReader(cardsTXTPath))
            {
                cardNumbers = reader.ReadLine().Split(',');
                cardTypes = reader.ReadLine().Split(',');
            }
            foreach (String cardType in cardTypes)
            {
                foreach (String cardNumber in cardNumbers)
                {
                    String cardName = String.Concat(cardNumber, cardType);
                    String fileName = String.Concat(cardName, ".png");
                    Image cardFrontImage = new Image();
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(String.Concat("pack://application:,,,/ExamenVB;component/card_images/",fileName));
                    logo.EndInit();
                    cardFrontImage.Source = logo;
                    this.cardsList.Add(new Card(cardName, cardFrontImage));
                }
            }
        }

        public List<Card> ShuffleCards()
        {
            ShuffleList(cardsList);
            return cardsList;
        }

        public Card DealCard()
        {
            int randomCard = random.Next(0,cardsList.Count - 1);
            return this.cardsList[randomCard];
        }

        private void ShuffleList<E>(IList<E> list)
        {
            Random random = new Random();
            if (list.Count > 1)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    E tmp = list[i];
                    int randomIndex = random.Next(i + 1);

                    //Swap elements
                    list[i] = list[randomIndex];
                    list[randomIndex] = tmp;
                }
            }
        }  
    }
}
