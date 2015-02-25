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

namespace Oef05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Polygon driehoek = new Polygon();
        public MainWindow()
        {
            InitializeComponent();
            driehoek.Stroke = new SolidColorBrush(Colors.Black);
            driehoek.Fill = new SolidColorBrush(Colors.LightBlue);
            driehoek.Points = new PointCollection {new Point(50,150), new Point(110, 50), new Point(160,150) };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (paperCanvas.Children.Contains(driehoek)) {
                paperCanvas.Children.Remove(driehoek);
                paperCanvas.Children.Add(driehoek);
            }
            else
            {
                paperCanvas.Children.Add(driehoek);
            }            
        }
    }
}
