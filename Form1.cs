using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int currentResult = 0;
        string currentRoman = "";
        string firstRoman = "";
        int firstNumber = 0;
        string secondRoman = "";
        int secondNumber = 0;
        string operation = "";
        int result = 0;
        string resultRoman = "";
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BM_Click(object sender, EventArgs e)
        {
            if(currentResult % 1000 == 0 && currentResult <= 2000 || currentResult == 0)
            {
                currentResult += 1000;
                currentRoman += "M";
                label1.Text = currentRoman;
            }
        }

        private void BD_Click(object sender, EventArgs e)
        {
            if(currentResult % 1000 == 0 || currentResult == 0 )
            {
                currentResult += 500;
                currentRoman += "D";
                label1.Text = currentRoman;
            }
            if (currentResult % 1000 == 100)
            {
                currentResult += 300;
                currentRoman += "D";
                label1.Text = currentRoman;

            }
        }

        private void BC_Click(object sender, EventArgs e)
        {
            if( currentResult == 0 ||
                currentResult % 500 == 0 ||
                currentResult % 500 == 100 ||
                currentResult % 500 == 200)
            {
                currentResult += 100;
                currentRoman += "C";
                label1.Text = currentRoman;
            }
            if( currentResult % 100 == 10)
            {
                currentResult += 80;
                currentRoman += "C";
                label1.Text = currentRoman;
            }
        }

        private void BL_Click(object sender, EventArgs e)
        {
            if (currentResult % 100 == 0 || currentResult == 0)
            {
                currentResult += 50;
                currentRoman += "L";
                label1.Text = currentRoman;
            }
            if (currentResult % 100 == 10)
            {
                currentResult += 30;
                currentRoman += "L";
                label1.Text = currentRoman;
            }
        }

        private void BX_Click(object sender, EventArgs e)
        {
            if (currentResult == 0 ||
                currentResult % 50 == 0 ||
                currentResult % 50 == 10 ||
                currentResult % 50 == 20)
            {
                currentResult += 10;
                currentRoman += "X";
                label1.Text = currentRoman;
            }
            if (currentResult % 10 == 1)
            {
                currentResult += 8;
                currentRoman += "X";
                label1.Text = currentRoman;
            }
        }

        private void BV_Click(object sender, EventArgs e)
        {
            if (currentResult % 10 == 0 || currentResult == 0)
            {
                currentResult += 5;
                currentRoman += "V";
                label1.Text = currentRoman;
            }
            if (currentResult % 10 == 1)
            {
                currentResult += 3;
                currentRoman += "V";
                label1.Text = currentRoman;
            }
        }

        private void BI_Click(object sender, EventArgs e)
        {
          if(currentResult % 5 < 3 || currentResult == 0)
            {
                currentRoman += "I";
                currentResult += 1;
                label1.Text = currentRoman;
            }
            MessageBox.Show($"{firstNumber} {secondNumber} ");
        }
        
        private void BPlus_Click(object sender, EventArgs e)
        {
            firstRoman = currentRoman;
            firstNumber = currentResult;
            currentRoman = "";
            currentResult = 0;
            label1.Text = currentRoman;
            operation = "+";
        }

        private void BMinus_Click(object sender, EventArgs e)
        {
            firstRoman = currentRoman;
            firstNumber = currentResult;
            currentRoman = "";
            currentResult = 0;
            operation = "-";
        }

        private void BMultiply_Click(object sender, EventArgs e)
        {
            firstRoman = currentRoman;
            firstNumber = currentResult;
            currentRoman = "";
            currentResult = 0;
            operation = "*";
        }

        private void BDivide_Click(object sender, EventArgs e)
        {
            firstRoman = currentRoman;
            firstNumber = currentResult;
            currentRoman = "";
            currentResult = 0;
            operation = "/";
        }

        private void BCalculate_Click(object sender, EventArgs e)
        {
            secondNumber = currentResult;
            if (operation == "+")
            {
                result = firstNumber + secondNumber;
                resultRoman = ToRoman(result);
                label1.Text = resultRoman;
            }
            if (operation == "-")
            {
                result = firstNumber - secondNumber;
                resultRoman = ToRoman(result);
                label1.Text = resultRoman;
            }
            if (operation == "*")
            {
                result = firstNumber * secondNumber;
                resultRoman = ToRoman(result);
                label1.Text = resultRoman;
            }
            if (operation == "/")
            {
                result = firstNumber / secondNumber;
                resultRoman = ToRoman(result);
                label1.Text = resultRoman;
            }
            secondNumber = 0;
            secondRoman = "";
            firstNumber = result;
            firstRoman = ToRoman(result);
            operation = "";
        }

        private void BDelete_Click(object sender, EventArgs e)
        {

        }

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }
    }
}
