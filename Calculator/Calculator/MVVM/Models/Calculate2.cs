using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.MVVM.Models
{
    public class Calculate2
    {

        int currentState = 1;
        string operatorMath;
        double firstNum, secondNum;

        public Calculate2()
        {
            OnClear(this, null);
            BorrarDigitoCommand = new Command(BorrarDigito);
            this.BindingContext = this;
        }
        public ICommand BorrarDigitoCommand { get; }

        void OnClear(object sender, EventArgs e)
        {
            firstNum = 0;
            secondNum = 0;
            currentState = 1;
            this.result.Text = "0";
        }

        void OnSquareRoot(object sender, EventArgs e)
        {
            if (firstNum == 0)
                return;
            firstNum = (firstNum * secondNum) / 100;

            this.result.Text = firstNum.ToString();
        }

        void OnNumberSelection(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnPressed = button.Text;

            if (this.result.Text == "0" || currentState < 0)
            {
                this.result.Text = string.Empty;
                if (currentState < 0)
                    currentState *= -1;
            }

            this.result.Text += btnPressed;

            double number;
            if (double.TryParse(this.result.Text, out number))
            {
                this.result.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNum = number;
                }
                else
                {
                    secondNum = number;
                }
            }
        }


        void onOperatorSelection(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string btnPressed = button.Text;
            operatorMath = btnPressed;
        }

        void onCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Calculate.DoCalculation(firstNum, secondNum, operatorMath);

                this.result.Text = result.ToString();
                firstNum = result;
                currentState = -1;
            }
        }

        void OnPercentage(object sender, EventArgs e)
        {
            if (firstNum == 0)
                return;

            double percentage = double.Parse(this.result.Text) / 100;
            firstNum *= percentage;

            this.result.Text = firstNum.ToString();
        }

        private void BorrarDigito()
        {
            if (!string.IsNullOrEmpty(this.result.Text))
            {
                this.result.Text = this.result.Text.Substring(0, this.result.Text.Length - 1);
            }
        }

    }
}
