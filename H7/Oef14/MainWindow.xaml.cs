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

namespace Oef14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            voornaamTextBox.Text = "";
            naamTextBox.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String voornaam = voornaamTextBox.Text;
            String naam = naamTextBox.Text;
            double geslachtsFactor = 1.0, leeftijdsFactor = 1.0;
            if (manRButton.IsChecked == true)
            {
                geslachtsFactor = 1.0;
            }
            else if (vrouwRButton.IsChecked == true)
            {
                geslachtsFactor = 1.25;
            }
            if (leeftijd1RButton.IsChecked == true || leeftijd4RButton.IsChecked == true)
            {
                leeftijdsFactor = 2.0;
            }
            else if (leeftijd2RButton.IsChecked == true || leeftijd3RButton.IsChecked == true)
            {
                leeftijdsFactor = 1.0;
            }
            double premie = 500 * leeftijdsFactor * geslachtsFactor;
            MessageBox.Show(String.Format("De premie voor {0} {1} bedraagt {2:c}", voornaam, naam, premie));
        }
    }
}
