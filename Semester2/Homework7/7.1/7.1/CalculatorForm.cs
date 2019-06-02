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
            Input.Text = calculator.Input();
        }

        private void Two_Click(object sender, EventArgs e)
        {
            calculator.Number("2");
            Input.Text = calculator.Input();
        }

        private void Three_Click(object sender, EventArgs e)
        {
            calculator.Number("3");
            Input.Text = calculator.Input();
        }

        private void Four_Click(object sender, EventArgs e)
        {
            calculator.Number("4");
            Input.Text = calculator.Input();
        }

        private void Five_Click(object sender, EventArgs e)
        {
            calculator.Number("5");
            Input.Text = calculator.Input();
        }

        private void Six_Click(object sender, EventArgs e)
        {
            calculator.Number("6");
            Input.Text = calculator.Input();
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            calculator.Number("7");
            Input.Text = calculator.Input();
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            calculator.Number("8");
            Input.Text = calculator.Input();
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            calculator.Number("9");
            Input.Text = calculator.Input();
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            calculator.Number("0");
            Input.Text = calculator.Input();
        }

        private void Addition_Click(object sender, EventArgs e)
        {
            calculator.Operation("+");
            Input.Text = calculator.Input();
            InputStringText.Text = calculator.InputString;
        }

        private void Subtraction_Click(object sender, EventArgs e)
        {
            calculator.Operation("-");
            Input.Text = calculator.Input();
            InputStringText.Text = calculator.InputString;
        }

        private void Multiplication_Click(object sender, EventArgs e)
        {
            calculator.Operation("*");
            Input.Text = calculator.Input();
            InputStringText.Text = calculator.InputString;
        }

        private void Division_Click(object sender, EventArgs e)
        {
            calculator.Operation("/");
            Input.Text = calculator.Input();
            InputStringText.Text = calculator.InputString;
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            calculator.Backspace();
            Input.Text = calculator.Input();
        }

        private void Equality_Click(object sender, EventArgs e)
        {
            calculator.Equality();
            Input.Text = calculator.Input();
            InputStringText.Text = calculator.InputString;
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            calculator.Dot();
            Input.Text = calculator.Input();
        }

        private void PlusMinus_Click(object sender, EventArgs e)
        {
            calculator.PlusMinus();
            Input.Text = calculator.Input();
        }

        private void C_Click(object sender, EventArgs e)
        {
            calculator.Clear();
            Input.Text = calculator.Input();
            InputStringText.Text = calculator.InputString;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            calculator.ClearEntry();
            Input.Text = calculator.Input();
        }
    }
}
