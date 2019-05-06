using System;
using System.Windows.Forms;

namespace _7._2
{
    public partial class Clock : Form
    {

        private Timer timer = new Timer();
        public Clock()
        {
            InitializeComponent();
        }

        private void Clock_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Clock_Tick);
            timer.Start();
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            string currentTime = "";
            var hours = DateTime.Now.Hour;
            var minutes = DateTime.Now.Minute;
            var seconds = DateTime.Now.Second;

            if (hours < 10)
            {
                currentTime += "0";
            }
            currentTime += hours;
            currentTime += ":";

            if (minutes < 10)
            {
                currentTime += "0";
            }
            currentTime += minutes;
            currentTime += ":";

            if (seconds < 10)
            {
                currentTime += "0";
            }
            currentTime += seconds;

            time.Text = currentTime;
        }
    }
}
