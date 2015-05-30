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

namespace Alfabet
{
    
    public partial class MainWindow : Window
    {
        String[,] alfabet = new String[2,26];
        public MainWindow()
        {
            InitializeComponent();
            CreateDictionary();
        }

        public void CreateDictionary()
        {
            String[,] alfabet = new String[2, 26];
            for (int i = 97; i <= 122; i++)
            {

                alfabet[0, i-97] = Convert.ToString(i - 96);
                alfabet[1,i-97] = Convert.ToChar(i).ToString();
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            int key = Convert.ToInt32(searchTextBox.Text);
            for (int i = 0; i <= 25; i++)
            {
                if (Convert.ToInt32(alfabet[0, i]) == key)
                {
                    resultLabel.Content = alfabet[1, i];
                }
            }
        }
    }
}
