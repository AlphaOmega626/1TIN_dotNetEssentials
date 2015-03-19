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
        private DateTime alarm = new DateTime();
        int teller = 0;
        public MainWindow()
        {
            InitializeComponent();
            wekker = new Wekker();
            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;
            currentTimeLabel.Background = new SolidColorBrush(Colors.LightGray);
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            
            currentTimeLabel.Content = wekker.getTijd.ToString("HH:mm:ss");
            if (wekker.getAlarmWentOff == true)
            {
                teller++;
                if (teller != wekker.getAlarmDuur)
                {
                    if (DateTime.Now.Second % 2 == 0)
                    {
                        currentTimeLabel.Background = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        currentTimeLabel.Background = new SolidColorBrush(Colors.LightGray);
                    }
                }
                else
                {
                    teller = 0;
                    wekker.resetAlarm();
                    currentTimeLabel.Background = new SolidColorBrush(Colors.LightGray);
                    alarmLogo.Visibility = Visibility.Hidden;
                    alarmSetTextBox.Content = "";
                }
                
            }
        }

        private void setAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            String text = alarmTimeTextBox.Text;
            checkString(text);
            if (!(alarmTimeTextBox.Text.Equals(null))   )
            {
                int hour = Convert.ToInt32(alarmTimeTextBox.Text.Substring(0, 2));
                int minute = Convert.ToInt32(alarmTimeTextBox.Text.Substring(3, 2));
                int second = Convert.ToInt32(alarmTimeTextBox.Text.Substring(6, 2));
                wekker.setAlarm(alarm.Date + new TimeSpan(hour, minute, second));
                alarmSetTextBox.Content = wekker.getAlarm.ToString("HH:mm:ss");
                alarmLogo.Visibility = Visibility.Visible;
            }
            
        }

        private void checkString(String text)
        {
            int length = text.Length;
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = Convert.ToChar(text.Substring(i, 1));
            }
        }

        private void resetAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            wekker.resetAlarm();
            alarmLogo.Visibility = Visibility.Hidden;
            alarmSetTextBox.Content = "";
        }

        private void saveAlarmLengthButton_Click(object sender, RoutedEventArgs e)
        {
            wekker.setAlarmDuur(Convert.ToInt32(alarmLengthTextBox.Text));
        }
    }
}
