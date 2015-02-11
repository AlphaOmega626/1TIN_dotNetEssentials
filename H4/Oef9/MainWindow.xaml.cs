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

namespace Oef9 {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       

        private void bedragButton_Click(object sender, RoutedEventArgs e)
        {
            int gegevenBedrag = Convert.ToInt32(bedragTextBox.Text);
            int artikelPrijs = (Convert.ToInt32(keuzeTextBox.Text));
            int restWaardeA = 0;
            int restWaardeB = 0;

            if ((gegevenBedrag - artikelPrijs) >= 0)
            {   
                //1 Euro
                restWaardeA = (gegevenBedrag - artikelPrijs) / 100; 
                euroLabel.Content = restWaardeA;
                restWaardeB = (gegevenBedrag - artikelPrijs) % 100; 
                //50Cent
                restWaardeA = restWaardeB / 50;
                cent50Label.Content = restWaardeA;
                restWaardeA = restWaardeB % 50; 
                //20Cent
                restWaardeB = restWaardeA / 20;
                cent20Label.Content = restWaardeB;
                restWaardeB = restWaardeA % 20;
                //10Cent
                restWaardeA = restWaardeB / 10;
                cent10Label.Content = restWaardeA;
                restWaardeA = restWaardeB % 10;
                //5Cent
                restWaardeB = restWaardeA / 5;
                cent5Label.Content = restWaardeB;
                restWaardeB = restWaardeA % 5;
                //2Cent
                restWaardeA = restWaardeB / 2;
                cent2Label.Content = restWaardeA;
                restWaardeA = restWaardeB % 2;
                //1Cent
                restWaardeB = restWaardeA / 1;
                cent1Label.Content = restWaardeB;

            }
            else if ((gegevenBedrag - artikelPrijs) < 0)
            {
                int tekortBedrag = (gegevenBedrag - artikelPrijs) * -1;
                MessageBox.Show(String.Format("U komt {0:e}", tekortBedrag));
            }

        }
    }
}
