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

namespace H2O1
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

        private void btnJa_Click(object sender, RoutedEventArgs e)
        {
            lblA.Content = "Ja";
            lblB.Content = "Ja";
            lblC.Content = "Ja";

        }

        private void btnNee_Click(object sender, RoutedEventArgs e)
        {
            lblA.Content = "Nee";
            lblB.Content = "Nee";
            lblC.Content = "Nee";
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lblA.Content = "A";
            lblB.Content = "B";
            lblC.Content = "C";
        }
    }
}
