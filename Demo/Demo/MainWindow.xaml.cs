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

namespace Demo
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

        private void txtButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(txtButton1))
            {
                txtLabelA.Content = "Ja";
                txtLabelB.Content = "Ja";
                txtLabelC.Content = "Ja";

            }
            else if (sender.Equals(txtButton2))
            {
                txtLabelA.Content = "Nee";
                txtLabelB.Content = "Nee";
                txtLabelC.Content = "Nee";
            }
            else if (sender.Equals(txtButton3))
            {
                txtLabelA.Content = "A";
                txtLabelB.Content = "B";
                txtLabelC.Content = "C";
            }
        }
    }
}
