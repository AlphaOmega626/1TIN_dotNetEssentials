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
using System.Windows.Threading;
using System.Diagnostics;

namespace Oef09
{
    public partial class MainWindow : Window
    {
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            List<String> comboList = new List<String>();
            comboList.Add("AskFrasier Methode");
            comboList.Add("StringBuilder");
            comboList.Add("Library");
            algorithmComboBox.ItemsSource = comboList;
            algorithmComboBox.SelectedIndex = 0;        
        }

        void timer_Tick(object sender, EventArgs e)
        {
            counter++;
        }

        private String GenerateLargeString()
        {
            String result = String.Empty;
            char[] letters = { 'a', 'b', 'c' };
            Random random = new Random();
            for (int i = 0; i <= 10000; i++)                                //Aantal woorden
            {
                for (int j = 0; j <= random.Next(1, 6); j++)                //Aantal letters in het woord
                {
                    result += letters[random.Next(0, 3)].ToString();
                }
                result += " ";
            }
            return result;
        }

        private void ClearBoxes()
        {
            resultTextBlock.Text = String.Empty;
            timeLabel.Content = String.Empty;
        }

        private String AskFrasier()
        {
            return GetReply(searchTextBox.Text);
        }

        private String GetReply(String searchString)
        {
            String resultString = String.Empty;
            String[] tempList = resultTextBlock.Text.Split(' ');
            for (int i = 0; i < tempList.Count(); i++)
            {
                if (tempList[i].Equals(searchTextBox.Text))
                {
                    tempList[i] = replaceTextBox.Text;
                }
                resultString += String.Format("{0} ", tempList[i]);
            }
            return resultString;
        }

        private StringBuilder StringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            String[] tempList = resultTextBlock.Text.Split(' ');
            for (int i = 0; i < tempList.Count(); i++)
            {
                if (tempList[i].Equals(searchTextBox.Text))
                {
                    tempList[i] = replaceTextBox.Text;
                }
                sb.Append(String.Format("{0} ", tempList[i]));
            }
            return sb;
        }

        private String Library()
        {
            String temp = resultTextBlock.Text;
            temp.Replace(searchTextBox.Text, replaceTextBox.Text);
            return temp;
        }

        private void Execute()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            switch (algorithmComboBox.SelectedItem.ToString())
            {
                case "AskFrasier Methode":
                    resultTextBlock.Text = AskFrasier();
                    break;
                case "Stringbuilder":
                    resultTextBlock.Text = StringBuilder().ToString();
                    break;
                case "Library":
                    resultTextBlock.Text = Library();
                    break;
            }
            sw.Stop();
            timeLabel.Content = String.Format("Finished in {0} milliseconds", sw.ElapsedMilliseconds);
        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            Button tempButton = (Button)sender;
            switch (tempButton.Name)
            {
                case "executeButton":
                    Execute();
                    break;
                case "clearButton":
                    ClearBoxes();
                    break;
                case "loadButton":
                    resultTextBlock.Text = GenerateLargeString();
                    break;
            }
        }
    }
}
