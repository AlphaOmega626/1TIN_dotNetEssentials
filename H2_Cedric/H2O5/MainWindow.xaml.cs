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

namespace H2O5
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

        private void btnA_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("U ging over de knop.");
        }

        private void btnA_MouseMove_1(object sender, MouseEventArgs e)
        {
            MessageBox.Show("U ging over de knop.");
        }

       
    }
}
