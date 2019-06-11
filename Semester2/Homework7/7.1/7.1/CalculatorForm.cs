using System;
using System.Windows.Forms;

namespace _7._1
{
    /// <summary>
    /// Calculator's form
    /// </summary>
    public partial class CalculatorForm : Form
    {
        private Calculator calculator;

        /// <summary>
        /// Calculator's form's constructor
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculator's loading
        /// </summary>
        private void Calculator_Load(object sender, EventArgs e)
        {
            calculator = new Calculator();
        }

        /// <summary>
        /// Processes number's click
        /// </summary>
        private void Number_Click(object sender, EventArgs e)
        {
            calculator.Number((string)((Button)sender).Tag);
        }

        /// <summary>
        /// Processes operation's click
        /// </summary>
        private void Operation_Click(object sender, EventArgs e)
        {
            calculator.Operation((string)((Button)sender).Tag);
        }

        /// <summary>
        /// Processes backspace's click
        /// </summary>
        private void Backspace_Click(object sender, EventArgs e)
        {
            calculator.Backspace();
        }

        /// <summary>
        /// Processes equality's click
        /// </summary>
        private void Equality_Click(object sender, EventArgs e)
        {
            calculator.Equality();
        }

        /// <summary>
        /// Processes dot's click
        /// </summary>
        private void Dot_Click(object sender, EventArgs e)
        {
            calculator.Dot();
        }

        /// <summary>
        /// Processes plusMinus's click
        /// </summary>
        private void PlusMinus_Click(object sender, EventArgs e)
        {
            calculator.PlusMinus();
        }

        /// <summary>
        /// Processes C's click
        /// </summary>
        private void C_Click(object sender, EventArgs e)
        {
            calculator.Clear();
        }

        /// <summary>
        /// Processes CE's click
        /// </summary>
        private void CE_Click(object sender, EventArgs e)
        {
            calculator.ClearEntry();
        }

        /// <summary>
        /// Refreshes Input's and WholeInput's texts
        /// </summary>
        private void InputAndWholeInputRefresh(object sender, EventArgs e)
        {
            Input.Text = calculator.Input;
            WholeInput.Text = calculator.WholeInput;
        }
    }
}
