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

namespace Oef01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            directDeleteRadioButton.IsChecked = true;
            PopulateListBox();
            SortListBox();
        }

        private void SortListBox()
        {
            personenListBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("",System.ComponentModel.ListSortDirection.Ascending));
        }

        private void PopulateListBox()
        {
            personenListBox.Items.Add("Frankie");
            personenListBox.Items.Add("Cedric");
            personenListBox.Items.Add("Hans");
            personenListBox.Items.Add("Hannah");
            personenListBox.Items.Add("Brecht");
        }

        private void CheckedHandler(object sender, RoutedEventArgs e)
        {
            RadioButton tempRB = (RadioButton)sender;
            switch (tempRB.Name)
            {
                case "directDeleteRadioButton":
                    deleteButton.IsEnabled = false;
                    deleteButton.Opacity = 0.3;                    
                    break;
                case "buttonDeleteRadioButton":
                    deleteButton.IsEnabled = true;
                    deleteButton.Opacity = 1;                    
                    break;
            }
        }

        private void RemoveItem()
        {
            if (personenListBox.SelectedIndex != -1)
            {
                personenListBox.Items.RemoveAt(personenListBox.SelectedIndex);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (directDeleteRadioButton.IsChecked == true)
            {
                RemoveItem();
            }            
        }

    }
}
