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

namespace Vragen
{
    /// <summary>
    /// Interaction logic for VragenWindow.xaml
    /// </summary>
    public partial class VragenWindow : Window
    {
        public VragenWindow(String s)
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            switch (s)
            {
                case "wiskundeButton":
                    this.Title = "Wiskunde";
                    break;
                case "talenButton":
                    this.Title = "Talen";
                    break;
                case "kennisButton":
                    this.Title = "Kennis";
                    break;
                default:
                    break;
            }
        }

        private void terugButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
