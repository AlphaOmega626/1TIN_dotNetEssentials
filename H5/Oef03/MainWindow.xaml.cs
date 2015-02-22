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

namespace Oef03
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToonInkomen(Convert.ToInt32(jaarInkomenTextBox.Text), Convert.ToInt32(jarenDienstTextBox.Text));
        }

        private void ToonInkomen(int jaarInkomen, int jarenDienst)
        {
            int totaalSalaris = jaarInkomen * jarenDienst;
            MessageBox.Show(String.Format("Totaal salaris: {0:C}", totaalSalaris));
        }
    }
}
