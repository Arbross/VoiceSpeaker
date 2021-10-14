﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Timers;

namespace Server.Reminder
{
        public class Reminder
        {
            public string TextMessage { get; set; }
            public string FileStay { get; set; }
            SoundPlayer player = new SoundPlayer("FileStay");
            private DateTime TimeNow = DateTime.Now;
            private DateTime alarmtimeStart = Convert.ToDateTime("12:00:00");
            private DateTime alarmtimeStop = Convert.ToDateTime("12:02:00");
            private Timer _timer = new Timer();


            public Reminder(string fileStay,string textMassage)
            {
                if (fileStay.Contains(".wav"))
                {
                    FileStay = fileStay;
                }
                if (textMassage != null)
                {
                    TextMessage = textMassage;
                }
                
            }

            private void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                player.Play();
                _timer.Stop();
            }

            public void AlarmTime()
            {
                if (TimeNow.Hour >= alarmtimeStart.Hour && TimeNow.Minute >= alarmtimeStart.Minute && TimeNow.Second >= alarmtimeStart.Second && TimeNow.Hour <= alarmtimeStop.Hour && TimeNow.Minute <= alarmtimeStop.Minute && TimeNow.Second <= alarmtimeStop.Second)
                {
                    _timer.Interval = 2000;
                    _timer.Elapsed += OnTimedEvent;
                    _timer.Start();
                }
            }
        }
}
