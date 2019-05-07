using System;
using System.Windows.Forms;

namespace _7._2
{
    /// <summary>
    /// Clock's form
    /// </summary>
    public partial class Clock : Form
    {
        private Timer timer = new Timer();

        /// <summary>
        /// Clock's constructor
        /// </summary>
        public Clock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clock's loading
        /// </summary>
        private void Clock_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Clock_Tick);
            timer.Start();
        }

        /// <summary>
        /// Clock's tick
        /// </summary>
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
