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
using System.IO;

namespace Voetbal
{
    public partial class MainWindow : Window
    {
        private const int spelersCount = 11;
        private const String spelersPad = "Spelers.txt";
        private const String ploegenPad = "Ploegen.txt";
        private List<Ploeg> ploegenList = new List<Ploeg>();
        private List<Speeldag> speeldagenList = new List<Speeldag>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnableDisable(MenuItem tempMenuItem, bool value)
        {
            tempMenuItem.IsEnabled = value;
        }

        private void ReadTeams()
        {
            if (File.Exists(ploegenPad))
            {
                using (StreamReader tempReader = new StreamReader(ploegenPad, System.Text.Encoding.Default))
                {
                    String line;
                    while ((line = tempReader.ReadLine()) != null)
                    {
                        String[] csv = line.Split(',');
                        Ploeg tempPloeg = new Ploeg(Convert.ToInt32(csv[0]), csv[1], csv[2]);
                        tempPloeg.spelersList = ReadPlayers(tempPloeg.stamNummer);
                        ploegenList.Add(tempPloeg);
                    }
                }
            }
            else
            {
                MessageBox.Show(String.Format("Bestand niet gevonden:{0}", ploegenPad));
            }

        }

        private List<Speler> ReadPlayers(int stamNummer)
        {
            List<Speler> spelersList = new List<Speler>();
            if (File.Exists(spelersPad))
            {

                using (StreamReader tempReader = new StreamReader(spelersPad, System.Text.Encoding.Default))
                {
                    String line;
                    while ((line = tempReader.ReadLine()) != null)
                    {
                        String[] csv = line.Split(',');
                        int spelerStamNummer = Convert.ToInt32(csv[0]);
                        if (spelerStamNummer == stamNummer)
                        {
                            Speler tempSpeler = new Speler(Convert.ToInt32(csv[1]), csv[2], csv[3], Convert.ToChar(csv[4]));
                            spelersList.Add(tempSpeler);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(String.Format("Bestand niet gevonden:{0}", spelersPad));
            }
            return spelersList;
        }

        private void StelWedstrijdenSamen()     //Werkt niet correct, daarom zijn de ploegen niet goed ingesteld in ploegenReeks1 en ploegenReeks2
        {
            for (int i = 0; i < ploegenList.Count - 1; i++)
            {
                Speeldag tempSpeeldag = new Speeldag();
                foreach (Ploeg tempPloeg in ploegenList)
                {
                    tempSpeeldag.ploegenReeks1.Add(tempPloeg);
                    tempSpeeldag.ploegenReeks2.Add(ploegenList[i]);
                    tempSpeeldag.dagNummer = i + 1;
                    tempSpeeldag.GenereerDatum();
                    tempSpeeldag.ShufflePloegenReeks2();
                }
                    speeldagenList.Add(tempSpeeldag);
            }
            EnableDisable(scoresMenuItem, true);
        }
        
        private void MenuClickHandler(object sender, RoutedEventArgs e)
        {
            MenuItem tempMenuItem = (MenuItem)sender;
            switch (tempMenuItem.Name)
            {
                case "leesInMenuItem":
                    ReadTeams();
                    EnableDisable(competitieMenuItem, true);
                    break;
                case "samenstellenMenuItem":
                    StelWedstrijdenSamen();
                    break;
                case "scoresMenuItem":
                    speelDagenListBox.ItemsSource = speeldagenList;
                    break;
                case "rangschikkingMenuItem":
                    RangschikkingWindow tempR = new RangschikkingWindow(ploegenList);
                    tempR.Show();
                    break;
            }
        }

        private void speeldagenListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Speeldag tempSpeeldag = (Speeldag)speelDagenListBox.SelectedItem;
            wedstrijdenListBox.ItemsSource = tempSpeeldag.GetWedstrijdenList();
        }

        private void wedstrijdenListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WedstrijdWindow tempWW = new WedstrijdWindow(this, (Speeldag)speelDagenListBox.SelectedItem,speelDagenListBox.SelectedIndex);
            tempWW.Show();
            this.WindowState = WindowState.Minimized;
        }
    }
}
