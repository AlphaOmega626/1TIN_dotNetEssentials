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
using System.Collections.ObjectModel;

namespace Blackjack_Oef03
{
    public partial class MainWindow : Window
    {
        Dictionary<int, String> cards = new Dictionary<int, String>();
        List<int> userCards = new List<int>();
        List<int> computerCards = new List<int>();
        int userSum = 0;
        int computerSum = 0;
        Random seed = new Random();
        public MainWindow()
        {
            InitializeComponent();
            FillDictionary();
            DealUser();
        }

        private void ResetGame()
        {
            userCards.Clear();
            computerCards.Clear();
            userSumLabel.Content = String.Empty;
            computerSumLabel.Content = String.Empty;
            winnerLabel.Content = String.Empty;
            userCardsListBox.Items.Clear();
            computerCardsListBox.Items.Clear();
            userSum = 0;
            computerSum = 0;
            cards.Clear();
            FillDictionary();
            DealUser();
            EnableButtons();
        }

        private void DealUser()
        {
            Random random = new Random(seed.Next(10));
            int randomCard = random.Next(1, 14);
            userCards.Add(randomCard);
            userCardsListBox.Items.Add(String.Format("{0}\t\t{1}",cards[randomCard], randomCard));
            DealComputer();
        }

        private void DealComputer()
        {
            Random random = new Random(seed.Next(5));
            int randomCard = random.Next(1, 14);
            computerCards.Add(randomCard);
            computerCardsListBox.Items.Add(String.Format("{0}\t\t{1}", cards[randomCard], randomCard));
            CalculateSum();
            CheckWinner();
        }

        private void CalculateSum()
        {
            userSum = 0;
            computerSum = 0;
            foreach (int card in userCards)
            {
                userSum += card;
            }
            userSumLabel.Content = userSum;
            foreach (int card in computerCards)
            {
                computerSum += card;
            }
            computerSumLabel.Content = computerSum;
        }

        private void CheckWinner()
        {
            if (userSum == 21)
            {
                winnerLabel.Content = "USER WINS";
                DisableButtons();
            }
            else if (computerSum == 21)
            {
                winnerLabel.Content = "COMPUTER WINS";
                DisableButtons();
            }
            else
            {
                if (userSum > 21 || computerSum > 21)
                {
                    if (userSum > 21)
                    {
                        winnerLabel.Content = "COMPUTER WINS";
                    }
                    else
                    {
                        winnerLabel.Content = "USER WINS";
                    }
                    DisableButtons();
                }
            }
            
        }

        private void EnableButtons()
        {
            cardButton.IsEnabled = true;
            cardButton.Opacity = 1;
            pasButton.IsEnabled = true;
            pasButton.Opacity = 1;
        }

        private void DisableButtons()
        {
            cardButton.IsEnabled = false;
            cardButton.Opacity = 0.3;
            pasButton.IsEnabled = false;
            pasButton.Opacity = 0.3;
        }

        private void FillDictionary()
        {
            cards.Add(1, "Een");
            cards.Add(2, "Twee");
            cards.Add(3, "Drie");
            cards.Add(4, "Vier");
            cards.Add(5, "Vijf");
            cards.Add(6, "Zes");
            cards.Add(7, "Zeven");
            cards.Add(8, "Acht");
            cards.Add(9, "Negen");
            cards.Add(10, "Boer");
            cards.Add(11, "Dame");
            cards.Add(12, "Koning");
            cards.Add(13, "Aas");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            switch (tempButton.Name)
            {
                case "cardButton":
                    DealUser();
                    break;
                case "pasButton":
                    DealComputer();
                    break;
                case "resetButton":
                    ResetGame();
                    break;
            }
        }

        private void TopMenuHandler(object sender, RoutedEventArgs e)
        {
            MenuItem tempButton = (MenuItem)sender;
            switch (tempButton.Name)
            {
                case "startButton":
                    ResetGame();
                    break;
                case "closeButton":
                    Application.Current.Shutdown();
                    break;
            }

        }
    }
}
