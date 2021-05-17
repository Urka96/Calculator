using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double current_result, new_number;
        bool isValueRes = false, isValueNumReady = false;
        bool wasClicked = false;
        string symbol, all_op;

        private void doMath()
        {
            switch (symbol)
            {
                case "+":
                    current_result += new_number;
                    break;
                case "-":
                    current_result -= new_number;
                    break;
                case "*":
                    current_result *= new_number;
                    break;
                case "/":
                    current_result /= new_number;
                    break;
                default:
                    break;
            }
            resultWindow.Text = current_result.ToString();
            isValueNumReady = false;
            
        }

        private void result_Click(object sender, EventArgs e)
        {
            if (wasClicked)
            {
                return;
            }
            wasClicked = true;
            if (isValueNumReady)
                new_number = Convert.ToDouble(resultWindow.Text);
            doMath();
            all_op += " " + new_number.ToString() + " =";
            operation.Text = all_op;
            isValueNumReady = false;
        }

        private void digit0_9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (resultWindow.Text == "0" && btn.Text != "0")
                resultWindow.Text = btn.Text;           
            else if (!isValueNumReady && isValueRes)
            {
                resultWindow.Text = btn.Text;
                isValueNumReady = true;
            }
            else 
                resultWindow.AppendText(btn.Text);
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //resultWindow.AppendText(btn.Text);
            symbol = btn.Text;
            wasClicked = false;
            if (!isValueRes)
            {
                current_result = Convert.ToDouble(resultWindow.Text);
                all_op = resultWindow.Text + " " + symbol;
                operation.Text = all_op;
                isValueRes = true;
            }
            else
            {
                all_op = resultWindow.Text + " " + symbol;
                operation.Text = all_op;
            }
            if (isValueNumReady)
            {
                new_number = Convert.ToDouble(resultWindow.Text);
                doMath();
                all_op = current_result.ToString() + " " + symbol;
                operation.Text = all_op;
            }
            
        }



    }
}
