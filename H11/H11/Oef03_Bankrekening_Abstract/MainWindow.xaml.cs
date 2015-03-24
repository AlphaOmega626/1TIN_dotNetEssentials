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

namespace Oef03_Bankrekening_Abstract
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bankrekening gewoon;
        Bankrekening golden;
        public MainWindow()
        {
            InitializeComponent();
            gewoon = new GewoneRekening();
            golden = new GoldenRekening();
            updateTextBoxes();
        }
        
        private void stortButton_Click(object sender, RoutedEventArgs e)
        {
            Stort();
            BerekenRente();
            updateTextBoxes();
        }

        private void updateTextBoxes()
        {
            saldoGewoonTextBox.Text = String.Format("{0:C}", gewoon.huidigSaldo);
            saldoGoldenTextBox.Text = String.Format("{0:C}", golden.huidigSaldo);
            renteGewoonTextBox.Text = String.Format("{0:C}", gewoon.GetRente());
            renteGoldenTextbox.Text = String.Format("{0:C}", golden.GetRente());
        }

        private void Stort()
        {
            gewoon.debetSaldo(Convert.ToDouble(stortTextBox.Text));
            golden.debetSaldo(Convert.ToDouble(stortTextBox.Text));
        }

        private void BerekenRente()
        {
            gewoon.BerekenRente();
            golden.BerekenRente();
        }
    }
}
