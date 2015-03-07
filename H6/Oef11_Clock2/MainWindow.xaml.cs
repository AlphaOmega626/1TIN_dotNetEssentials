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

namespace Oef11_Clock2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse klokEllipse = new Ellipse();
        Ellipse klokCenterEllipse = new Ellipse();
        Rectangle minuteHand = new Rectangle();
        Rectangle hourHand = new Rectangle();
        Rectangle secondHand = new Rectangle();
        SolidColorBrush brush = new SolidColorBrush(Colors.Black);
        DispatcherTimer timer = new DispatcherTimer();
        RotateTransform rotHour = new RotateTransform();
        RotateTransform rotMinute = new RotateTransform();
        RotateTransform rotSecond = new RotateTransform();
        TextBox currentTime = new TextBox();

        public MainWindow()

        {
            InitializeComponent();

            klokEllipse.Width = 250;
            klokEllipse.Height = 250;
            klokEllipse.Stroke = brush;
            klokEllipse.Fill = new SolidColorBrush(Colors.Transparent);
            klokEllipse.StrokeThickness = 3;

            klokCenterEllipse.Width = 30;
            klokCenterEllipse.Height = 30;
            klokCenterEllipse.Stroke = brush;
            klokCenterEllipse.Fill = brush;
         
            minuteHand.Width = 10;
            minuteHand.Height = (klokEllipse.Height / 2) * 0.85;
            minuteHand.Stroke = brush;
            minuteHand.Fill = brush;
            
            hourHand.Width = minuteHand.Width * 1.5;
            hourHand.Height = minuteHand.Height * 0.75;
            hourHand.Stroke = brush;
            hourHand.Fill = brush;

            secondHand.Width = minuteHand.Width * 0.5;
            secondHand.Height = minuteHand.Height * 1.15;
            secondHand.Stroke = brush;
            secondHand.Fill = brush;

            currentTime.Width = 100;
            currentTime.Height = 20;
            currentTime.TextAlignment = TextAlignment.Center;

            Canvas.SetLeft(klokEllipse, (paperCanvas.Width / 2) - klokEllipse.Width / 2);
            Canvas.SetTop(klokEllipse, (paperCanvas.Height / 2) - klokEllipse.Height / 2);
            Canvas.SetLeft(klokCenterEllipse, (paperCanvas.Width / 2) - klokCenterEllipse.Width / 2);
            Canvas.SetTop(klokCenterEllipse, (paperCanvas.Height / 2) - klokCenterEllipse.Height / 2);
            Canvas.SetLeft(minuteHand, (paperCanvas.Width / 2) - minuteHand.Width / 2);
            Canvas.SetTop(minuteHand, (paperCanvas.Height / 2) - minuteHand.Height);
            Canvas.SetLeft(hourHand, (paperCanvas.Width / 2) - hourHand.Width / 2);
            Canvas.SetTop(hourHand, (paperCanvas.Height / 2) - hourHand.Height);
            Canvas.SetLeft(secondHand, (paperCanvas.Width / 2) - secondHand.Width / 2);
            Canvas.SetTop(secondHand, (paperCanvas.Height / 2) - secondHand.Height);
            Canvas.SetLeft(currentTime, (paperCanvas.Width / 2) - currentTime.Width / 2);
            Canvas.SetBottom(currentTime, 0);

            paperCanvas.Children.Add(klokEllipse);
            paperCanvas.Children.Add(klokCenterEllipse);
            paperCanvas.Children.Add(minuteHand);
            paperCanvas.Children.Add(hourHand);
            paperCanvas.Children.Add(secondHand);
            paperCanvas.Children.Add(currentTime);

            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            
            hourHand.RenderTransformOrigin = new Point(0.5,1);
            rotHour.Angle = DateTime.Now.Hour * 30;

            minuteHand.RenderTransformOrigin = new Point(0.5, 1);
            rotMinute.Angle = DateTime.Now.Minute * 6;

            secondHand.RenderTransformOrigin = new Point(0.5, 1);
            rotSecond.Angle = DateTime.Now.Second * 6;

            secondHand.RenderTransform = rotSecond;
            hourHand.RenderTransform = rotHour;
            minuteHand.RenderTransform = rotMinute;

            currentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
