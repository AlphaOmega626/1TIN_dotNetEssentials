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

namespace Gallery
{
    public partial class ImageUserControl : UserControl
    {

        MainWindow mainInstance;
        Image tempImage;
         public ImageUserControl(MainWindow mainInstance, Image mainImage)
        {
            InitializeComponent();
            this.mainInstance = mainInstance;
            this.tempImage = mainImage;
            ShowImage();
        }

        private void ShowImage()
        {
            mainImage.Source = tempImage.Source;
            mainImage.Width = tempImage.Width;
            mainImage.Height = tempImage.Height;
            mainImage.MouseLeftButtonDown += ImageClickHandler;
        }

        void ImageClickHandler(object sender, MouseButtonEventArgs e)
        {
            mainInstance.imageViewer.Content = null;
            mainInstance.imageViewer.Visibility = Visibility.Collapsed;
        }
    }
}
