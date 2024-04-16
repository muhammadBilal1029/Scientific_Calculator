using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scientific_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button33_Click(object sender, EventArgs e)
        {
            string expression = textBox1.Text.Trim();
            double result;

            if (TryEvaluateExpression(expression, out result))
            {
                textBox1.Text = result.ToString();
            }
            else
            {
                textBox1.Text = "Error: Invalid expression";
            }
        }

        private bool TryEvaluateExpression(string expression, out double result)
        {
            expression = expression.Replace(" ", "");
            if (expression.StartsWith("(") && expression.EndsWith(")"))
            {
                TryEvaluateExpression(expression.Substring(1, expression.Length - 2), out result);
            }

            if (expression.Contains("+"))
            {
                string[] parts = expression.Split('+');
                if (parts.Length == 2 && double.TryParse(parts[0], out double num1) && double.TryParse(parts[1], out double num2))
                {
                    result = num1 + num2;
                    return true;
                }
            }
            else if (expression.Contains("-"))
            {
                string[] parts = expression.Split('-');
                if (parts.Length == 2 && double.TryParse(parts[0], out double num1) && double.TryParse(parts[1], out double num2))
                {
                    result = num1 - num2;
                    return true;
                }
            }
            else if (expression.Contains("/"))
            {
                string[] parts = expression.Split('/');
                if (parts.Length == 2 && double.TryParse(parts[0], out double num1) && double.TryParse(parts[1], out double num2) && num2 != 0)
                {
                    result = num1 / num2;
                    return true;
                }
            }
            else if (expression.Contains("*"))
            {
                string[] parts = expression.Split('*');
                if (parts.Length == 2 && double.TryParse(parts[0], out double num1) && double.TryParse(parts[1], out double num2))
                {
                    result = num1 * num2;
                    return true;
                }
            }
            else if (expression.Contains("%"))
            {
                string[] parts = expression.Split('%');
                if (parts.Length == 2 && double.TryParse(parts[0], out double num1) && double.TryParse(parts[1], out double num2) && num2 != 0)
                {
                    result = num1 % num2;
                    return true;
                }
            }
            else if (expression.StartsWith("log("))
            {
                string numberString = expression.Substring(4, expression.Length - 5);
                if (double.TryParse(numberString, out double number) && number > 0)
                {
                    result = Math.Log10(number);
                    return true;
                }
            }
            else if (expression.StartsWith("sin("))
            {
                string numberString = expression.Substring(4, expression.Length - 5);
                if (double.TryParse(numberString, out double number))
                {
                    result = Math.Sin(number);
                    return true;
                }
            }
            else if (expression.StartsWith("cos("))
            {
                string numberString = expression.Substring(4, expression.Length - 5);
                if (double.TryParse(numberString, out double number))
                {
                    result = Math.Cos(number);
                    return true;
                }
            }
            else if (expression.StartsWith("tan("))
            {
                string numberString = expression.Substring(4, expression.Length - 5);
                if (double.TryParse(numberString, out double number))
                {
                    result = Math.Tan(number);
                    return true;
                }
            }
            else if (expression.StartsWith("^"))
            {
                string[] parts = expression.Split('^');
                if (parts.Length == 2 && double.TryParse(parts[0], out double baseValue) && double.TryParse(parts[1], out double exponentValue))
                {
                    result = Math.Pow(baseValue, exponentValue);
                    return true;
                }
            }
            else if (expression.StartsWith("sqrt("))
            {
                string numberString = expression.Substring(5, expression.Length - 6);
                if (double.TryParse(numberString, out double number) && number >= 0)
                {
                    result = Math.Sqrt(number);
                    return true;
                }
            }
            else if (expression.ToLower() == "pi")
            {
                result = Math.PI;
                return true;
            }
           
            else if (expression.Contains("^"))
            {
                string[] parts = expression.Split('^');
                if (parts.Length == 2 && double.TryParse(parts[0], out double baseValue) && double.TryParse(parts[1], out double exponentValue))
                {
                    result = Math.Pow(baseValue, exponentValue);
                    return true;
                }
            }
            else if (expression.Contains("!"))
            {
                string[] parts = expression.Split('!');
                if (parts.Length == 2)
                {
                    if (double.TryParse(parts[0], out double num) && num >= 0)
                    {
                        result = Factorial((int)num);
                        return true;
                    }
                    else
                    {
                        result = 0;
                        return false;
                    }
                }
                else
                {
                    result = 0;
                    return false;
                }
            

        }
            else if (expression.StartsWith("Exp("))
            {
                string numberString = expression.Substring(4, expression.Length - 5);
                if (double.TryParse(numberString, out double number))
                {
                    result = Math.Exp(number);
                    return true;
                }
            }

            result = 0;
            return false;
        }

        private double Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        
    }











        private void button20_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("7");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("8");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("9");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("4");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("5");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("6");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("1");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("2");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("3");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("00");
        }

        private void button35_Click(object sender, EventArgs e)
        {
         
            AppendTextToTextbox("0");
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ".")
            {

            }
            else
            {
                AppendTextToTextbox(".");

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            
                AppendTextToTextbox("(");
            
                
        }

        private void button32_Click(object sender, EventArgs e)
        {
           
                AppendTextToTextbox(")");
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text.StartsWith("-"))
           {
                textBox1.Text = textBox1.Text.Substring(1);
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else if (textBox1.Text.Length > 0 && IsOperator(textBox1.Text[textBox1.Text.Length - 1]))
            {
                return;
            }
            else
            {
                AppendTextToTextbox("/");


            }
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c=='^' || c == '-' || c == '*' || c == '/' || c == '^' || c == '%' || c == '(' || c == ')';
        }



        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("sqrt(");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else if (textBox1.Text.Length > 0 && IsOperator(textBox1.Text[textBox1.Text.Length - 1]))
            {
                return;
            }
            else
            {
                AppendTextToTextbox("^");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("sin(");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("cos(");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("tan(");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("log(");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                AppendTextToTextbox("!");
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else if (textBox1.Text.Length > 0 && IsOperator(textBox1.Text[textBox1.Text.Length - 1]))
            {
                return;
            }
            else
            {
                AppendTextToTextbox("*");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "-")
            {

            }
            else if (textBox1.Text.Length > 0 && IsOperator(textBox1.Text[textBox1.Text.Length - 1]))
            {
                return;
            }
            else
            {
                AppendTextToTextbox("-");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "+")
            {

            }
            else if (textBox1.Text.Length > 0 && IsOperator(textBox1.Text[textBox1.Text.Length - 1]))
            {
                return;
            }
            else
            {
                AppendTextToTextbox("+");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else if (textBox1.Text.Length > 0 && IsOperator(textBox1.Text[textBox1.Text.Length - 1]))
            {
                return;
            }
            else
            {
                AppendTextToTextbox("^");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            
                AppendTextToTextbox("10^");
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("Exp(");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

            }
            else if (textBox1.Text.Length > 0 && IsOperator(textBox1.Text[textBox1.Text.Length - 1]))
            {
                return;
            }
            else
            {
                AppendTextToTextbox("%");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("pi");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AppendTextToTextbox("1/");
        }

        private void AppendTextToTextbox(string text)
        {
            
            textBox1.Text += text;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}