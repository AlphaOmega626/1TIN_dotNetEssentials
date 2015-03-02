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

namespace Oef11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Ellipse cirkel = new Ellipse();
        Line uur = new Line();
        Line minuten = new Line();
        Line seconden = new Line();
        SolidColorBrush brush = new SolidColorBrush(Colors.Black);
        DispatcherTimer timer = new DispatcherTimer();
 
        public MainWindow()
        {
            InitializeComponent();
            cirkel.Stroke = brush;
            cirkel.Width = 200;
            cirkel.Height = 200;
            paperCanvas.Children.Add(cirkel);
            Canvas.SetLeft(cirkel, (paperCanvas.Width / 2) - (cirkel.Width / 2));
            Canvas.SetTop(cirkel, (paperCanvas.Height / 2) - (cirkel.Height / 2));
            timer.Start();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            String hour = DateTime.Now.Hour.ToString();
            String minute = DateTime.Now.Minute.ToString();
            String second = DateTime.Now.Second.ToString();
            timeTextBox.Text = String.Format("{0}:{1}:{2}", hour, minute, second);
            timeTextBox.TextAlignment = TextAlignment.Center;
        }
    }
}
