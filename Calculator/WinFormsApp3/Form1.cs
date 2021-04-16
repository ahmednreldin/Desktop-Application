using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {

        String myOperator = ""; // for mathmatics Operator +/-..
        double num1, num2,result;
        bool isOperationAdded = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void num_Click(object sender, EventArgs e)
        {
            // create button object 
            Button btn = (Button)sender;

              if (isOperationAdded)
            {
                if(userInput.Text =="0")
                {
                    userInput.Text = btn.Text;
                    num2 = double.Parse(btn.Text);
                }
                else
                {
                    userInput.Text += btn.Text;
                    if(num2 == 0)
                    {
                       num2 = double.Parse(btn.Text);
                    }
                    else 
                    num2 = double.Parse(num2.ToString() + btn.Text);

                }
                
            }
            else
            {
                // Clear text box if at inital state 
                if (userInput.Text == "0")
                {
                    userInput.Text = btn.Text;
                }
                else
                {
                    userInput.Text += btn.Text;
                }
            }

            // decimal place 
            if (btn.Text == ".")
            {
                // Handle if click decimal btn twice
                if (!userInput.Text.Contains("."))
                    userInput.Text += btn.Text;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
                
        }


        private void signBtn_Click(object sender, EventArgs e)
        {
            if (userInput.Text.Contains("-"))
            {
                userInput.Text = userInput.Text.Remove(0,1);
            }
            else
                userInput.Text = "-" + userInput.Text;
        }

        private void CE_Click(object sender, EventArgs e)
        {
            
            if(userInput.Text.Length > 0)
            {
                userInput.Text = userInput.Text.Remove(userInput.Text.Length - 1, 1);
            }
            if(userInput.Text == "")
            {
                userInput.Text = "0";
                num1 = num2 = 0;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            isOperationAdded = false;

            switch (myOperator)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                default:
                    break;
            }
            userInput.Text = result.ToString();
        }

        private void C_Click(object sender, EventArgs e)
        {
            userInput.Text = "0";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            userInput.Text = "0";
            num1 = num2 = result = 0;
            isOperationAdded = false;
        }

        private void OperationFunction(object sender, EventArgs e)
        {
            // Crate object to handle click 
            Button btn = (Button)sender; // contain +-/..etc
            myOperator = btn.Text;  // put +- to myOperator variable 

            // Put first operand (what inside the txtbox to var num1)
            num1 = double.Parse(userInput.Text);

            // Clear txtbox
            userInput.Text += btn.Text;

            // Enable myOperator 
            isOperationAdded = true;

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
