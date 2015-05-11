using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Threading;

namespace ExamenVB
{
    public partial class MainWindow : Window
    {
        private DeckOfCards deck = new DeckOfCards();
        private int cardCounterUser = 0;
        private int cardCounterComputer = 0;
        Card userTempCard;
        Card computerTempCard;
        public MainWindow()
        {
            InitializeComponent();
            Begin();
        }

        private void Begin()
        {
            deck.GenerateCards();
        }

        private void Shuffle()
        {
            deck.ShuffleCards();
            statusLabel.Content = "Deck Shuffled!";
        }

        private void DealUser()
        {          
            userTempCard = deck.DealCard();
            cardCounterUser++;
            userBackCardImage.Child = userTempCard.GetBackCardImage();
            userFrontCardImage.Child = userTempCard.GetFrontCardImage();
            userFrontCardNameLabel.Content = userTempCard.GetFrontCardName();
            userCardCounterLabel.Content = String.Format("Card #{0}", cardCounterUser.ToString());
            statusLabel.Content = "Card dealt!";
            DealComputer();
        }

        private void DealComputer()
        {
            computerTempCard = deck.DealCard();
            cardCounterComputer++;
            if (computerTempCard == userTempCard)
            {
                Image tempImage = new Image();
                tempImage.Source = userTempCard.GetFrontCardImage().Source;
                computerFrontCardImage.Child = tempImage;
                Image tempImageBack = new Image();
                tempImageBack.Source = userTempCard.GetBackCardImage().Source;
                computerBackCardImage.Child = tempImageBack;
            }
            else
            {
                computerFrontCardImage.Child = computerTempCard.GetFrontCardImage();
                computerBackCardImage.Child = computerTempCard.GetBackCardImage();
            }            
            computerFrontCardNameLabel.Content = computerTempCard.GetFrontCardName();
            computerCardCounterLabel.Content = String.Format("Card #{0}", cardCounterComputer.ToString());
            computerCardCounterLabel.Content = String.Format("Card #{0}", cardCounterUser.ToString());
            CheckCards();
        }

        private void CheckCards()
        {
            if (computerTempCard.GetCardValue() == userTempCard.GetCardValue())
            {
                winLabel.Content = "GELIJK!";
            }
            else if (computerTempCard.GetCardValue() > userTempCard.GetCardValue())
            {
                winLabel.Content = "COMPUTER WINT!";
            }
            else
            {
                winLabel.Content = "JIJ WINT!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            switch (tempButton.Name)
            {
                case "shuffleButton":
                    Shuffle();
                    break;
                case "dealButton":
                    DealUser();
                    break;
            }

        }


    }
}
