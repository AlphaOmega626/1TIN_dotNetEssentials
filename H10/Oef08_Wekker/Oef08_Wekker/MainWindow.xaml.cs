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

namespace Oef08_Wekker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Wekker wekker;
        private DispatcherTimer timer1;
        public MainWindow()
        {
            InitializeComponent();
            wekker = new Wekker();
            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            currentTimeLabel.Content = wekker.getTijd.ToString("HH:mm:ss");
        }

        private void setAlarmButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
