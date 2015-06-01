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

namespace Gallery
{
    public partial class MainWindow : Window
    {
        List<Image> imageList = new List<Image>();
        List<ColumnDefinition> columnsList = new List<ColumnDefinition>();
        List<RowDefinition> rowsList = new List<RowDefinition>();
        int rows;
        int columns = 5;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateColumnsRows(){
            // Create columns
            for (int i = 1; i <= columns; i++)
            {
                ColumnDefinition temp = new ColumnDefinition();
                temp.Name = String.Format("c{0}", i);
                temp.Width = new GridLength(205, GridUnitType.Pixel);
                columnsList.Add(temp);
            }
            // Create rows
            for (int i = 1; i <= rows; i++)
            {
                RowDefinition temp = new RowDefinition();
                temp.Name = String.Format("c{0}", i);
                temp.Height = new GridLength(205, GridUnitType.Pixel);
                rowsList.Add(temp);
            }
            // Add Columns and Rows to Grid
            foreach (ColumnDefinition tempColumn in columnsList)
            {
                mainGrid.ColumnDefinitions.Add(tempColumn);
            }
            foreach (RowDefinition tempRow in rowsList)
            {
                mainGrid.RowDefinitions.Add(tempRow);
            }
        }

        private void OpenDirectory()
        {
            String folder;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            fbd.Description = "Kies een map met foto's";
            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                folder = fbd.SelectedPath;
                PopulateList(folder);
                ShowImages();
            }
        }

        private void PopulateList(String folder)
        {
            String[] fileList = Directory.GetFiles(folder);
            foreach (String file in fileList)
            {
                if (file.ToLower().Contains(".jpg") || file.ToLower().Contains(".gif") || file.ToLower().Contains(".png") || file.ToLower().Contains(".bmp"))
                {
                    Image photoImage = new Image();
                    BitmapImage bmpImage = new BitmapImage();
                    bmpImage.BeginInit();
                    bmpImage.UriSource = new Uri(System.IO.Path.Combine(folder,file));
                    bmpImage.EndInit();
                    photoImage.Source = bmpImage;
                    photoImage.MouseLeftButtonDown += ImageClickHandler;
                    imageList.Add(photoImage);
                }
            }
            rows = (imageList.Count / columns) + 1;
        }

        private void ShowImages()
        {
            CreateColumnsRows();
            foreach (Image tempImage in imageList)
            {
                Grid containerGrid = new Grid();
                containerGrid.Width = 140;
                containerGrid.Height = 140;
                containerGrid.Children.Add(tempImage);
                containerGrid.Margin = new Thickness(5);
                Grid.SetColumn(containerGrid, imageList.IndexOf(tempImage) % columns);
                Grid.SetRow(containerGrid, imageList.IndexOf(tempImage) % rows);
                mainGrid.Children.Add(containerGrid);
            }
        }

        void ImageClickHandler(object sender, MouseButtonEventArgs e)
        {
            imageViewer.Content = new ImageUserControl(this, (Image)sender);
            imageViewer.Visibility = Visibility.Visible;
        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.MenuItem tempMenuItem = (System.Windows.Controls.MenuItem)sender;
            switch (tempMenuItem.Name)
            {
                case "openButton":
                    OpenDirectory();
                    break;
                case "closeButton":
                    System.Windows.Application.Current.Shutdown();
                    break;
            }

        }
    }
}
