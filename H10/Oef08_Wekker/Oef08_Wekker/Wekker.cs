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

        public Wekker () {
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            tijd = DateTime.Now;
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
    }
}
