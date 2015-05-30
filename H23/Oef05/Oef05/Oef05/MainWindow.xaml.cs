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

namespace Oef05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StringList mainList = new StringList();
        public MainWindow()
        {
            InitializeComponent();
            stringListBox.ItemsSource = mainList.GetList();
        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            switch (tempButton.Name)
            {
                case "searchButton":
                    Search();
                    break;
                case "addButton":
                    mainList.Insert(StringTextBox.Text); 
                    break;
                case "deleteButton":
                    mainList.Delete(StringTextBox.Text);
                    break;
            }
        }

        private void Search()
        {
            int position = mainList.Search(StringTextBox.Text);
            String textToShow;
            if (position == -1)
            {
                textToShow = "String niet gevonden!";
            }
            else
            {
                textToShow = String.Format("String gevonden op positie {0} in de lijst!", position);
            }
            MessageBox.Show(textToShow);
        }

        private void stringListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StringTextBox.Text = (String)stringListBox.SelectedItem;
        }
    }
}
