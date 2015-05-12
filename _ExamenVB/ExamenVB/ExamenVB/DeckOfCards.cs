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
        public Card currentCard;
        public DeckOfCards()
        {
            GenerateCards();
            random = random = new Random();
        }

        public void GenerateCards()
        {
            String temp = Path.GetFullPath(cardsTXTPath);
            String[] cardSuits;
            String[] cardFaces;
            using (StreamReader reader = new StreamReader(cardsTXTPath))
            {
                cardFaces = reader.ReadLine().Split(',');
                cardSuits = reader.ReadLine().Split(',');
            }
            foreach (String cardSuit in cardSuits)
            {
                foreach (String cardFace in cardFaces)
                {
                    String cardName = String.Concat(cardFace, cardSuit);
                    String fileName = String.Concat(cardName, ".png");
                    Image cardFrontImage = new Image();
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(String.Concat("pack://application:,,,/ExamenVB;component/card_images/",fileName));
                    logo.EndInit();
                    cardFrontImage.Source = logo;
                    this.cardsList.Add(new Card(cardFace, cardSuit, cardFrontImage));
                }
            }
        }

        public List<Card> ShuffleCards()
        {
            ShuffleList(cardsList);
            return cardsList;
        }

        public void DealCard()
        {
            int randomCard = random.Next(0,cardsList.Count - 1);
            this.currentCard = this.cardsList[randomCard];
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
