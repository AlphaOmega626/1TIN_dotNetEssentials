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

namespace H4Oef9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void resetLabel()
        {
            euroLabel.Content = "The number of 1 euro coins is ";
            cent50Label.Content = "The number of 50 cent coins is ";
            cent20Label.Content = "The number of 20 cent coins is ";
            cent10Label.Content = "The number of 10 cent coins is ";
            cent5Label.Content = "The number of 5 cent coins is ";
            cent2Label.Content = "The number of 2 cent coins is ";
            cent1Label.Content = "The number of 1 cent coins is ";

        }

        private int teBetalen(int i)
        {
            switch (i)
            {
                case 0: return 50;
                    break;
                case 1: return 50;
                    break;
                case 2: return 30;
                    break;
                default: return 0;
                    break;
            }
        }

        private void bedragButton_Click(object sender, RoutedEventArgs e)
        {
            resetLabel();
            int amountGiven = Convert.ToInt32(bedragTextBox.Text);
            int itemCost = teBetalen(Convert.ToInt32(keuzeTextBox.Text));
            //Twee bereken variabelen
            int x = 0, y = 0, z=0;
            string s;

           if ((amountGiven - itemCost) >= 0)
            {   //vb 183
               //Euro
                x = (amountGiven - itemCost) / 100; //x = 1
                s = (string)euroLabel.Content;
                euroLabel.Content = s + " " + x;
                y = (amountGiven - itemCost) % 100; // y = 83
               //50Cent
                x = y / 50;//x = 1
                s = (string)cent50Label.Content;
                cent50Label.Content = s + " " + x;
                x = y % 50; // x = 33
               //20Cent
                y = x / 20; //y = 1
                s = (string)cent20Label.Content;
                cent20Label.Content = s + " " + y;
                y = x % 20; // y = 13
               //10Cent
                x = y / 10; //x = 1
                s = (string)cent10Label.Content;
                cent10Label.Content = s + " " + x;
                x = y % 10; // x = 3
               //5Cent
                y = x / 5; //y = 0
                s = (string)cent5Label.Content;
                cent5Label.Content = s + " " + y;
                y = x % 5; // y = 3
               //2Cent
                x = y / 2; //x = 1
                s = (string)cent2Label.Content;
                cent2Label.Content = s + " " + x;
                x = y % 2; // x = 1
               //1Cent
                y = x / 1; //y = 0
                s = (string)cent1Label.Content;
                cent1Label.Content = s + " " + y;
                
            }
            else if ((amountGiven - itemCost) < 0)
            {
                MessageBox.Show("U hebt een tekort van " + ((amountGiven - itemCost) * -1) + "cent");
            }

        }
    }
}
