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

namespace Oef06
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
            CheckEmail();
        }

        private void CheckEmail()
        {
            try
            {
                EmailChecker tempEmailChecker = new EmailChecker();
                if (tempEmailChecker.CheckAddress(emailAddressTextBox.Text))
                {
                    MessageBox.Show(String.Format("Geldig Emailadres: {0}", emailAddressTextBox.Text));
                }
            }
            catch (InvalidEmailException ex)
            {
                MessageBox.Show(String.Format("{0}: {1}", ex.message, ex.emailAdress), "Opgelet!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
