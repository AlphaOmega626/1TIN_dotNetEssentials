using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Oef08_Wekker
{
    class Wekker
    {
        private DateTime tijd = new DateTime();
        private DateTime alarm = new DateTime();
        private int alarmduur;
        private DispatcherTimer timer = new DispatcherTimer();
        private Boolean alarmWentOff = false;

        public Wekker () {
            alarmWentOff = false;
            alarmduur = 10;
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public Boolean getAlarmWentOff
        {
            get
            {
                return this.alarmWentOff;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            tijd = DateTime.Now;
            if (tijd.ToString("HH:mm:ss").Equals(this.alarm.ToString("HH:mm:ss")))
            {
                alarmWentOff = true;
            }
        }

        public DateTime getTijd {
            get {
                return tijd;
            }
        }

        public void setAlarm (DateTime alarm)
        {
                this.alarm = alarm;
        }

        public void setAlarmDuur(int alarmduur)
        {
            this.alarmduur = alarmduur;

        }

        public void resetAlarm() {
            this.alarmWentOff = false;
        }

        public DateTime getAlarm
        {
            get {
                return this.alarm;
            }
            
        }

        public int getAlarmDuur
        {
            get
            {
                return this.alarmduur;
            }
        }
    }
}
