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

namespace Oef11
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

        private void berekenButton_Click(object sender, RoutedEventArgs e)
        {
            int getal;
            if (int.TryParse(getalTextBox.Text, out getal))
            {
                if (getal < 0 || getal > 255)
                {
                    MessageBox.Show("Het ingegeven getal ligt niet tussen 0 en 255!");
                }
                else
                {
                    String binary = Convert.ToString(getal, 2);
                    binairTextbox.Text = binary;
                }
            }
            else
            {
                MessageBox.Show("U hebt geen getal ingegeven!");
            }

        }
    }
}