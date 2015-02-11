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

namespace H4Oef11
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
        private int stringToInt(String s)
        {
            int x = Convert.ToInt32(s);
            return x;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void berekenButton_Click(object sender, RoutedEventArgs e)
        {
           
            int y = 0;
            try
            {
               y = stringToInt(invoerTextBox.Text);
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            if(y<=255 && y>=0){
            binairLabel.Content = Convert.ToString(y, 2);}
            else {
                MessageBox.Show("Het getal ligt niet tussen 0 en 255");
            }
        }
    }
}
