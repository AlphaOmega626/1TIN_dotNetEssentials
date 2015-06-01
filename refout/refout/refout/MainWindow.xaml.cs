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

namespace refout
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<String> tempList = new List<String>();
            tempList.Add("snul");
            WijzigList(tempList);

            int nummer = 10;
            WijzigNummer(nummer);

        }

        public void WijzigNummer(int getal)
        {
            getal = 0;
        }

        public void WijzigList(List<String> tijdelijkeLijst)
        {
            tijdelijkeLijst.Clear();
        }

            
    }
}
