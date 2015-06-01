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
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFolder()
        {
            String folder;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            fbd.Description = "Kies een map met tekstbestande";
            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                folder = fbd.SelectedPath;
                CountLines(folder);   
            }
        }

        private void CountLines(String folder)
        {
            String[] files = Directory.GetFiles(folder);
            foreach (String file in files)
            {
                if (file.Contains(".txt"))
                {
                    counter += File.ReadLines(file).Count();
                }
            }
            countLabel.Content = counter.ToString();
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
                    break;
            }
        }
    }
}
