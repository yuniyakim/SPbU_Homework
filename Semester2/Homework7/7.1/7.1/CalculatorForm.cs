using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7._1
{
    public partial class CalculatorForm : Form
    {
        private Calculator calculator;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            calculator = new Calculator();
        }

        private void One_Click(object sender, EventArgs e)
        {
            calculator.Number("1");
            this.Input.Text = calculator.Current();
        }

        private void Two_Click(object sender, EventArgs e)
        {
            calculator.Number("2");
            this.Input.Text = calculator.Current();
        }

        private void Three_Click(object sender, EventArgs e)
        {
            calculator.Number("3");
            this.Input.Text = calculator.Current();
        }

        private void Four_Click(object sender, EventArgs e)
        {
            calculator.Number("4");
            this.Input.Text = calculator.Current();
        }

        private void Five_Click(object sender, EventArgs e)
        {
            calculator.Number("5");
            this.Input.Text = calculator.Current();
        }

        private void Six_Click(object sender, EventArgs e)
        {
            calculator.Number("6");
            this.Input.Text = calculator.Current();
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            calculator.Number("7");
            this.Input.Text = calculator.Current();
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            calculator.Number("8");
            this.Input.Text = calculator.Current();
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            calculator.Number("9");
            this.Input.Text = calculator.Current();
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            calculator.Number("0");
            this.Input.Text = calculator.Current();
        }

        private void Addition_Click(object sender, EventArgs e)
        {
            calculator.Operation("+");
            this.Input.Text = calculator.Current();
        }

        private void Subtraction_Click(object sender, EventArgs e)
        {
            calculator.Operation("-");
            this.Input.Text = calculator.Current();
        }

        private void Multiplication_Click(object sender, EventArgs e)
        {
            calculator.Operation("*");
            this.Input.Text = calculator.Current();
        }

        private void Division_Click(object sender, EventArgs e)
        {
            calculator.Operation("/");
            this.Input.Text = calculator.Current();
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            calculator.Backspace();
            this.Input.Text = calculator.Current();
        }

        private void Equality_Click(object sender, EventArgs e)
        {
            calculator.Equality();
            this.Input.Text = calculator.Current();
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            calculator.Dot();
            this.Input.Text = calculator.Current();
        }

        private void PlusMinus_Click(object sender, EventArgs e)
        {
            calculator.PlusMinus();
            this.Input.Text = calculator.Current();
        }

        private void C_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            this.Input.Text = calculator.Current();
        }

        private void CE_Click(object sender, EventArgs e)
        {
            calculator.ClearEntry();
            this.Input.Text = calculator.Current();
        }
    }
}
