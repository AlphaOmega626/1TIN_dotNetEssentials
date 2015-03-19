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
            alarmTimeTextBox.Text = "__:__:__";
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
            if (checkString(text))
            {
                int hour = Convert.ToInt32(alarmTimeTextBox.Text.Substring(0, 2));
                int minute = Convert.ToInt32(alarmTimeTextBox.Text.Substring(3, 2));
                int second = Convert.ToInt32(alarmTimeTextBox.Text.Substring(6, 2));
                wekker.setAlarm(alarm.Date + new TimeSpan(hour, minute, second));
                alarmSetTextBox.Content = wekker.getAlarm.ToString("HH:mm:ss");
                alarmLogo.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Enter a corrent time format -> HH:mm:ss", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private Boolean checkString(String text)
        {
            int length = text.Length;
            if (length == 8 && text != String.Empty)
            {
                String part1 = text.Substring(0, 2);
                String part2 = text.Substring(2, 1);
                String part3 = text.Substring(3, 2);
                String part4 = text.Substring(5, 1);
                String part5 = text.Substring(6, 2);
                int part1int;
                int part3int;
                int part5int;
                Boolean part1b = int.TryParse(part1,out part1int);
                Boolean part3b = int.TryParse(part3, out part3int);
                Boolean part5b = int.TryParse(part5, out part5int);
                if (part1b && part3b && part5b)
                {
                    if (part1int < 24 && part2.Equals(":") && part3int < 60 && part4.Equals(":") && part5int < 60)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
            if (alarmLengthTextBox.Text != String.Empty)
            {
                wekker.setAlarmDuur(Convert.ToInt32(alarmLengthTextBox.Text));
            }            
        }
    }
}
