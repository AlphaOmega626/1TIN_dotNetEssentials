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

namespace Oef20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<String, Vak> vakkenDictionary = new Dictionary<String, Vak>();
        public MainWindow()
        {
            InitializeComponent();      
            CreateVakken();
        }

        private void CreateVakken()
        {
            vakkenDictionary.Add("Web", new Vak("Web", "E. Ulrichts", 6));
            vakkenDictionary.Add("dotNet", new Vak("dotNet", "J. Raymaekers", 6));
            vakkenDictionary.Add("Cisco", new Vak("Cisco", "V. Asaert", 4));
            vakkenDictionary.Add("Communication", new Vak("Communication", "L. Custers", 4));
            vakkenDictionary.Add("SQL", new Vak("SQL", "K. Nys", 4));
            vakkenDictionary.Add("Math", new Vak("Math", "I. Vanherwegen", 4));
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Text = SearchVak();            
        }

        private String SearchVak()
        {
            String result = String.Empty;
            if(vakkenDictionary.ContainsKey(searchTextBox.Text))
            {
                result = vakkenDictionary[searchTextBox.Text].ToString();
            }
            else
            {
                result = "Vak niet gevonden!";
            }
            return result;
        }
    }
}
