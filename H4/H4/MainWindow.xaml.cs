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

namespace H4
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

        private void EnterKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {   Double straal = Convert.ToDouble(straalTextBox.Text);
                Double omtrek = 2 * Math.PI * straal;
                omtrekLabel.Content = String.Format("De omtrek is {0} cm", rondAf(omtrek));
                Double opp = Math.PI * Math.Pow(straal, 2);
                oppLabel.Content = String.Format("De oppervlakte van de de bol is {0} vierkante cm", rondAf(opp));
                Double volume = (4 * Math.PI / 3) * Math.Pow(straal, 3);
                volumeLabel.Content = String.Format("Het volume van de bol is {0} kubieke cm", rondAf(volume));
            }

        }

        public Double rondAf(Double getal) {
            return (Math.Round(getal * 1000.0)) / 1000.0;
        }
    }
}
