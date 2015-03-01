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
using System.Windows.Threading;

namespace Oef02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private Rectangle rectangleMinuten = new Rectangle();
        private Rectangle rectangleSeconden = new Rectangle();
        SolidColorBrush brush = new SolidColorBrush(Colors.Black);
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += timer_Tick;
            timer.Start();
            rectangleMinuten.Stroke = brush;
            rectangleMinuten.Fill = brush;
            rectangleMinuten.Height = 50;
            rectangleMinuten.Width = 0;
            rectangleSeconden.Fill = brush;
            rectangleSeconden.Height = 50;
            rectangleSeconden.Width = 0;
            paperCanvas.Children.Add(rectangleMinuten);
            paperCanvas.Children.Add(rectangleSeconden);
            Canvas.SetLeft(rectangleMinuten, 0);
            Canvas.SetLeft(rectangleSeconden, 0);
            Canvas.SetTop(rectangleMinuten, 150);
            Canvas.SetTop(rectangleSeconden, 50);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            paperCanvas.Children.Clear();
            rectangleSeconden.Width +=10;
            if (rectangleSeconden.Width % 600 == 0) {
                rectangleMinuten.Width += 10;
                rectangleSeconden.Width = 0;
            }
            paperCanvas.Children.Add(rectangleMinuten);
            paperCanvas.Children.Add(rectangleSeconden);
        }
    }
}
