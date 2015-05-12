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
using System.Windows.Threading;

namespace ExamenVB
{
    public partial class MainWindow : Window
    {
        private DeckOfCards deckUser = new DeckOfCards();
        private DeckOfCards deckComputer = new DeckOfCards();
        private int cardCounterUser = 0;
        private int cardCounterComputer = 0;
        DispatcherTimer computerSleepTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            Begin();
        }

        private void Begin()
        {
            deckUser.GenerateCards();
            computerSleepTimer.Interval = TimeSpan.FromMilliseconds(2000);
            computerSleepTimer.Tick += computerSleepTimer_Tick;
            
        }

        void computerSleepTimer_Tick(object sender, EventArgs e)
        {
            if (cardCounterComputer <= 52)
            {
                deckComputer.DealCard();
                cardCounterComputer++;
                computerFrontCardImage.Children.Clear();
                computerFrontCardImage.Children.Add(deckComputer.currentCard.GetFrontCardImage());
                computerFrontCardNameLabel.Content = deckComputer.currentCard.ToString();
                computerCardCounterLabel.Content = String.Format("Card #{0}", cardCounterComputer.ToString());
                computerCardCounterLabel.Content = String.Format("Card #{0}", cardCounterUser.ToString());
                CheckCards();
                computerSleepTimer.Stop();
            }
            else
            {

            }
        }

        private void Shuffle()
        {
            deckUser.ShuffleCards();
            statusLabel.Content = "Deck Shuffled!";
        }

        private void DealUser()
        {
            if (cardCounterUser <= 52)
            {
                cardCounterUser++;
                deckUser.DealCard();
                userFrontCardImage.Children.Clear();
                userFrontCardImage.Children.Add(deckUser.currentCard.GetFrontCardImage());
                userFrontCardNameLabel.Content = deckUser.currentCard.ToString();
                userCardCounterLabel.Content = String.Format("Card #{0}", cardCounterUser.ToString());
                statusLabel.Content = "Card dealt!";
                DealComputer();
            }
            else
            {

            }
        }

        private void DealComputer()
        {
            computerSleepTimer.Start();
        }

        private void CheckCards()
        {
            if (deckComputer.currentCard != null && deckUser.currentCard != null)
            {
                if (deckComputer.currentCard.GetCardValue() == deckUser.currentCard.GetCardValue())
                {
                    winLabel.Content = "GELIJK!";
                }
                else if (deckComputer.currentCard.GetCardValue() > deckUser.currentCard.GetCardValue())
                {
                    winLabel.Content = "COMPUTER WINT!";
                }
                else
                {
                    winLabel.Content = "JIJ WINT!";
                }
            }
        }

        private void ButtonHandler(object sender, RoutedEventArgs e)
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

        private void MenuHandler(object sender, RoutedEventArgs e)
        {
            MenuItem tempMenuItem = (MenuItem)sender;
            switch (tempMenuItem.Name)
            {
                case "closeMenuItem":
                    this.Close();
                    break;
                case "dealMenuItem":
                    DealUser();
                    break;
            }
        }

        private void CardHandler(object sender, MouseButtonEventArgs e)
        {
            Image tempGrid = (Image)sender;
            switch (tempGrid.Name)
            {
                case "userBackCardImage":
                    DealUser();
                    break;
                case "computerBackCardImage":
                    DealComputer();
                    break;
            }

        }


    }
}
