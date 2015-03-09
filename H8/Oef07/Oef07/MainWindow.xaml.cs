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

namespace Oef07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        
    {
        int einde;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tekenButton_Click(object sender, RoutedEventArgs e)
        {
            tabelTextBlock.Text = "";
            if (!intTextBox.Text.Equals(null))
            {
                einde = Convert.ToInt32(intTextBox.Text);
            }
            if (einde > 0 && einde < 16)
            {
                for (int rij = 1; rij <= einde; rij++)
                {
                    for (int kolom = 1; kolom <= einde; kolom++)
                    {
                        if (rij == 1 && kolom == 1)
                        {
                            for (int i = 1; i <= einde; i++)
                            {
                                tabelTextBlock.Text += String.Format("{0}{1}", "\t", i);
                            }
                            tabelTextBlock.Text += "\n\n";
                        }
                        int product = rij * kolom;
                        if (kolom == 1)
                        {
                            tabelTextBlock.Text += Convert.ToString(rij);
                        }
                        tabelTextBlock.Text += String.Format("{0}{1}", "\t", product);

                    }
                    tabelTextBlock.Text += "\n";
                }
               
            }
            else
            {
                MessageBox.Show("Vul een getal > 0 en <= 15 in!");
            }            
        }
    }
}
