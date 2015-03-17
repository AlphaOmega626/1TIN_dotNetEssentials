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
            saldoTextBox.Content = String.Format("{0:C}", bankrek.getSaldo());
        }

        private void transactionButton_Click(object sender, RoutedEventArgs e)
        {
            bankrek.transaction(Convert.ToDouble(amountTextBox.Text));
            saldoTextBox.Content = String.Format("{0:C}", bankrek.getSaldo());
            if (bankrek.getSaldo() < 0)
            {
                MessageBox.Show("NEGATIEF SALDO!");
            }
        }
    }
}
