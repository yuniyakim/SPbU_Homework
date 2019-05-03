using System;
using System.Drawing;
using System.Windows.Forms;

namespace _1._2
{
    /// <summary>
    /// Form with click on me button's class
    /// </summary>
    public partial class FormWithClickOnMeButton : System.Windows.Forms.Form
    {
        /// <summary>
        /// Form with click on me button's constructor
        /// </summary>
        public FormWithClickOnMeButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event that occurs when the button is clicked
        /// </summary>
        private void ClickOnMeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event that occurs when the mouse is moved over the button
        /// </summary>
        private void ClickOnMeButton_MouseMove(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            clickOnMeButton.Location= new Point(random.Next(0, this.ClientSize.Width - clickOnMeButton.Width), random.Next(0, this.ClientSize.Height - clickOnMeButton.Height));
        }
    }
}
