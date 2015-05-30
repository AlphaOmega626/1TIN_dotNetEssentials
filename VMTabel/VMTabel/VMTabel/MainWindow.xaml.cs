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

namespace VMTabel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            CheckTextBox();   
        }

        private bool CheckNumeric()
        {
            bool result = false;
            foreach (char c in VMTextBox.Text)
            {
                if (Char.IsDigit(c))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        private void CheckTextBox()
        {
            if (VMTextBox.Text != String.Empty)
            {
                int result;
                bool succes = Int32.TryParse(VMTextBox.Text, out result);
                if (succes)
                {
                    VMTextBlock.Text = GenerateTable(result);
                }
                else
                {
                    MessageBox.Show("Gelieve enkel cijfers in te geven!");
                }
            }
            else
            {
                MessageBox.Show("Gelieve een getal in te geven!");
            }
        }

        private String GenerateTable(int multiplier)
        {
            String result = String.Empty;
            bool firstTime = true;
                for (int i = 1; i <= multiplier; i++)
                {
                    if (firstTime)
                    {
                        for (int j = 1; j <= multiplier; j++)
                        {
                            result += String.Format("\t{0}", j);
                            firstTime = false;
                        }
                        result += Environment.NewLine;
                        result += Environment.NewLine;
                    }
                    result += String.Format("{0}", i);
                    for (int j = 1; j <= multiplier; j++)
                    {
                        int number = i * j;
                        result += String.Format("\t{0}", number);
                    }
                    result += Environment.NewLine;
                }
            return result;
        }
    }
}
