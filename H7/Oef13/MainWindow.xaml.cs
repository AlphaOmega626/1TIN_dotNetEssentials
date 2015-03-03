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

namespace Oef13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String btw = "hoog";
        public MainWindow()
        {
            InitializeComponent();
            nettoTextBox.Text = "0";
        }

        private void calcHandler(object sender, TextChangedEventArgs e)
        {
            bereken();
        }

        private void clickHandler(object sender, RoutedEventArgs e)
        {
            bereken();
        }

        private void bereken()
        {
            if (tariefCheckBox.IsChecked == true)
            {
                totaalTextBox.Text = Convert.ToString(Convert.ToInt32(nettoTextBox.Text) * 1.06);
            }
            else
            {
                totaalTextBox.Text = Convert.ToString(Convert.ToInt32(nettoTextBox.Text) * 1.21);
            }
            if (!(totaalTextBox.Text.Equals("null")))
            {
                btwTextBox.Text = Convert.ToString(Convert.ToDecimal(totaalTextBox.Text) - Convert.ToDecimal(nettoTextBox.Text));
            }

        }


    }
}
