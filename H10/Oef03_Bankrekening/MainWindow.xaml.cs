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

namespace Oef03_Bankrekening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Bankrekening bankrek;
        public MainWindow()
        {
            InitializeComponent();
            bankrek = new Bankrekening();
            updateSaldo();
            afhaalButton.Visibility = Visibility.Hidden;
        }

        private void afhaalButton_Click(object sender, RoutedEventArgs e)
        {
            bankrek.afhalen(Convert.ToDouble(amountTextBox.Text));
            updateSaldo();
            if (bankrek.getSaldo() < 0)
            {
                MessageBox.Show("NEGATIEF SALDO!");
            }
        }

        private void stortButton_Click(object sender, RoutedEventArgs e)
        {
            bankrek.storten(Convert.ToDouble(amountTextBox.Text));
            updateSaldo();
        }

        private void updateSaldo()
        {
            saldoTextBox.Content = String.Format("{0:C}", bankrek.getSaldo());
            if (bankrek.getSaldo() > 0)
            {
                afhaalButton.Visibility = Visibility.Visible;
            }
            else
            {
                afhaalButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
