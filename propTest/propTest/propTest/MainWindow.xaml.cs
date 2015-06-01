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

namespace propTest
{
    public partial class MainWindow : Window
    {
        List<Person> personList = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            CreatePersons();
        }

        private void CreatePersons()
        {
            personList.Add(new Person("Claessens", "Frankie", 31));
            personList.Add(new Person("Philips", "Brecht", 23));
            personList.Add(new Person("Habraken", "Hans", 19));
            personListBox.ItemsSource = personList;
            Person temp = new Person("","",0);
            temp.naam = "Frankie";
        }
    }
}
