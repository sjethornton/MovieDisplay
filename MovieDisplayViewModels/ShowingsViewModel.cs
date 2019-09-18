using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDisplayViewModels
{
   
    public class ShowingsViewModel
    {
        public struct showTimes
         {
            public bool isSoldOut;
            public string time;

            public showTimes(bool so, string t)
            {
                isSoldOut = so;
                time = t;
            }
         }
        public string name { get; set; }
        public string dimension { get; set; }
        public string format { get; set; }
        public string rating { get; set; }
        public int auditorium { get; set; }
        public List<showTimes> showTime { get; set; }

        //constructor
        //used to combine performance and movie information into one object for ease
        //of use
        public ShowingsViewModel() {
            showTime = new List<showTimes>();
        }

        public void addTime(bool so, string s)
        {
            this.showTime.Add(new showTimes(so, s + " "));
        }
    }
}
