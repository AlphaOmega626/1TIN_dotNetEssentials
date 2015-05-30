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

namespace Oef09
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

        private String GenerateLargeString()
        {
            String result = String.Empty;
            char[] letters = { 'a', 'b', 'c' };
            Random random = new Random();
            Random random2 = new Random();
            random.Next(0, 2);
            
            for (int i = 0; i <= 10000; i++)
            {
                for (int j = 0; j <= random.Next(2, 5); j++)
                {

                }
            }
            return result;
        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            switch (tempButton.Name)
            {
                case "executeButton":
                    break;
                case "clearButton":
                    resultTextBlock.Text = String.Empty;
                    break;
                case "loadButton":
                    resultTextBlock.Text = GenerateLargeString();
                    break;
            }
        }
    }
}
