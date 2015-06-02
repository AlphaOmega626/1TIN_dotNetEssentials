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

namespace Voetbal
{
    public partial class WedstrijdWindow : Window
    {
        int positie;
        Speeldag tempSpeeldag;
        int scorePloeg1;
        int scorePloeg2;
        MainWindow mainInstance;
        public WedstrijdWindow(MainWindow mainInstance, Speeldag tempSpeeldag, int positie)
        {
            InitializeComponent();
            this.positie = positie;
            this.tempSpeeldag = tempSpeeldag;
            this.mainInstance = mainInstance;
            SetLabels();
            UpdateScores();
            SetPlayers();
        }

        private void SetLabels()
        {
            scorePloeg1 = tempSpeeldag.scoreReeks1[positie];
            scorePloeg2 = tempSpeeldag.scoreReeks2[positie];
            ploeg1Label.Content = tempSpeeldag.ploegenReeks1[positie].ToString();
            ploeg2Label.Content = tempSpeeldag.ploegenReeks2[positie].ToString();
        }

        private void UpdateScores()
        {
            scoreP1Label.Content = scorePloeg1;
            scoreP2Label.Content = scorePloeg2;
        }

        private void SetPlayers()
        {
            Ploeg ploeg1 = tempSpeeldag.ploegenReeks1[positie];
            Ploeg ploeg2 = tempSpeeldag.ploegenReeks2[positie];
            spelersPloeg1ListBox.ItemsSource = ploeg1.spelersList;
            spelersPloeg2ListBox.ItemsSource = ploeg2.spelersList;
        }

        private void DoubleClickHandler(object sender, MouseButtonEventArgs e)
        {
            ListBox tempListBox = (ListBox) sender;
            switch (tempListBox.Name)
            {
                case "spelersPloeg1ListBox":
                    scorePloeg1++;
                    UpdateScores();
                    break;
                case "spelersPloeg2ListBox":
                    scorePloeg2++;
                    UpdateScores();
                    break;
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (scorePloeg1 == scorePloeg2)
            {
                tempSpeeldag.ploegenReeks1[positie].punten += 1;
                tempSpeeldag.ploegenReeks2[positie].punten += 1;
            }
            else if (scorePloeg1 > scorePloeg2)
            {
                tempSpeeldag.ploegenReeks1[positie].punten += 3;
            }
            else
            {
                tempSpeeldag.ploegenReeks2[positie].punten += 3;
            }
            mainInstance.WindowState = WindowState.Normal;
            mainInstance.rangschikkingMenuItem.IsEnabled = true;
            this.Close();

        }
    }
}
