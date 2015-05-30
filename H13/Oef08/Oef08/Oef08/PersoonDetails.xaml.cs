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

namespace Oef08
{
    /// <summary>
    /// Interaction logic for PersoonDetails.xaml
    /// </summary>
    public partial class PersoonDetails : Window
    {
        MainWindow mainInstance;
        public PersoonDetails(MainWindow mainInstance)
        {
            InitializeComponent();
            this.mainInstance = mainInstance;
            FillInFields();
        }

        private void FillInFields()
        {
            voornaamTextBox.Text = mainInstance.tempPersoon.GetVoornaam;
            naamTextBox.Text = mainInstance.tempPersoon.GetNaam;
            geslachtTextBox.Text = mainInstance.tempPersoon.GetGeslacht.ToString();
            adresTextBox.Text = mainInstance.tempPersoon.GetAdres;
            telefoonNummerTextBox.Text = mainInstance.tempPersoon.GetTelefoonNummer.ToString();
            geboorteDatumTextBox.Text = mainInstance.tempPersoon.GetGeboorteDatum;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainInstance.tempPersoon.SetVoornaam(voornaamTextBox.Text);
            mainInstance.tempPersoon.SetNaam(naamTextBox.Text);
            CheckGeslacht();
            mainInstance.tempPersoon.SetAdres(adresTextBox.Text);
            CheckTelefoonNummer();
            mainInstance.tempPersoon.SetGeboorteDatum(geboorteDatumTextBox.Text);
            mainInstance.UpdateList();
            this.Close();
        }

        private void CheckGeslacht()
        {
            if (geslachtTextBox.Text.Equals("M") || geslachtTextBox.Text.Equals("V"))
            {
                mainInstance.tempPersoon.SetGeslacht(Convert.ToChar(geslachtTextBox.Text));
            }
            else
            {
                MessageBox.Show("Het geslacht mag enkel M of V zijn!");
            }
        }

        private void CheckTelefoonNummer()
        {
            int result;
            bool succes = Int32.TryParse(telefoonNummerTextBox.Text, out result);
            if (succes)
            {
                mainInstance.tempPersoon.SetTelefoonNummer(result);
            }
            else
            {
                MessageBox.Show("Het telefoonnummer mag enkel cijfers bevatten!");
            }
        }
    }
}
