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
using System.Windows.Forms;
using System.IO;

namespace Oef07
{
    public partial class MainWindow : Window
    {
        List<String> FileLineList = new List<String>();
        String folder;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            fbd.Description = "Kies een map met tekstbestande";
            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                folder = fbd.SelectedPath;
                searchButton.IsEnabled = true;
            }
        }

        private void Search()
        {
            String[] files = Directory.GetFiles(folder);
            foreach (String file in files)
            {
                if (file.Contains(".txt"))
                {
                    int counter = 0;
                    using (StreamReader tempReader = new StreamReader(System.IO.Path.Combine(folder,file)))
                    {
                        String line;
                        while ((line = tempReader.ReadLine()) != null)
                        {
                            counter++;
                            if (line.Contains(searchTextBox.Text))
                            {
                                FileLineList.Add(String.Format("Bestand: {0}\t\tLijnnummer: {1}", System.IO.Path.GetFileName(file), counter));
                            }
                        }
                    }
                }
            }
            FillTextBlock();
        }

        private void FillTextBlock()
        {
            foreach(String tempString in FileLineList)
            {
                resultTextBlock.Text += String.Format("{0}{1}", tempString, Environment.NewLine);
            }
        }

        private void MenuHandler(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.MenuItem tempMenuItem = (System.Windows.Controls.MenuItem)sender;
            switch (tempMenuItem.Name)
            {
                case "openMenuButton":
                    OpenFolder();
                    break;
                case "closeMenuButton":
                    System.Windows.Application.Current.Shutdown();
                    break;
            }
        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            if (!(searchTextBox.Text.Equals(null) || searchTextBox.Text.Equals("")))
            {
                Search();
            }            
        }
    }
}
