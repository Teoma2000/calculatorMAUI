using MauiApp1.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MauiApp1.MVVM.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged();
                }
            }
        }

        private double firstNum;
        private double secondNum;
        private string operatorMath;

        public CalculatorViewModel()
        {
            Result = "0";
        }

        public string Clear()
        {
            firstNum = 0;
            secondNum = 0;
            Result = "0";
            return Result;  
        }

        public String AppendNumber(string number)
        {
            if (Result == "0")
                Result = string.Empty;

            Result += number;
            return Result;
        }

        public void PerformOperation(string operatorSymbol)
        {
            operatorMath = operatorSymbol;
            if (double.TryParse(Result, out firstNum))
                Result = "0";
            
        }

        public string CalculateResult()
        {
            if (double.TryParse(Result, out secondNum))
            {
                double result = 0;
                switch (operatorMath)
                {
                    case "+":
                        result = firstNum + secondNum;
                        break;
                    case "-":
                        result = firstNum - secondNum;
                        break;
                    case "*":
                        result = firstNum * secondNum;
                        break;
                    case "/":
                        result = firstNum / secondNum;
                        break;
                    case "%":
                        result = (firstNum * secondNum) / 100;
                        break;
                    default:
                        break;
                }

                Result = result.ToString();
                firstNum = result;
            }
            return Result;
        }

        public string DeleteDigit()
        {
            if (!string.IsNullOrEmpty(Result))
            {
                Result = Result.Substring(0, Result.Length - 1);
            }
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
