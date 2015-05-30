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
    public partial class MainWindow : Window
    {
        Ellipse circle = new Ellipse();
        public MainWindow()
        {
            InitializeComponent();
            CreateCircle();
        }

        private void CreateCircle()
        {
            circle.Width = 50;
            circle.Height = 50;
            circle.Stroke = new SolidColorBrush(Colors.Black);
            circle.Fill = new SolidColorBrush(Colors.LightBlue);
            drawCanvas.Children.Add(circle);
        }

        private void ValueChangedHandler(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider tempSlider = (Slider)sender;
            circle.Width = tempSlider.Value;
            circle.Height = tempSlider.Value;
        }
    }
}
