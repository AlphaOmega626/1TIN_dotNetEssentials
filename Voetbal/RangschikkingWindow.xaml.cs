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
using System.Windows.Shapes;

namespace Voetbal
{
    public partial class RangschikkingWindow : Window
    {
        List<Ploeg> ploegenList;
        public RangschikkingWindow(List<Ploeg> ploegenList)
        {
            InitializeComponent();
            this.ploegenList = ploegenList;
            LaadPloegen();
        }

        private void LaadPloegen()
        {
            foreach(Ploeg tempPloeg in ploegenList)
            {
                rangschikkingTextBox.Text += String.Format("{0}\t{1}{2}", tempPloeg.punten, tempPloeg.naam,Environment.NewLine);
            }
        }
        
        private void sluitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
