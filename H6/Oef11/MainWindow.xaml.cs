using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Analog_clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        String hour;
        String minute;
        String second;

        //Create an instance of RotateTransform objects
        private RotateTransform MinHandTr = new RotateTransform();
        private RotateTransform HourHandTr = new RotateTransform();
        private RotateTransform SecHandTr = new RotateTransform();

        //Create an instance of DispatcherTimer
        private DispatcherTimer dT = new DispatcherTimer();
        public MainWindow()
            : base()
        {
            Loaded += MainWindow_Loaded;
            this.InitializeComponent();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dT.Tick += dispatcher_Tick;
            dT.Interval = TimeSpan.FromMilliseconds(1000);
            dT.Start();
            secondHandTransform.Angle = (DateTime.Now.Second * 6);
            hour = Convert.ToString(DateTime.Now.Hour);
            minute = Convert.ToString(DateTime.Now.Minute);
            second = Convert.ToString(DateTime.Now.Second);
        }

        public void dispatcher_Tick(object source, EventArgs e)
        {
            MinHandTr.Angle = (DateTime.Now.Minute * 6);
            HourHandTr.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);
            textBox1.Text = DateTime.Now.ToShortDateString();
            Minutehand.RenderTransform = MinHandTr;
            Hourhand.RenderTransform = HourHandTr;
            timeTextBox.Text = String.Format("{0}:{1}:{2}", hour, minute, second);
        }
    }
}