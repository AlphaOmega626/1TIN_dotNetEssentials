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
        Random generator1 = new Random();
        Random generator2 = new Random();
        public MainWindow()
        {
            InitializeComponent();
            generator1.Next(5000);

            gen1Label.Content = Convert.ToString(generator1.Next(5000));
            gen2Label.Content = Convert.ToString(generator1.Next(5000));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button temp = (Button)sender;
            if (temp.Name == "gen1Button")
            {
                gen1Label.Content = Convert.ToString(generator1.Next(5000));
            }
            else
            {
                gen2Label.Content = Convert.ToString(generator2.Next(5000));
            }
        }
    }
}
