/*
 * Made by Frankie Claessens
 * 26/03/2015
 */

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
using System.Windows.Shapes;
using System.IO;
using System.Collections;

namespace BeheerVragen
{
    /// <summary>
    /// Interaction logic for VragenWindow.xaml
    /// </summary>
    public partial class VragenWindow : Window
    {
        String pathWiskunde = "wiskunde.txt";
        String pathTalen = "talen.txt";
        String pathKennis = "kennis.txt";
        List<VraagActies> vragen = new List<VraagActies>();
        public VragenWindow(String s)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            switch (s)
            {
                case "wiskundeButton":
                    this.Title = "Wiskunde";
                    checkFile(pathWiskunde);
                    break;
                case "talenButton":
                    this.Title = "Talen";
                    checkFile(pathTalen);
                    break;
                case "kennisButton":
                    this.Title = "Kennis";
                    checkFile(pathKennis);
                    break;
                default:
                    break;
            }
        }

        private void terugButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void checkFile(String path)
        {
            if (File.Exists(path)) {
                readFile(path);
            } else {
                File.WriteAllText(path, "");
            }
        }

        private void readFile(String path)
        {
            int counter = 0;
            String line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                createVraagObject(line);
                vragenListBox.Items.Add(String.Format("Vraag {0}: {1}",counter+1,vragen[counter].ToString()));
                counter++;
            }
        }

        private void vragenListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pos = vragenListBox.SelectedIndex;
            vakTextBox.Text = Convert.ToString(vragen[pos].GetVak());
            typeTextBox.Text = Convert.ToString(vragen[pos].GetVraagType());
            mGraadTextBox.Text = Convert.ToString(vragen[pos].GetmGraad());
            opgaveTextBox.Text = Convert.ToString(vragen[pos].GetOpgave());
        }

        private void createVraagObject(String line) {
            char vak = Convert.ToChar(line.Substring(0,1));
            char type = Convert.ToChar(line.Substring(2,1));
            int mGraad = Convert.ToInt32(line.Substring(4,1));
            int pos = line.IndexOf('|', 6);
            int length = pos-6;
            String correctAnswer = line.Substring(6, length);
            String opgave = line.Substring(pos+1);
            if (type == 'E')
            {
                vragen.Add(new OneChoiceVraag(vak,type,mGraad,correctAnswer,opgave));
            }
            else
            {

            }
        }
    }
}
