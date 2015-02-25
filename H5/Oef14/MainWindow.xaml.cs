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
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            int getal = Convert.ToInt32(intTextBox.Text);
            if (getal < 0 || getal > 255)
            {
                MessageBox.Show("Foutief getal!");
            }
            else {
                binTextBox.Text = decNaarBin(getal);
            }
            
        }

        private String decNaarBin(int getal)
        {
            return Convert.ToString(getal, 2);
        }

    }
}
