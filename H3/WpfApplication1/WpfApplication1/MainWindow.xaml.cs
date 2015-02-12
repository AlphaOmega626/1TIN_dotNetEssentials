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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse gezicht = new Ellipse();
        Ellipse linkerOog = new Ellipse();
        Ellipse rechterOog = new Ellipse();
        Ellipse neus = new Ellipse();
        Ellipse mond = new Ellipse();
        

        public MainWindow()
        {
            InitializeComponent();

            gezicht.Width = 350;
            gezicht.Height = 450;
            gezicht.Margin = new Thickness(tekenCanvas.Width / 4, 30, 0, 0);
            gezicht.Stroke = new SolidColorBrush(Colors.Pink);
            gezicht.Fill  = new SolidColorBrush(Colors.Pink);
            
            linkerOog.Width = 40;
            linkerOog.Height = 40;
            linkerOog.Margin = new Thickness(220, 100, 0, 0);
            linkerOog.Stroke = new SolidColorBrush(Colors.Blue);
            linkerOog.Fill = new SolidColorBrush(Colors.DarkBlue);

            rechterOog.Width = 40;
            rechterOog.Height = 40;
            rechterOog.Margin = new Thickness(330, 100, 0, 0);
            rechterOog.Stroke = new SolidColorBrush(Colors.Blue);
            rechterOog.Fill = new SolidColorBrush(Colors.DarkBlue);

            neus.Width = 25;
            neus.Height = 25;
            neus.Margin = new Thickness(275, 200, 0, 0);
            neus.Stroke = new SolidColorBrush(Colors.DeepPink);
            neus.Fill = new SolidColorBrush(Colors.HotPink);

            mond.Width = 80;
            mond.Height = 80;
            mond.Margin = new Thickness(265, 330, 0, 0);
            mond.Stroke = new SolidColorBrush(Colors.Black);
            mond.Fill = new SolidColorBrush(Colors.Black);

        }

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            tekenCanvas.Children.Add(gezicht);
            tekenCanvas.Children.Add(linkerOog);
            tekenCanvas.Children.Add(rechterOog);
            tekenCanvas.Children.Add(neus);
            tekenCanvas.Children.Add(mond);
        }
    }
}
