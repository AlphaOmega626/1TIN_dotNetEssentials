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

namespace Oef01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random generator = new Random();
        private int teller = 0;
        public MainWindow()
        {
            InitializeComponent();
            somTextBox.Text = "0";
        }

        private void geneerButton_Click(object sender, RoutedEventArgs e)
        {
            randomTextBox.Text = Convert.ToString(generator.Next(200, 400));
            teller++;
            somTextBox.Text = Convert.ToString(Convert.ToInt32(somTextBox.Text) + Convert.ToInt32(randomTextBox.Text));
            gemiddeldeTextBox.Text = Convert.ToString(Convert.ToDouble(somTextBox.Text) / teller);
        }
    }
}
