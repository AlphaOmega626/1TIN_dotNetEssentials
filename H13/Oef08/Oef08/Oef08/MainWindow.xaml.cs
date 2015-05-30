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
using System.Collections.ObjectModel;

namespace Oef08
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Persoon> personenList = new ObservableCollection<Persoon>();
        public Persoon tempPersoon;
        public int positionInlist = -1;
        public MainWindow()
        {
            InitializeComponent();
            CreatePersonen();
        }

        private void CreatePersonen()
        {
            personenList.Add(new Persoon("Claessens", "Frankie", 'M', "De Schom 26, 3600 Genk", 0478604083, "17/01/1984"));
            personenList.Add(new Persoon("Patronoudis", "Hannah", 'V', "Hoogveldstraat 54, 3600 Genk", 0478371442, "18/04/1996"));
            personenList.Add(new Persoon("Claessens", "Frankie", 'M', "De Schom 26, 3600 Genk", 0478604083, "17/01/1984"));
            personenList.Add(new Persoon("Patronoudis", "Hannah", 'V', "Hoogveldstraat 54, 3600 Genk", 0478371442, "18/04/1996"));
            personenList.Add(new Persoon("Claessens", "Frankie", 'M', "De Schom 26, 3600 Genk", 0478604083, "17/01/1984"));
            personenList.Add(new Persoon("Patronoudis", "Hannah", 'V', "Hoogveldstraat 54, 3600 Genk", 0478371442, "18/04/1996"));
            personenList.Add(new Persoon("Claessens", "Frankie", 'M', "De Schom 26, 3600 Genk", 0478604083, "17/01/1984"));
            personenList.Add(new Persoon("Patronoudis", "Hannah", 'V', "Hoogveldstraat 54, 3600 Genk", 0478371442, "18/04/1996"));
            personenList.Add(new Persoon("Claessens", "Frankie", 'M', "De Schom 26, 3600 Genk", 0478604083, "17/01/1984"));
            personenList.Add(new Persoon("Patronoudis", "Hannah", 'V', "Hoogveldstraat 54, 3600 Genk", 0478371442, "18/04/1996"));
            personenList.Add(new Persoon("Claessens", "Frankie", 'M', "De Schom 26, 3600 Genk", 0478604083, "17/01/1984"));
            personenList.Add(new Persoon("Patronoudis", "Hannah", 'V', "Hoogveldstraat 54, 3600 Genk", 0478371442, "18/04/1996"));            
            personenListBox.ItemsSource = personenList;
        }

        private void DoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            ListBox tempListBox = (ListBox)sender;
            tempPersoon = (Persoon)tempListBox.SelectedItem;
            positionInlist = personenList.IndexOf(tempPersoon);
            PersoonDetails tempDetails = new PersoonDetails(this);
            tempDetails.Show();
        }

        public void UpdateList()
        {
            
            personenList[positionInlist] = tempPersoon;
            personenListBox.ItemsSource = null;
            personenListBox.ItemsSource = personenList;
            //Alternatief voor ItemsSource = null en ItemsSource = personenList -> personenListBox.Items.Refresh();      
        }
    }
}
