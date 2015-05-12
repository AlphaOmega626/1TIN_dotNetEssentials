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
using Microsoft.Win32;


namespace ExamenVB
{
    public partial class MainWindow : Window
    {
        private DeckOfCards deckUser;
        private DeckOfCards deckComputer;
        private int cardCounterUser = 1;
        private int cardCounterComputer = 1;
        DispatcherTimer computerSleepTimer = new DispatcherTimer();
        private int computerWins = 0;
        private int userWins = 0;
        public MainWindow()
        {
            InitializeComponent();
            DisableMenuItems();
        }

        private void DisableMenuItems()
        {
            dealMenuItem.Opacity = 0.3;
            dealMenuItem.IsEnabled = false;
            dealButton.Opacity = 0.3;
            dealButton.IsEnabled = false;
            shuffleButton.Opacity = 0.3;
            shuffleButton.IsEnabled = false;
            userBackCardImage.Visibility = Visibility.Hidden;
            computerBackCardImage.Visibility = Visibility.Hidden;
        }

        private void EnableMenuItems()
        {
            dealMenuItem.Opacity = 1;
            dealMenuItem.IsEnabled = true;
            dealButton.Opacity = 1;
            dealButton.IsEnabled = true;
            shuffleButton.Opacity = 1;
            shuffleButton.IsEnabled = true;
            userBackCardImage.Visibility = Visibility.Visible;
            computerBackCardImage.Visibility = Visibility.Visible;
        }

        private void EnableDealButton()
        {
            dealButton.Opacity = 1;
            dealButton.IsEnabled = true;
        }

        private void DisableDealButton()
        {
            dealButton.Opacity = 0.3;
            dealButton.IsEnabled = false;
        }

        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                String fullPath = ofd.FileName;
                deckUser = new DeckOfCards(fullPath);
                deckComputer = new DeckOfCards(fullPath);
            }
            computerSleepTimer.Interval = TimeSpan.FromMilliseconds(1000);
            computerSleepTimer.Tick += computerSleepTimer_Tick;
            dealMenuItem.Opacity = 1;
            dealMenuItem.IsEnabled = true;
            EnableMenuItems();
            statusLabel.Content = "Decks created, click shuffle!";
        }

        void computerSleepTimer_Tick(object sender, EventArgs e)
        {
            DealComputer();
        }

        private void Shuffle()
        {
            deckUser.ShuffleCards();
            statusLabel.Content = "Deck Shuffled!";
            computerWins = 0;
            userWins = 0;
            winLabel.Content = String.Empty;
            userCardCounterLabel.Content = String.Empty;
            userFrontCardNameLabel.Content = String.Empty;
            computerCardCounterLabel.Content = String.Empty;
            computerFrontCardNameLabel.Content = String.Empty;
            EnableDealButton();
        }

        private void DealUser()
        {
            if (cardCounterUser <= 52)
            {
                deckUser.DealCard();
                userFrontCardImage.Children.Clear();
                userFrontCardImage.Children.Add(deckUser.currentCard.GetFrontCardImage());
                userFrontCardNameLabel.Content = deckUser.currentCard.ToString();
                userCardCounterLabel.Content = String.Format("Card #{0}", cardCounterUser.ToString());
                statusLabel.Content = "Card dealt!";
                cardCounterUser++;
                computerSleepTimer.Start();
            }
            else
            {
                String winner;
                if (userWins > computerWins)
                {
                    winner = "You";
                }
                else
                {
                    winner = "Computer";
                }
                winLabel.Content = String.Format("Congratulations! Winner: {0}! The computer won {1} times and you won {2} times!", winner, computerWins, userWins);
                userCardCounterLabel.Content = "No more cards to deal";
                userFrontCardNameLabel.Content = "Shuffle cards to continue";
                computerCardCounterLabel.Content = "No more cards to deal";
                computerFrontCardNameLabel.Content = "Shuffle cards to continue";
                DisableMenuItems();
                DisableDealButton();
            }
        }

        private void DealComputer()
        {
            deckComputer.DealCard();
            computerFrontCardImage.Children.Clear();
            computerFrontCardImage.Children.Add(deckComputer.currentCard.GetFrontCardImage());
            computerFrontCardNameLabel.Content = deckComputer.currentCard.ToString();
            computerCardCounterLabel.Content = String.Format("Card #{0}", cardCounterComputer.ToString());
            cardCounterComputer++;
            CheckWinner();
            computerSleepTimer.Stop();
            EnableDealButton();
        }

        private void CheckWinner()
        {
            if (deckComputer.currentCard != null && deckUser.currentCard != null)
            {
                if (deckComputer.currentCard.GetCardValue() == deckUser.currentCard.GetCardValue())
                {
                    userResultLabel.Content = "EQUAL!";
                    compResultLabel.Content = "EQUAL!";
                }
                else if (deckComputer.currentCard.GetCardValue() > deckUser.currentCard.GetCardValue())
                {
                    compResultLabel.Content = "COMPUTER WINS!";
                    userResultLabel.Content = String.Empty;
                    computerWins++;
                }
                else
                {
                    userResultLabel.Content = "YOU WIN!";
                    compResultLabel.Content = String.Empty;
                    userWins++;
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
                case "openMenuItem":
                    OpenFile();
                    break;
                case "exitMenuItem":
                    Application.Current.Shutdown();
                    break;
                case "dealMenuItem":
                    DealUser();
                    break;
            }
        }

        private void CardHandler(object sender, MouseButtonEventArgs e)
        {
            DealUser();
        }


    }
}
